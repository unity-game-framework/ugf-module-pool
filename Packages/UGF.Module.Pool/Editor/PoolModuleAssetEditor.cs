using UGF.EditorTools.Editor.IMGUI;
using UGF.EditorTools.Editor.IMGUI.AssetReferences;
using UGF.EditorTools.Editor.IMGUI.Scopes;
using UGF.Module.Pool.Runtime;
using UnityEditor;

namespace UGF.Module.Pool.Editor
{
    [CustomEditor(typeof(PoolModuleAsset), true)]
    internal class PoolModuleAssetEditor : UnityEditor.Editor
    {
        private SerializedProperty m_propertyUnloadOnUninitialize;
        private AssetReferenceListDrawer m_listLoaders;
        private ReorderableListSelectionDrawerByPath m_listLoadersSelection;
        private AssetReferenceListDrawer m_listPools;
        private ReorderableListSelectionDrawerByPath m_listPoolSelection;
        private ReorderableListDrawer m_listPreload;
        private ReorderableListDrawer m_listPreloadAsync;

        private void OnEnable()
        {
            m_propertyUnloadOnUninitialize = serializedObject.FindProperty("m_unloadOnUninitialize");
            m_listLoaders = new AssetReferenceListDrawer(serializedObject.FindProperty("m_loaders"));

            m_listLoadersSelection = new ReorderableListSelectionDrawerByPath(m_listLoaders, "m_asset")
            {
                Drawer =
                {
                    DisplayTitlebar = true
                }
            };

            m_listPools = new AssetReferenceListDrawer(serializedObject.FindProperty("m_pools"));

            m_listPoolSelection = new ReorderableListSelectionDrawerByPath(m_listPools, "m_asset")
            {
                Drawer =
                {
                    DisplayTitlebar = true
                }
            };

            m_listPreload = new ReorderableListDrawer(serializedObject.FindProperty("m_preload"));
            m_listPreloadAsync = new ReorderableListDrawer(serializedObject.FindProperty("m_preloadAsync"));

            m_listPools.Enable();
            m_listPoolSelection.Enable();
            m_listLoaders.Enable();
            m_listLoadersSelection.Enable();
            m_listPreload.Enable();
            m_listPreloadAsync.Enable();
        }

        private void OnDisable()
        {
            m_listLoaders.Disable();
            m_listLoadersSelection.Disable();
            m_listPools.Disable();
            m_listPoolSelection.Disable();
            m_listPreload.Disable();
            m_listPreloadAsync.Disable();
        }

        public override void OnInspectorGUI()
        {
            using (new SerializedObjectUpdateScope(serializedObject))
            {
                EditorIMGUIUtility.DrawScriptProperty(serializedObject);

                EditorGUILayout.PropertyField(m_propertyUnloadOnUninitialize);

                m_listLoaders.DrawGUILayout();
                m_listPools.DrawGUILayout();
                m_listPreload.DrawGUILayout();
                m_listPreloadAsync.DrawGUILayout();

                m_listLoadersSelection.DrawGUILayout();
                m_listPoolSelection.DrawGUILayout();
            }
        }
    }
}
