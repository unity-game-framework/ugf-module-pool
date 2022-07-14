using UGF.Description.Runtime;
using UGF.EditorTools.Runtime.Ids;

namespace UGF.Module.Pool.Runtime
{
    public class PoolDescription : DescriptionBase, IPoolDescription
    {
        public GlobalId LoaderId { get; set; }
    }
}
