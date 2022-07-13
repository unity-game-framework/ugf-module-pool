using UGF.Description.Runtime;
using UGF.EditorTools.Runtime.Ids;

namespace UGF.Module.Pool.Runtime
{
    public interface IPoolDescription : IDescription
    {
        GlobalId LoaderId { get; }
    }
}
