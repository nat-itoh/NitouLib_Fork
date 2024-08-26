#if UNITY_EDITOR
using UnityEngine;
using UnityEditor;

// [�Q�l]
//  LIGHT11: �G�f�B�^�Ńf�[�^��ۑ�����ꏊ�ƕۑ����@�܂Ƃ�

namespace nitou.ConfigManagement{

    public class ConfigUtilWindow : EditorWindow{

        private string savePath;

        [MenuItem("Tools/Data Save Location")]
        public static void Open() {
            GetWindow<ConfigUtilWindow>("Data Save Location");
        }

        private void OnEnable() {
            // �ۑ���̏����p�X���擾���܂��i��: Application.persistentDataPath�j
            savePath = Application.persistentDataPath;
        }

        private void OnGUI() {

            DrawDataPath("persistentDataPath", Application.persistentDataPath);
            DrawDataPath("unityPreferencesFolder", UnityEditorInternal.InternalEditorUtility.unityPreferencesFolder);
        }


        /// <summary>
        /// 
        /// </summary>
        private void DrawDataPath(string label, string dataPath) {
            using var scope = new EditorGUILayout.HorizontalScope();

            // ���݂̕ۑ��p�X��\��
            EditorGUILayout.LabelField($"{label}:", dataPath);

            //EditorGUILayout.Space();

            // �t�H���_���J���{�^��
            if (GUILayout.Button("Open")) {
                EditorUtility.RevealInFinder(savePath);
            }


        }

    }
}
# endif