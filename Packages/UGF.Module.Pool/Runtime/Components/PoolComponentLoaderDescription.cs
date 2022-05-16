using UGF.Description.Runtime;

namespace UGF.Module.Pool.Runtime.Components
{
    public class PoolComponentLoaderDescription : DescriptionBase
    {
        public string SceneName { get; set; }
        public bool SceneCreate { get; set; }
        public bool SceneUnloadEmpty { get; set; }
    }
}
