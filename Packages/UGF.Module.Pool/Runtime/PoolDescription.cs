using System;
using UGF.Description.Runtime;
using UGF.EditorTools.Runtime.Ids;

namespace UGF.Module.Pool.Runtime
{
    public class PoolDescription : DescriptionBase, IPoolDescription
    {
        public GlobalId LoaderId { get; }

        public PoolDescription(GlobalId loaderId)
        {
            if (!loaderId.IsValid()) throw new ArgumentException("Value should be valid.", nameof(loaderId));

            LoaderId = loaderId;
        }
    }
}
