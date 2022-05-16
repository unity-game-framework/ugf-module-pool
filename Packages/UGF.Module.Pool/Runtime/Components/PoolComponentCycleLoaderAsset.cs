using UGF.Pool.Runtime.Unity;
using UnityEngine;

namespace UGF.Module.Pool.Runtime.Components
{
    [CreateAssetMenu(menuName = "Unity Game Framework/Pool/Pool Component Cycle Loader", order = 2000)]
    public class PoolComponentCycleLoaderAsset : PoolLoaderAsset
    {
        protected override IPoolLoader OnBuild()
        {
            return new PoolComponentCycleLoader<PoolComponent>();
        }
    }
}
