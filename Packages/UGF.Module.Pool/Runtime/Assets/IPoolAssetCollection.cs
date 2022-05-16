using UGF.Pool.Runtime;
using UnityEngine;

namespace UGF.Module.Pool.Runtime.Assets
{
    public interface IPoolAssetCollection : IPoolCollection
    {
        Object Asset { get; }
    }
}
