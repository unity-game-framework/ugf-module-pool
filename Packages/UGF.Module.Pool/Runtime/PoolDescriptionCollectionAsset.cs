using System;
using System.Collections.Generic;
using UGF.EditorTools.Runtime.Ids;
using UnityEngine;

namespace UGF.Module.Pool.Runtime
{
    public abstract class PoolDescriptionCollectionAsset : ScriptableObject
    {
        public void GetDescriptions(IDictionary<GlobalId, IPoolDescription> descriptions)
        {
            if (descriptions == null) throw new ArgumentNullException(nameof(descriptions));

            OnGetDescriptions(descriptions);
        }

        protected abstract void OnGetDescriptions(IDictionary<GlobalId, IPoolDescription> descriptions);
    }
}
