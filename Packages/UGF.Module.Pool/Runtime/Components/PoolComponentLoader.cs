using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using UGF.Application.Runtime;
using UGF.Module.Assets.Runtime;
using UGF.Module.Pool.Runtime.Assets;
using UGF.RuntimeTools.Runtime.Contexts;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace UGF.Module.Pool.Runtime.Components
{
    public abstract class PoolComponentLoader<TComponent, TCollection, TDescription> : PoolAssetLoader<TComponent, TCollection, TDescription>
        where TComponent : Component
        where TCollection : class, IPoolAssetCollection<TComponent>
        where TDescription : PoolAssetDescription
    {
        public PoolComponentLoaderDescription Description { get; }

        private readonly Dictionary<IApplication, SceneHandler> m_scenes = new Dictionary<IApplication, SceneHandler>();

        private struct SceneHandler
        {
            public Scene Scene { get; set; }
            public int Count { get; set; }
        }

        protected PoolComponentLoader(PoolComponentLoaderDescription description)
        {
            Description = description ?? throw new ArgumentNullException(nameof(description));
        }

        protected override TCollection OnLoad(TDescription description, IContext context)
        {
            var assetsModule = context.Get<IApplication>().GetModule<IAssetModule>();

            var gameObject = assetsModule.Load<GameObject>(description.AssetId);

            if (!gameObject.TryGetComponent(out TComponent component))
            {
                throw new ArgumentException($"Pool gameobject component not found of the specified type: '{typeof(TComponent)}'.");
            }

            TCollection collection = OnCollectionCreate(component, description, context);

            OnCollectionBuild(collection, description, context);

            return collection;
        }

        protected override async Task<TCollection> OnLoadAsync(TDescription description, IContext context)
        {
            var assetsModule = context.Get<IApplication>().GetModule<IAssetModule>();

            var gameObject = await assetsModule.LoadAsync<GameObject>(description.AssetId);

            if (!gameObject.TryGetComponent(out TComponent component))
            {
                throw new ArgumentException($"Pool gameobject component not found of the specified type: '{typeof(TComponent)}'.");
            }

            TCollection collection = OnCollectionCreate(component, description, context);

            OnCollectionBuild(collection, description, context);

            return collection;
        }

        protected override void OnUnload(TCollection collection, TDescription description, IContext context)
        {
            var assetsModule = context.Get<IApplication>().GetModule<IAssetModule>();

            OnCollectionDestroy(collection, description, context);

            assetsModule.Unload(description.AssetId, collection.Asset.gameObject);
        }

        protected override async Task OnUnloadAsync(TCollection collection, TDescription description, IContext context)
        {
            var assetsModule = context.Get<IApplication>().GetModule<IAssetModule>();

            OnCollectionDestroy(collection, description, context);

            await assetsModule.UnloadAsync(description.AssetId, collection.Asset.gameObject);
        }

        protected override void OnCollectionBuild(TCollection collection, TDescription description, IContext context)
        {
            PoolComponentUtility.CollectionBuild(collection, description.Count, Description.SceneName);
        }

        protected override void OnCollectionDestroy(TCollection collection, TDescription description, IContext context)
        {
            PoolComponentUtility.CollectionDestroy(collection);
        }

        protected virtual void OnSceneCreate(TCollection collection, TDescription description, IContext context)
        {
            var application = context.Get<IApplication>();
        }

        protected virtual void OnSceneUnload(TCollection collection, TDescription description, IContext context)
        {
            var application = context.Get<IApplication>();

            if (m_scenes.TryGetValue(application, out SceneHandler handler))
            {
                handler.Count--;

                m_scenes[application] = handler;

                if (handler.Count == 0)
                {
#pragma warning disable CS0618
                    SceneManager.UnloadScene(handler.Scene);
#pragma warning restore CS0618

                    m_scenes.Remove(application);
                }
            }
        }
    }
}
