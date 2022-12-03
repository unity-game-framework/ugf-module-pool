using UGF.Description.Runtime;
using UnityEngine.SceneManagement;

namespace UGF.Module.Pool.Runtime.Components
{
    public class PoolComponentLoaderDescription : DescriptionBase
    {
        public string SceneName { get; set; }
        public CreateSceneParameters SceneCreateParameters { get; set; }
    }
}
