using UGF.Pool.Runtime;
using UnityEngine;

namespace UGF.Module.Pool.Runtime.Assets
{
    public interface IPoolAssetCollection<TAsset> : IPoolCollection<TAsset> where TAsset : Object
    {
        TAsset Asset { get; }
    }
}
