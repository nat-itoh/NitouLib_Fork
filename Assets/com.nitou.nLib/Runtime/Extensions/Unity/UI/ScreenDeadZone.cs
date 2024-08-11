using UnityEngine;

namespace nitou {

    /// <summary>
    /// ��ʂ̎��́i�X�N���[���̃p�f�B���O�̈�j�̃}�E�X��^�b�`�����h�~���邽�߂̍\����
    /// </summary>
    [System.Serializable]
    public struct ScreenDeadZone {

        // �㕔�̃p�f�B���O���i��ʍ����ɑ΂��銄���j
        [Range(0f, 1f)] public float top;

        // �����̃p�f�B���O���i��ʍ����ɑ΂��銄���j
        [Range(0f, 1f)] public float bottom;

        // �����̃p�f�B���O���i��ʕ��ɑ΂��銄���j
        [Range(0f, 1f)] public float left;

        // �E���̃p�f�B���O���i��ʕ��ɑ΂��銄���j
        [Range(0f, 1f)] public float right;

        public float XMin => left * Screen.width;
        public float YMin => bottom * Screen.height;


        public Rect CalculateSafeZone() {

            var pos = new Vector2(XMin, YMin);
            var size = new Vector2(
                Screen.width - (1 - (left + right)),
                Screen.height - (1 - (top + bottom)));


            return new Rect(pos, size);
        }

        /// <summary>
        /// �}�E�X���W���f�b�h�]�[�������ǂ���
        /// </summary>
        public bool IsMouseInDeadZone() {
            Vector2 mousePosition = Input.mousePosition;
            Rect safeZone = CalculateSafeZone();

            // Invert the Y coordinate for mouse position to align with Unity's GUI Rect coordinate system
            mousePosition.y = Screen.height - mousePosition.y;

            return !safeZone.Contains(mousePosition);
        }

    }
}



#if UNITY_EDITOR
namespace nitou.EditorScripts {
    using UnityEditor;

    /*

    [CustomPropertyDrawer(typeof(ScreenDeadZone))]
    public class ScreenDeadZoneDrawer : PropertyDrawer {

        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label) {
            // �e�v���p�e�B�iScreenDeadZone�j�̃��x����\��
            EditorGUI.PrefixLabel(position, label);

            // �C���f���g�̐ݒ�
            EditorGUI.indentLevel++;

            // Rect�v���p�e�B���擾
            SerializedProperty percentageProp = property.FindPropertyRelative("percentage");

            // �e�t�B�[���h��\��
            Rect rectField = new Rect(position.x, position.y + EditorGUIUtility.singleLineHeight, position.width, EditorGUIUtility.singleLineHeight);

            // xMin, yMin, width, height �����ꂼ��0.0�`1.0�͈͓̔��ŃX���C�_�[�\��
            EditorGUI.Slider(new Rect(rectField.x, rectField.y, rectField.width, rectField.height), percentageProp.FindPropertyRelative("x"), 0.0f, 1.0f, "X Min");
            rectField.y += EditorGUIUtility.singleLineHeight + EditorGUIUtility.standardVerticalSpacing;
            EditorGUI.Slider(new Rect(rectField.x, rectField.y, rectField.width, rectField.height), percentageProp.FindPropertyRelative("y"), 0.0f, 1.0f, "Y Min");
            rectField.y += EditorGUIUtility.singleLineHeight + EditorGUIUtility.standardVerticalSpacing;
            EditorGUI.Slider(new Rect(rectField.x, rectField.y, rectField.width, rectField.height), percentageProp.FindPropertyRelative("width"), 0.0f, 1.0f, "Width");
            rectField.y += EditorGUIUtility.singleLineHeight + EditorGUIUtility.standardVerticalSpacing;
            EditorGUI.Slider(new Rect(rectField.x, rectField.y, rectField.width, rectField.height), percentageProp.FindPropertyRelative("height"), 0.0f, 1.0f, "Height");

            // �C���f���g��߂�
            EditorGUI.indentLevel--;
        }

        public override float GetPropertyHeight(SerializedProperty property, GUIContent label) {
            // 4�̃X���C�_�[�ƕW���̊Ԋu���̍������v�Z
            return EditorGUIUtility.singleLineHeight * 5 + EditorGUIUtility.standardVerticalSpacing * 4;
        }
    }

    */
}
#endif