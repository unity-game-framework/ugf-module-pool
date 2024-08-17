using UnityEngine;

namespace UGF.Module.Pool.Runtime.Components
{
    public abstract class PoolComponentLoaderAsset : PoolLoaderAsset
    {
        [SerializeField] private string m_sceneName = "Pool";

        public string SceneName { get { return m_sceneName; } set { m_sceneName = value; } }

        protected override IPoolLoader OnBuild()
        {
            var description = new PoolComponentLoaderDescription(m_sceneName);

            return OnBuild(description);
        }

        protected abstract IPoolLoader OnBuild(PoolComponentLoaderDescription description);
    }
}
