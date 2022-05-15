using UnityEngine;

namespace UGF.Module.Pool.Runtime.Assets
{
    [CreateAssetMenu(menuName = "Unity Game Framework/Pool/Pool Asset Static Loader", order = 2000)]
    public class PoolAssetStaticLoaderAsset : PoolLoaderAsset
    {
        protected override IPoolLoader OnBuild()
        {
            return new PoolAssetStaticLoader<Object, PoolAssetDescription>();
        }
    }
}
