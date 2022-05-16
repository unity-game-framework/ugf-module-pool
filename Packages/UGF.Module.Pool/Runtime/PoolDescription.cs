using UGF.Description.Runtime;

namespace UGF.Module.Pool.Runtime
{
    public class PoolDescription : DescriptionBase, IPoolDescription
    {
        public string LoaderId { get; set; }
    }
}
