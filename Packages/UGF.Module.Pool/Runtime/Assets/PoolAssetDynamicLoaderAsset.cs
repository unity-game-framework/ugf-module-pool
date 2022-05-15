using UnityEngine;

namespace UGF.Module.Pool.Runtime.Assets
{
    [CreateAssetMenu(menuName = "Unity Game Framework/Pool/Pool Asset Dynamic Loader", order = 2000)]
    public class PoolAssetDynamicLoaderAsset : PoolLoaderAsset
    {
        protected override IPoolLoader OnBuild()
        {
            return new PoolAssetDynamicLoader<Object, PoolAssetDynamicDescription>();
        }
    }
}
