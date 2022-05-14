using System.Collections.Generic;
using UGF.Application.Runtime;
using UGF.Builder.Runtime;

namespace UGF.Module.Pool.Runtime
{
    public class PoolModuleDescription : ApplicationModuleDescription
    {
        public bool UnloadOnUninitialize { get; set; }
        public Dictionary<string, IPoolDescription> Pools { get; } = new Dictionary<string, IPoolDescription>();
        public Dictionary<string, IBuilder<IPoolLoader>> Loaders { get; } = new Dictionary<string, IBuilder<IPoolLoader>>();
        public List<string> Preload { get; } = new List<string>();
        public List<string> PreloadAsync { get; } = new List<string>();
    }
}
