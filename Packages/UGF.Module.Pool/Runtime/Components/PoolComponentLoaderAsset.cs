using UnityEngine;

namespace UGF.Module.Pool.Runtime.Components
{
    public abstract class PoolComponentLoaderAsset : PoolLoaderAsset
    {
        [SerializeField] private string m_sceneName = "Pool";
        [SerializeField] private bool m_sceneCreate = true;
        [SerializeField] private bool m_sceneUnloadEmpty = true;

        public string SceneName { get { return m_sceneName; } set { m_sceneName = value; } }
        public bool SceneCreate { get { return m_sceneCreate; } set { m_sceneCreate = value; } }
        public bool SceneUnloadEmpty { get { return m_sceneUnloadEmpty; } set { m_sceneUnloadEmpty = value; } }

        protected override IPoolLoader OnBuild()
        {
            var description = new PoolComponentLoaderDescription
            {
                SceneName = m_sceneName,
                SceneCreate = m_sceneCreate,
                SceneUnloadEmpty = m_sceneUnloadEmpty
            };

            return OnBuild(description);
        }

        protected abstract IPoolLoader OnBuild(PoolComponentLoaderDescription description);
    }
}
