using System;
using UGF.Module.Pool.Runtime.Assets;
using UnityEngine;
using UnityEngine.SceneManagement;
using Object = UnityEngine.Object;

namespace UGF.Module.Pool.Runtime.Components
{
    public static class PoolComponentUtility
    {
        public static void CollectionBuild(IPoolAssetCollection collection, int count, string sceneName)
        {
            if (string.IsNullOrEmpty(sceneName)) throw new ArgumentException("Value cannot be null or empty.", nameof(sceneName));

            Scene scene = SceneManager.GetSceneByName(sceneName);

            if (!scene.IsValid())
            {
                scene = SceneManager.CreateScene(sceneName);
            }

            CollectionBuild(collection, count, scene);
        }

        public static void CollectionBuild(IPoolAssetCollection collection, int count, Scene scene)
        {
            if (collection == null) throw new ArgumentNullException(nameof(collection));
            if (count < 0) throw new ArgumentOutOfRangeException(nameof(count));
            if (!scene.IsValid()) throw new ArgumentException("Value should be valid.", nameof(scene));

            for (int i = 0; i < count; i++)
            {
                var asset = (Component)collection.Asset;
                Component component = Object.Instantiate(asset);

                SceneManager.MoveGameObjectToScene(component.gameObject, scene);

                collection.Add(component);
            }
        }

        public static void CollectionDestroy(IPoolAssetCollection collection, string sceneName)
        {
            if (string.IsNullOrEmpty(sceneName)) throw new ArgumentException("Value cannot be null or empty.", nameof(sceneName));

            CollectionDestroy(collection);

            Scene scene = SceneManager.GetSceneByName(sceneName);

            if (scene.IsValid() && scene.rootCount == 0 && scene.isLoaded)
            {
                SceneManager.UnloadSceneAsync(sceneName);
            }
        }

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
