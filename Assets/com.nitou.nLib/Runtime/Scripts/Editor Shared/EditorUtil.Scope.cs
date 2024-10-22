#if UNITY_EDITOR
using UnityEngine;
using UnityEditor;

// [�Q�l]
//  qiita: Unity5��GUI�N���X�ɒǉ����ꂽScope�ɂ��� https://qiita.com/kyusyukeigo/items/4642ae85d6ff075acf31
//  hatena: EditorWindow�Ŏg����Scope�ꗗ https://hacchi-man.hatenablog.com/entry/2019/12/20/002444

namespace nitou.EditorShared {
    public static partial class EditorUtil {

        /// ----------------------------------------------------------------------------
        #region Color Scope

        /// <summary>
        /// GUI.color�ݒ���X�R�[�v�ŊǗ����邽�߂̃N���X
        /// </summary>
        public sealed class GUIColorScope : UnityEngine.GUI.Scope {

            private readonly Color _oldColor;

            /// <summary>
            /// �R���X�g���N�^
            /// </summary>
            public GUIColorScope(Color color) {
                _oldColor = UnityEngine.GUI.color;
                UnityEngine.GUI.color = color;
            }

            /// <summary>
            /// �I������
            /// </summary>
            protected override void CloseScope() {
                UnityEngine.GUI.color = _oldColor;
            }
        }


        /// <summary>
        /// GUI.backgroundColor��ݒ���X�R�[�v�ŊǗ����邽�߂̃N���X
        /// </summary>
        public sealed class GUIBackgroundColorScope : UnityEngine.GUI.Scope {

            private readonly Color _oldColor;

            /// <summary>
            /// �R���X�g���N�^
            /// </summary>
            public GUIBackgroundColorScope(Color color) {
                _oldColor = UnityEngine.GUI.backgroundColor;
                UnityEngine.GUI.backgroundColor = color;
            }

            /// <summary>
            /// �I������
            /// </summary>
            protected override void CloseScope() {
                UnityEngine.GUI.backgroundColor = _oldColor;
            }
        }


        /// <summary>
        /// GUI.backgroundColor��ݒ���X�R�[�v�ŊǗ����邽�߂̃N���X
        /// </summary>
        public sealed class GUIContentColorScope : UnityEngine.GUI.Scope {

            private readonly Color _oldColor;

            /// <summary>
            /// �R���X�g���N�^
            /// </summary>
            public GUIContentColorScope(Color color) {
                _oldColor = UnityEngine.GUI.contentColor;
                UnityEngine.GUI.contentColor = color;
            }

            /// <summary>
            /// �I������
            /// </summary>
            protected override void CloseScope() {
                UnityEngine.GUI.contentColor = _oldColor;
            }
        }
        #endregion


        /// ----------------------------------------------------------------------------
        #region Indent Scope

        /// <summary>
        /// �C���f���g�ݒ���X�R�[�v�ŊǗ����邽�߂̃N���X
        /// </summary>
        public sealed class IndentScope : UnityEngine.GUI.Scope {

            private readonly int _oldIndentLevel;

            /// <summary>
            /// �R���X�g���N�^
            /// </summary>
            public IndentScope() {
                _oldIndentLevel = EditorGUI.indentLevel;
                EditorGUI.indentLevel++;    // ���C���f���g���ЂƂグ��
            }

            /// <summary>
            /// �R���X�g���N�^
            /// </summary>
            public IndentScope(int indentLevel) {
                _oldIndentLevel = EditorGUI.indentLevel;
                EditorGUI.indentLevel = indentLevel;
            }

            /// <summary>
            /// �I������
            /// </summary>
            protected override void CloseScope() {
                EditorGUI.indentLevel = _oldIndentLevel;
            }
        }

        #endregion


        /// ----------------------------------------------------------------------------
        #region Condition

        /// <summary>
        /// 
        /// </summary>
        public sealed class EnableScope : UnityEngine.GUI.Scope {
            private readonly bool _oldEnabled;

            /// <summary>
            /// �R���X�g���N�^
            /// </summary>
            public EnableScope(bool enabled) {
                _oldEnabled = UnityEngine.GUI.enabled;
                UnityEngine.GUI.enabled = enabled;
            }

            /// <summary>
            /// �I������
            /// </summary>
            protected override void CloseScope() {
                UnityEngine.GUI.enabled = _oldEnabled;
            }
        }

        #endregion


        /// ----------------------------------------------------------------------------
        #region Misc

        /// <summary>
        /// �����ϊ��s���ݒ肷��X�R�[�v
        /// </summary>
        public class RotateScope : UnityEngine.GUI.Scope {

            private readonly Matrix4x4 _oldMatrix;

            public RotateScope(float angle, Vector2 pivotPoint) {
                _oldMatrix = UnityEngine.GUI.matrix;
                GUIUtility.RotateAroundPivot(angle, pivotPoint);
            }

            protected override void CloseScope() {
                UnityEngine.GUI.matrix = _oldMatrix;
            }
        }
        #endregion
    }
}
#endif