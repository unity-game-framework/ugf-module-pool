using UGF.RuntimeTools.Runtime.Contexts;
using UnityEngine;

namespace UGF.Module.Pool.Runtime.Assets
{
    public class PoolAssetCycleLoader<TAsset, TDescription> : PoolAssetLoader<TAsset, PoolAssetCollectionCycle<TAsset>, TDescription>
        where TAsset : Object
        where TDescription : PoolAssetDescription
    {
        protected override PoolAssetCollectionCycle<TAsset> OnCreateCollection(TAsset asset, TDescription description, IContext context)
        {
            return new PoolAssetCollectionCycle<TAsset>(asset, description.Capacity);
        }

        protected override TAsset OnGetAsset(PoolAssetCollectionCycle<TAsset> collection, TDescription description, IContext context)
        {
            return collection.Asset;
        }
    }
}
