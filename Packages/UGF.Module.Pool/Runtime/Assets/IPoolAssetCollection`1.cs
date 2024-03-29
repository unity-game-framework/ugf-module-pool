﻿using UGF.Pool.Runtime;
using UnityEngine;

namespace UGF.Module.Pool.Runtime.Assets
{
    public interface IPoolAssetCollection<TAsset> : IPoolCollection<TAsset>, IPoolAssetCollection where TAsset : Object
    {
        new TAsset Asset { get; }
    }
}
