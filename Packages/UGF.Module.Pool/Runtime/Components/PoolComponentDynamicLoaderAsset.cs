using UGF.Module.Pool.Runtime.Assets;
using UGF.Pool.Runtime.Unity;
using UnityEngine;

namespace UGF.Module.Pool.Runtime.Components
{
    [CreateAssetMenu(menuName = "Unity Game Framework/Pool/Pool Component Dynamic Loader", order = 2000)]
    public class PoolComponentDynamicLoaderAsset : PoolLoaderAsset
    {
        protected override IPoolLoader OnBuild()
        {
            return new PoolAssetDynamicLoader<PoolComponent>();
        }
    }
}
