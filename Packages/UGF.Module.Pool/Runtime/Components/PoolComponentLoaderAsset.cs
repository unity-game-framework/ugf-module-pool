using UnityEngine;
using UnityEngine.SceneManagement;

namespace UGF.Module.Pool.Runtime.Components
{
    public abstract class PoolComponentLoaderAsset : PoolLoaderAsset
    {
        [SerializeField] private string m_sceneName = "Pool";
        [SerializeField] private CreateSceneParameters m_sceneCreateParameters;

        public string SceneName { get { return m_sceneName; } set { m_sceneName = value; } }
        public CreateSceneParameters SceneCreateParameters { get { return m_sceneCreateParameters; } set { m_sceneCreateParameters = value; } }

        protected override IPoolLoader OnBuild()
        {
            var description = new PoolComponentLoaderDescription
            {
                SceneName = m_sceneName,
                SceneCreateParameters = m_sceneCreateParameters
            };

            return OnBuild(description);
        }

        protected abstract IPoolLoader OnBuild(PoolComponentLoaderDescription description);
    }
}
