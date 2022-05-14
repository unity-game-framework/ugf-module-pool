using UGF.Description.Runtime;

namespace UGF.Module.Pool.Runtime
{
    public interface IPoolDescription : IDescription
    {
        string LoaderId { get; }
    }
}
