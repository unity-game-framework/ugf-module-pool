﻿using UGF.Module.Pool.Runtime.Assets;
using UGF.Pool.Runtime.Unity;
using UGF.RuntimeTools.Runtime.Contexts;
using UnityEngine;

namespace UGF.Module.Pool.Runtime.Components
{
    public class PoolComponentDynamicCollection<TComponent> : PoolCollectionDynamicComponent<TComponent>, IPoolAssetCollection<TComponent> where TComponent : Component
    {
        public TComponent Asset { get { return Source; } }

        Object IPoolAssetCollection.Asset { get { return Asset; } }

        public PoolComponentDynamicCollection(TComponent source, IContext context, int capacity = 4) : base(source, context, capacity)
        {
        }
    }
}