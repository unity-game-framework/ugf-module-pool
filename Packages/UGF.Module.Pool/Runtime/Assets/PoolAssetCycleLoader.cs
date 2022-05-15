using UGF.RuntimeTools.Runtime.Contexts;
using UnityEngine;

namespace UGF.Module.Pool.Runtime.Assets
{
    public class PoolAssetCycleLoader<TAsset> : PoolAssetLoader<TAsset, PoolAssetCycleCollection<TAsset>, PoolAssetDescription> where TAsset : Object
    {
        protected override PoolAssetCycleCollection<TAsset> OnCreateCollection(TAsset asset, PoolAssetDescription description, IContext context)
        {
            return new PoolAssetCycleCollection<TAsset>(asset, description.Capacity);
        }
    }
}
