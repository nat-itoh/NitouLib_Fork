using System.Linq;
using UnityEngine;
#if UNITY_EDITOR
using UnityEditor;
#endif

// [�Q�l]
//  LIGHT11 �����̃J�X�^��PropertyAttribute������PropertyDrawer������������Ƃ��̑Ή��� https://light11.hatenadiary.com/entry/2021/08/16/201543

namespace nitou.Inspector {

    public interface IAttributePropertyDrawer {
#if UNITY_EDITOR
        void OnGUI(Rect position, SerializedProperty property, GUIContent label);

        float GetPropertyHeight(SerializedProperty property, GUIContent label);
#endif
    }


    public abstract class MultiPropertyAttribute : PropertyAttribute {
        public MultiPropertyAttribute[] Attributes;
        public IAttributePropertyDrawer[] PropertyDrawers;

#if UNITY_EDITOR
        /// <summary>
        /// �v���p�e�B�`��̑O����
        /// </summary>
        public virtual void OnPreGUI(Rect position, SerializedProperty property) {}

        /// <summary>
        /// �v���p�e�B�`��̌㏈��
        /// </summary>
        public virtual void OnPostGUI(Rect position, SerializedProperty property, bool changed) {}

        // [NOTE] �A�g���r���[�g�̂�����ł�false�������炻��GUI�͔�\���ɂȂ�
        public virtual bool IsVisible(SerializedProperty property) {
            return true;
        }
#endif
    }



#if UNITY_EDITOR
    [CustomPropertyDrawer(typeof(MultiPropertyAttribute), true)]
    public class MultiPropertyAttributeDrawer : PropertyDrawer {

        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label) {
            
            var attributes = GetAttributes();
            var propertyDrawers = GetPropertyDrawers();

            // ��\���̏ꍇ
            if (attributes.Any(attr => !attr.IsVisible(property))) {
                return;
            }

            // �O����
            foreach (var attr in attributes) {
                attr.OnPreGUI(position, property);
            }

            // �`��
            using (var ccs = new EditorGUI.ChangeCheckScope()) {
                if (propertyDrawers.Length == 0) {
                    EditorGUI.PropertyField(position, property, label);
                } else {
                    // ���ł�order���������̂�`��
                    propertyDrawers.Last().OnGUI(position, property, label);
                }

                // �㏈��
                foreach (var attr in attributes.Reverse()) {
                    attr.OnPostGUI(position, property, ccs.changed);
                }
            }
        }

        public override float GetPropertyHeight(SerializedProperty property, GUIContent label) {
            var attributes = GetAttributes();
            var propertyDrawers = GetPropertyDrawers();

            // ��\���̏ꍇ
            if (attributes.Any(attr => !attr.IsVisible(property))) {
                return -EditorGUIUtility.standardVerticalSpacing;
            }

            var height = propertyDrawers.Length == 0
                ? base.GetPropertyHeight(property, label)
                : propertyDrawers.Last().GetPropertyHeight(property, label);
            return height;
        }

        private MultiPropertyAttribute[] GetAttributes() {
            var attr = (MultiPropertyAttribute)attribute;

            if (attr.Attributes == null) {
                attr.Attributes = fieldInfo
                    .GetCustomAttributes(typeof(MultiPropertyAttribute), false)
                    .Cast<MultiPropertyAttribute>()
                    .OrderBy(x => x.order)
                    .ToArray();
            }

            return attr.Attributes;
        }

        private IAttributePropertyDrawer[] GetPropertyDrawers() {
            var attr = (MultiPropertyAttribute)attribute;

            if (attr.PropertyDrawers == null) {
                attr.PropertyDrawers = fieldInfo
                    .GetCustomAttributes(typeof(MultiPropertyAttribute), false)
                    .OfType<IAttributePropertyDrawer>()
                    .OrderBy(x => ((MultiPropertyAttribute)x).order)
                    .ToArray();
            }

            return attr.PropertyDrawers;
        }
    }
#endif

}