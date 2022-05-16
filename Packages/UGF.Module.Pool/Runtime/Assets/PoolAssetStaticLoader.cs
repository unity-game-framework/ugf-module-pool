using UGF.RuntimeTools.Runtime.Contexts;
using UnityEngine;

namespace UGF.Module.Pool.Runtime.Assets
{
    public class PoolAssetStaticLoader<TAsset> : PoolAssetLoader<TAsset, PoolAssetStaticCollection<TAsset>, PoolAssetDescription> where TAsset : Object
    {
        protected override PoolAssetStaticCollection<TAsset> OnCollectionCreate(TAsset asset, PoolAssetDescription description, IContext context)
        {
            return new PoolAssetStaticCollection<TAsset>(asset, description.Capacity);
        }
    }
}
