using System;
using System.Linq;
using System.Threading.Tasks;
using UGF.Application.Runtime;
using UGF.Builder.Runtime;
using UGF.Logs.Runtime;
using UGF.Pool.Runtime;
using UGF.RuntimeTools.Runtime.Contexts;
using UGF.RuntimeTools.Runtime.Providers;

namespace UGF.Module.Pool.Runtime
{
    public class PoolModule : ApplicationModule<PoolModuleDescription>, IApplicationModuleAsync
    {
        public IProvider<string, IPoolCollection> Pools { get; } = new Provider<string, IPoolCollection>();
        public IProvider<string, IPoolLoader> Loaders { get; } = new Provider<string, IPoolLoader>();
        public IContext Context { get; }

        public PoolModule(PoolModuleDescription description, IApplication application) : base(description, application)
        {
            Context = new Context { application };
        }

        protected override void OnInitialize()
        {
            base.OnInitialize();

            foreach ((string key, IBuilder<IPoolLoader> value) in Description.Loaders)
            {
                Loaders.Add(key, value.Build());
            }

            foreach (string id in Description.Preload)
            {
                Load(id);
            }

            Log.Debug("Pool Module initialized", new
            {
                pools = Description.Pools.Count,
                loaders = Description.Loaders.Count,
                preload = Description.Preload.Count
            });
        }

        public async Task InitializeAsync()
        {
            Log.Debug("Pool Module initialize async", new
            {
                preloadAsync = Description.PreloadAsync.Count
            });

            foreach (string id in Description.PreloadAsync)
            {
                await LoadAsync(id);
            }
        }

        protected override void OnUninitialize()
        {
            base.OnUninitialize();

            Log.Debug("Pool Module uninitialize", new
            {
                pools = Pools.Entries.Count,
                loaders = Loaders.Entries.Count
            });

            while (Pools.Entries.Count > 0)
            {
                string id = Pools.Entries.First().Key;

                Unload(id);
            }

            Pools.Clear();
            Loaders.Clear();
        }

        public IPoolCollection Load(string id)
        {
            if (string.IsNullOrEmpty(id)) throw new ArgumentException("Value cannot be null or empty.", nameof(id));
            if (Pools.Entries.ContainsKey(id)) throw new ArgumentException($"Pool already loaded by the specified id: '{id}'.");

            Log.Debug("Pool Module loading", new { id });

            IPoolDescription description = GetPoolDescription(id);
            IPoolLoader loader = Loaders.Get(description.LoaderId);

            IPoolCollection collection = loader.Load(description, Context);

            Pools.Add(id, collection);

            return collection;
        }

        public async Task<IPoolCollection> LoadAsync(string id)
        {
            if (string.IsNullOrEmpty(id)) throw new ArgumentException("Value cannot be null or empty.", nameof(id));
            if (Pools.Entries.ContainsKey(id)) throw new ArgumentException($"Pool already loaded by the specified id: '{id}'.");

            Log.Debug("Pool Module loading async", new { id });

            IPoolDescription description = GetPoolDescription(id);
            IPoolLoader loader = Loaders.Get(description.LoaderId);

            IPoolCollection collection = await loader.LoadAsync(description, Context);

            Pools.Add(id, collection);

            return collection;
        }

        public void Unload(string id)
        {
            if (string.IsNullOrEmpty(id)) throw new ArgumentException("Value cannot be null or empty.", nameof(id));

            Log.Debug("Pool Module unloading", new { id });

            IPoolCollection collection = Pools.Get(id);
            IPoolDescription description = GetPoolDescription(id);
            IPoolLoader loader = Loaders.Get(description.LoaderId);

            loader.Unload(collection, description, Context);

            Pools.Remove(id);
        }

        public async Task UnloadAsync(string id)
        {
            if (string.IsNullOrEmpty(id)) throw new ArgumentException("Value cannot be null or empty.", nameof(id));

            Log.Debug("Pool Module unloading async", new { id });

            IPoolCollection collection = Pools.Get(id);
            IPoolDescription description = GetPoolDescription(id);
            IPoolLoader loader = Loaders.Get(description.LoaderId);

            await loader.UnloadAsync(collection, description, Context);

            Pools.Remove(id);
        }

        public IPoolDescription GetPoolDescription(string id)
        {
            return TryGetPoolDescription(id, out IPoolDescription description) ? description : throw new ArgumentException($"Pool description not found by the specified id: '{id}'.");
        }

        public bool TryGetPoolDescription(string id, out IPoolDescription description)
        {
            if (string.IsNullOrEmpty(id)) throw new ArgumentException("Value cannot be null or empty.", nameof(id));

            return Description.Pools.TryGetValue(id, out description);
        }
    }
}
