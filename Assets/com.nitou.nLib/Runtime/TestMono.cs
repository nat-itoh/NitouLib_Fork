using UnityEngine;
using UnityEditor;

namespace nitou {

    public enum TestType {
        A, B, C
    }


    public class TestMono : MonoBehaviour {
        public TestType testType;
    }


    [CustomEditor(typeof(TestMono))]
    public class TestScriptEditor : Editor {
        public override void OnInspectorGUI() {
            TestMono script = (TestMono)target;

            // ���݂�GUI�J���[��ۑ�
            Color defaultColor = GUI.backgroundColor;

            EditorGUILayout.BeginHorizontal();

            // A�{�^��
            GUI.backgroundColor = (script.testType == TestType.A) ? Color.green : defaultColor;
            if (GUILayout.Button("A")) {
                script.testType = TestType.A;
            }

            // B�{�^��
            GUI.backgroundColor = (script.testType == TestType.B) ? Color.green : defaultColor;
            if (GUILayout.Button("B")) {
                script.testType = TestType.B;
            }

            // C�{�^��
            GUI.backgroundColor = (script.testType == TestType.C) ? Color.green : defaultColor;
            if (GUILayout.Button("C")) {
                script.testType = TestType.C;
            }

            // GUI�J���[�����ɖ߂�
            GUI.backgroundColor = defaultColor;

            EditorGUILayout.EndHorizontal();

            // �ύX���������ꍇ�ɃV���A���C�Y���ꂽ�I�u�W�F�N�g���}�[�N
            if (GUI.changed) {
                EditorUtility.SetDirty(target);
            }
        }
    }

}
