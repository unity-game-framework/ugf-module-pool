using System;
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
