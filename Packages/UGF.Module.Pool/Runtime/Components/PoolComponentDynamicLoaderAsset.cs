using UGF.Pool.Runtime.Unity;
using UnityEngine;

namespace UGF.Module.Pool.Runtime.Components
{
    [CreateAssetMenu(menuName = "Unity Game Framework/Pool/Pool Component Dynamic Loader", order = 2000)]
    public class PoolComponentDynamicLoaderAsset : PoolComponentLoaderAsset
    {
        protected override IPoolLoader OnBuild(PoolComponentLoaderDescription description)
        {
            return new PoolComponentDynamicLoader<PoolComponent>(description);
        }
    }
}
