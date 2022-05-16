using UGF.RuntimeTools.Runtime.Contexts;
using UnityEngine;

namespace UGF.Module.Pool.Runtime.Assets
{
    public class PoolAssetDynamicLoader<TAsset> : PoolAssetLoader<TAsset, PoolAssetDynamicCollection<TAsset>, PoolAssetDynamicDescription> where TAsset : Object
    {
        protected override PoolAssetDynamicCollection<TAsset> OnCollectionCreate(TAsset asset, PoolAssetDynamicDescription description, IContext context)
        {
            return new PoolAssetDynamicCollection<TAsset>(asset, context, description.Capacity)
            {
                DefaultCount = description.Count,
                ExpandAuto = description.ExpandEnable,
                ExpandCount = description.ExpandCount,
                ExpandThreshold = description.ExpandThreshold,
                TrimAuto = description.TrimEnable,
                TrimCount = description.TrimCount,
                TrimThreshold = description.TrimThreshold
            };
        }
    }
}
