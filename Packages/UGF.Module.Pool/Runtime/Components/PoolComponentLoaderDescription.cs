using System;
using UGF.Description.Runtime;

namespace UGF.Module.Pool.Runtime.Components
{
    public class PoolComponentLoaderDescription : DescriptionBase
    {
        public string SceneName { get; }

        public PoolComponentLoaderDescription(string sceneName)
        {
            if (string.IsNullOrEmpty(sceneName)) throw new ArgumentException("Value cannot be null or empty.", nameof(sceneName));

            SceneName = sceneName;
        }
    }
}
