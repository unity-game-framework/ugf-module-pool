using UGF.EditorTools.Editor.Assets;
using UGF.EditorTools.Editor.IMGUI;
using UGF.EditorTools.Editor.IMGUI.Scopes;
using UGF.Module.Pool.Runtime;
using UnityEditor;

namespace UGF.Module.Pool.Editor
{
    [CustomEditor(typeof(PoolDescriptionCollectionListAsset), true)]
    internal class PoolDescriptionCollectionListAssetEditor : UnityEditor.Editor
    {
        private AssetIdReferenceListDrawer m_listPools;
        private ReorderableListSelectionDrawerByPath m_listPoolsSelection;

        private void OnEnable()
        {
            m_listPools = new AssetIdReferenceListDrawer(serializedObject.FindProperty("m_pools"));

            m_listPoolsSelection = new ReorderableListSelectionDrawerByPath(m_listPools, "m_asset")
            {
                Drawer = { DisplayTitlebar = true }
            };

            m_listPools.Enable();
            m_listPoolsSelection.Enable();
        }

        private void OnDisable()
        {
            m_listPools.Disable();
            m_listPoolsSelection.Disable();
        }

        public override void OnInspectorGUI()
        {
            using (new SerializedObjectUpdateScope(serializedObject))
            {
                EditorIMGUIUtility.DrawScriptProperty(serializedObject);

                m_listPools.DrawGUILayout();
                m_listPoolsSelection.DrawGUILayout();
            }
        }
    }
}
