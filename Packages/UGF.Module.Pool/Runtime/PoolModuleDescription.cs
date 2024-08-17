using System;
using System.Collections.Generic;
using UGF.Application.Runtime;
using UGF.Builder.Runtime;
using UGF.EditorTools.Runtime.Ids;

namespace UGF.Module.Pool.Runtime
{
    public class PoolModuleDescription : ApplicationModuleDescription
    {
        public bool UnloadOnUninitialize { get; set; }
        public IReadOnlyDictionary<GlobalId, IBuilder<IPoolLoader>> Loaders { get; }
        public IReadOnlyDictionary<GlobalId, IPoolDescription> Pools { get; }
        public IReadOnlyList<GlobalId> Preload { get; }
        public IReadOnlyList<GlobalId> PreloadAsync { get; }

        public PoolModuleDescription(
            bool unloadOnUninitialize,
            IReadOnlyDictionary<GlobalId, IBuilder<IPoolLoader>> loaders,
            IReadOnlyDictionary<GlobalId, IPoolDescription> pools,
            IReadOnlyList<GlobalId> preload,
            IReadOnlyList<GlobalId> preloadAsync)
        {
            UnloadOnUninitialize = unloadOnUninitialize;
            Loaders = loaders ?? throw new ArgumentNullException(nameof(loaders));
            Pools = pools ?? throw new ArgumentNullException(nameof(pools));
            Preload = preload ?? throw new ArgumentNullException(nameof(preload));
            PreloadAsync = preloadAsync ?? throw new ArgumentNullException(nameof(preloadAsync));
        }
    }
}
