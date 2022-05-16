using System.Threading.Tasks;
using UGF.Pool.Runtime;
using UGF.RuntimeTools.Runtime.Contexts;

namespace UGF.Module.Pool.Runtime
{
    public interface IPoolLoader
    {
        IPoolCollection Load(IPoolDescription description, IContext context);
        Task<IPoolCollection> LoadAsync(IPoolDescription description, IContext context);
        void Unload(IPoolCollection collection, IPoolDescription description, IContext context);
        Task UnloadAsync(IPoolCollection collection, IPoolDescription description, IContext context);
    }
}
