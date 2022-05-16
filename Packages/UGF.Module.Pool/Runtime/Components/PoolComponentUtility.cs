using System;
using UGF.Module.Pool.Runtime.Assets;
using UnityEngine;
using Object = UnityEngine.Object;

namespace UGF.Module.Pool.Runtime.Components
{
    public static class PoolComponentUtility
    {
        public static void CollectionDestroy(IPoolAssetCollection collection)
        {
            if (collection == null) throw new ArgumentNullException(nameof(collection));

            if (collection.EnabledCount > 0)
            {
                collection.DisableAll();
            }

            foreach (Component component in collection)
            {
                Object.Destroy(component.gameObject);
            }

            collection.Clear();
        }
    }
}
