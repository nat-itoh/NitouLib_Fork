using System;
using System.Linq;
using UnityEditor;
using Sirenix.OdinInspector.Editor;

// [REF]
//  youtube: Data Manager - Scriptable Object Editor Window https://www.youtube.com/watch?v=1zu41Ku46xU&t=23s

namespace nitou.DataManagement {

    /// <summary>
    /// "ManageableDataAttribute"��t�^����ScriptableObject��ҏW����G�f�B�^�E�C���h�E
    /// </summary>
    internal class DataManager : OdinMenuEditorWindow {

        // �Ώۂ̌^���
        private static Type[] typesToDisplay = TypeCache.GetTypesWithAttribute<ManageableDataAttribute>()
            .OrderBy(m => m.Name)
            .ToArray();

        // �I�𒆂̌^
        private Type selectedType;


        /// ----------------------------------------------------------------------------
        // OdinEditor Method 

        /// <summary>
        /// �E�C���h�E�̕\��
        /// </summary>
        [MenuItem("Tools/Open/Data Manager")]
        private static void OpenEditor() => GetWindow<DataManager>();

        /// 
        protected override void OnImGUI() {

            if (typesToDisplay.Length!=0) {

                // �^�I���{�^�����X�g�̕\��
                if (GUIUtils.SelectButonList(ref selectedType, typesToDisplay))
                    this.ForceMenuTreeRebuild();    // ���{�^���������ꂽ��ĕ`��
            }

            base.OnImGUI();
        }



        /// <summary>
        /// ���j���[��ʂ̍\�z
        /// </summary>
        /// <returns></returns>
        protected override OdinMenuTree BuildMenuTree() {

            var tree = new OdinMenuTree();
            tree.AddAllAssetsAtPath(selectedType.Name, "Assets/", selectedType, true, true);
            return tree;
        }

    }
}