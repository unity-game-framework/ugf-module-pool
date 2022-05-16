using UGF.Pool.Runtime.Unity;
using UnityEngine;

namespace UGF.Module.Pool.Runtime.Components
{
    [CreateAssetMenu(menuName = "Unity Game Framework/Pool/Pool Component Static Loader", order = 2000)]
    public class PoolComponentStaticLoaderAsset : PoolLoaderAsset
    {
        protected override IPoolLoader OnBuild()
        {
            return new PoolComponentStaticLoader<PoolComponent>();
        }
    }
}
