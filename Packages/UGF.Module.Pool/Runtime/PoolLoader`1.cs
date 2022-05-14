using System.Threading.Tasks;
using UGF.Pool.Runtime;
using UGF.RuntimeTools.Runtime.Contexts;

namespace UGF.Module.Pool.Runtime
{
    public abstract class PoolLoader<TCollection, TDescription> : PoolLoader
        where TCollection : class, IPoolCollection
        where TDescription : class, IPoolDescription
    {
        protected override IPoolCollection OnLoad(IPoolDescription description, IContext context)
        {
            return OnLoad((TDescription)description, context);
        }

        protected override async Task<IPoolCollection> OnLoadAsync(IPoolDescription description, IContext context)
        {
            return await OnLoadAsync((TDescription)description, context);
        }

        protected override void OnUnload(IPoolCollection collection, IPoolDescription description, IContext context)
        {
            OnUnload((TCollection)collection, (TDescription)description, context);
        }

        protected override Task OnUnloadAsync(IPoolCollection collection, IPoolDescription description, IContext context)
        {
            return OnUnloadAsync((TCollection)collection, (TDescription)description, context);
        }

        protected abstract TCollection OnLoad(TDescription description, IContext context);
        protected abstract Task<TCollection> OnLoadAsync(TDescription description, IContext context);
        protected abstract void OnUnload(TCollection collection, TDescription description, IContext context);
        protected abstract Task OnUnloadAsync(TCollection collection, TDescription description, IContext context);
    }
}
