using System;
using UGF.Module.Pool.Runtime.Assets;
using UGF.Pool.Runtime.Unity;
using UGF.RuntimeTools.Runtime.Contexts;
using UnityEngine;
using UnityEngine.SceneManagement;
using Object = UnityEngine.Object;

namespace UGF.Module.Pool.Runtime.Components
{
    public class PoolComponentDynamicCollection<TComponent> : PoolCollectionDynamicComponent<TComponent>, IPoolAssetCollection<TComponent> where TComponent : Component
    {
        public Scene Scene { get; }
        public TComponent Asset { get { return Source; } }

        Object IPoolAssetCollection.Asset { get { return Asset; } }

        public PoolComponentDynamicCollection(TComponent source, Scene scene, IContext context, int capacity = 4) : base(source, context, capacity)
        {
            if (!scene.IsValid()) throw new ArgumentException("Value should be valid.", nameof(scene));

            Scene = scene;
        }

        protected override void OnDisabled(TComponent item)
        {
            base.OnDisabled(item);

            item.transform.SetParent(null, false);

            SceneManager.MoveGameObjectToScene(item.gameObject, Scene);
        }
    }
}
