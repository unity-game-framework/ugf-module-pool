using System;
using Object = UnityEngine.Object;

namespace UGF.Module.Pool.Runtime.Assets
{
    public static class PoolAssetUtility
    {
        public static void CollectionBuild(IPoolAssetCollection collection, int count)
        {
            if (collection == null) throw new ArgumentNullException(nameof(collection));
            if (count < 0) throw new ArgumentOutOfRangeException(nameof(count));

            for (int i = 0; i < count; i++)
            {
                collection.Add(Object.Instantiate(collection.Asset));
            }
        }

        public static void CollectionDestroy(IPoolAssetCollection collection)
        {
            if (collection == null) throw new ArgumentNullException(nameof(collection));

            if (collection.EnabledCount > 0)
            {
                collection.DisableAll();
            }

            foreach (Object asset in collection)
            {
                Object.Destroy(asset);
            }

            collection.Clear();
        }
    }
}
