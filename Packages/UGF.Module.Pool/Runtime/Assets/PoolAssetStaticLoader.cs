using UGF.RuntimeTools.Runtime.Contexts;
using UnityEngine;

namespace UGF.Module.Pool.Runtime.Assets
{
    public class PoolAssetStaticLoader<TAsset, TDescription> : PoolAssetLoader<TAsset, PoolAssetCollectionStatic<TAsset>, TDescription>
        where TAsset : Object
        where TDescription : PoolAssetDescription
    {
        protected override PoolAssetCollectionStatic<TAsset> OnCreateCollection(TAsset asset, TDescription description, IContext context)
        {
            return new PoolAssetCollectionStatic<TAsset>(asset, description.Capacity);
        }

        protected override TAsset OnGetAsset(PoolAssetCollectionStatic<TAsset> collection, TDescription description, IContext context)
        {
            return collection.Asset;
        }
    }
}
