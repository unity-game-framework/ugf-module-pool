using System;
using System.Threading.Tasks;
using UGF.Pool.Runtime;
using UGF.RuntimeTools.Runtime.Contexts;

namespace UGF.Module.Pool.Runtime
{
    public abstract class PoolLoader : IPoolLoader
    {
        public IPoolCollection Load(IPoolDescription description, IContext context)
        {
            if (description == null) throw new ArgumentNullException(nameof(description));
            if (context == null) throw new ArgumentNullException(nameof(context));

            return OnLoad(description, context);
        }

        public Task<IPoolCollection> LoadAsync(IPoolDescription description, IContext context)
        {
            if (description == null) throw new ArgumentNullException(nameof(description));
            if (context == null) throw new ArgumentNullException(nameof(context));

            return OnLoadAsync(description, context);
        }

        public void Unload(IPoolCollection collection, IPoolDescription description, IContext context)
        {
            if (collection == null) throw new ArgumentNullException(nameof(collection));
            if (description == null) throw new ArgumentNullException(nameof(description));
            if (context == null) throw new ArgumentNullException(nameof(context));

            OnUnload(collection, description, context);
        }

        public Task UnloadAsync(IPoolCollection collection, IPoolDescription description, IContext context)
        {
            if (collection == null) throw new ArgumentNullException(nameof(collection));
            if (description == null) throw new ArgumentNullException(nameof(description));
            if (context == null) throw new ArgumentNullException(nameof(context));

            return OnUnloadAsync(collection, description, context);
        }

        protected abstract IPoolCollection OnLoad(IPoolDescription description, IContext context);
        protected abstract Task<IPoolCollection> OnLoadAsync(IPoolDescription description, IContext context);
        protected abstract void OnUnload(IPoolCollection collection, IPoolDescription description, IContext context);
        protected abstract Task OnUnloadAsync(IPoolCollection collection, IPoolDescription description, IContext context);
    }
}
