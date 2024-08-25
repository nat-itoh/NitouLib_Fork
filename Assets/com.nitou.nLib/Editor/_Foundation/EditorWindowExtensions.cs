#if UNITY_EDITOR
using UnityEngine;
using UnityEditor;

namespace nitou.EditorScripts{

    /// <summary>
    /// <see cref="EditorWindow"/>�̊�{�I�Ȋg�����\�b�h�W
    /// </summary>
    public static class EditorWindowExtensions{


        public static Rect GetPaddingRect(this EditorWindow self, float padding) {
            return self.position.Padding(padding);
        }



    }
}
#endif