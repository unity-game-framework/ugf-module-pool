using System.Collections.Generic;
using UGF.Application.Runtime;
using UGF.Builder.Runtime;
using UGF.EditorTools.Runtime.Ids;

namespace UGF.Module.Pool.Runtime
{
    public class PoolModuleDescription : ApplicationModuleDescription
    {
        public bool UnloadOnUninitialize { get; set; }
        public Dictionary<GlobalId, IBuilder<IPoolLoader>> Loaders { get; } = new Dictionary<GlobalId, IBuilder<IPoolLoader>>();
        public Dictionary<GlobalId, IPoolDescription> Pools { get; } = new Dictionary<GlobalId, IPoolDescription>();
        public List<GlobalId> Preload { get; } = new List<GlobalId>();
        public List<GlobalId> PreloadAsync { get; } = new List<GlobalId>();
    }
}
