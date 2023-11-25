using UGF.Assets.Editor;
using UGF.EditorTools.Runtime.Assets;
using UGF.EditorTools.Runtime.Ids;
using UGF.Module.Pool.Runtime;
using UnityEditor;
using UnityEngine;

namespace UGF.Module.Pool.Editor
{
    [CreateAssetMenu(menuName = "Unity Game Framework/Pool/Pool Description Collection List Folder", order = 2000)]
    public class PoolDescriptionCollectionListFolderAsset : AssetFolderAsset<PoolDescriptionCollectionListAsset, PoolDescriptionAsset>
    {
        protected override void OnUpdate()
        {
            Collection.Pools.Clear();

            string[] guids = FindAssetsAsGuids();

            for (int i = 0; i < guids.Length; i++)
            {
                string guid = guids[i];
                string path = AssetDatabase.GUIDToAssetPath(guid);

                var id = new GlobalId(guid);
                var asset = AssetDatabase.LoadAssetAtPath<PoolDescriptionAsset>(path);

                Collection.Pools.Add(new AssetIdReference<PoolDescriptionAsset>(id, asset));
            }

            EditorUtility.SetDirty(Collection);
        }
    }
}
