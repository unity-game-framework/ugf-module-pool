using System;
using System.Threading.Tasks;
using UGF.Application.Runtime;
using UGF.Module.Assets.Runtime;
using UGF.Module.Pool.Runtime.Assets;
using UGF.RuntimeTools.Runtime.Contexts;
using UnityEngine;

namespace UGF.Module.Pool.Runtime.Components
{
    public abstract class PoolComponentLoader<TComponent, TCollection, TDescription> : PoolAssetLoader<TComponent, TCollection, TDescription>
        where TComponent : Component
        where TCollection : class, IPoolAssetCollection<TComponent>
        where TDescription : PoolAssetDescription
    {
        public PoolComponentLoaderDescription Description { get; }

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
    }
}
