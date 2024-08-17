using UGF.Tables.Runtime;

namespace UGF.Module.Pool.Runtime
{
    public interface IPoolDescriptionTableEntry<out TDescription> : ITableEntry where TDescription : IPoolDescription
    {
        TDescription Build();
    }
}
