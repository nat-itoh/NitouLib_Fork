using UnityEditor;
using UnityEngine;
using nitou.Tools.ProjectWindow;

namespace nitou.Tools.ProjectWindow {


    public class ProjectSetupWindow : EditorWindow {

        private ScriptsDirectoryFlags _scriptsFlags = new ();

        private string _parentFolderName = "OutGame";
        private string _parentFolderPath = "Assets/Scripts";


        [MenuItem(ToolBarMenu.Prefix.Develop + "Project Setup")]
        public static void ShowWindow() {
            GetWindow<ProjectSetupWindow>("Project Setup");
        }

        private void OnGUI() {

            EditorGUILayout.LabelField("Parent Folder Settings", EditorStyles.boldLabel);
            _parentFolderName = EditorGUILayout.TextField("Parent Folder Name", _parentFolderName);
            _parentFolderPath = EditorGUILayout.TextField("Parent Folder Path", _parentFolderPath);

            EditorGUILayout.Space();

            EditorGUILayout.LabelField("Scripts Directory Flags", EditorStyles.boldLabel);

            // IFlagContainer �̊g�����\�b�h���g�p���ē��I�Ƀt�B�[���h��\��
            DrawFlagFields(_scriptsFlags);

            if (GUILayout.Button("Create Folders")) {
                ProjectFolderCreater.CreateFolders("Assets/Scripts", "OutGame", _scriptsFlags);
            }
        }




        public static void DrawFlagFields(IFlagContainer target) {

            foreach (var flagName in target.GetFlagNames()) {
                bool value = target.GetFlagValue(flagName);
                bool newValue = EditorGUILayout.Toggle(ObjectNames.NicifyVariableName(flagName), value);
                if (newValue != value) {
                    target.SetFlagValue(flagName, newValue);
                }
            }
        }
    }

}