#if UNITY_EDITOR
using UnityEngine;
using UnityEditor;
using System;

// Rererence: https://www.foundations.unity.com/fundamentals/color-palette

namespace nitou.EditorShared {

    // [TODO] ���������̂Q�L�[Dictionary�𐮔������� (2024.08.01)

    /// <summary>
    /// Unity�G�f�B�^�Ŏg�p����Ă���J���[�W
    /// </summary>
    public static class EditorColors {

        /// ----------------------------------------------------------------------------
        // Window Colors

        /// <summary>
        /// �w�i�F
        /// </summary>
        public static Color DefaultBackground =>
            GetColor(EditorGUIUtility.isProSkin ? "#282828" : "#A5A5A5");

        /// <summary>
        /// �w�i�F�i��A�N�e�B�u�n�C���C�g�j
        /// </summary>
        public static Color HighlightBackgroundInactive =>
            GetColor(EditorGUIUtility.isProSkin ? "#4D4D4D" : "#AEAEAE");

        /// <summary>
        /// �w�i�F�i�n�C���C�g�j
        /// </summary>
        public static Color HighlightBackground =>
            GetColor(EditorGUIUtility.isProSkin ? "#2C5D87" : "#3A72B0");

        /// <summary>
        /// 
        /// </summary>
        public static Color WindowBackground =>
            GetColor(EditorGUIUtility.isProSkin ? "#383838" : "#C8C8C8");

        /// <summary>
        /// 
        /// </summary>
        public static Color InspectorTitlebarBorder =>
            GetColor(EditorGUIUtility.isProSkin ? "#1A1A1A" : "#7F7F7F");


        /// ----------------------------------------------------------------------------
        // Button Colors

        /// <summary>
        /// �{�^���w�i�F
        /// </summary>
        public static Color ButtonBackground =>
            GetColor(EditorGUIUtility.isProSkin ? "#585858" : "#E4E4E4");

        /// <summary>
        /// �{�^���w�i�F�i�z�o�[�j
        /// </summary>
        public static Color ButtonBackgroundHover =>
            GetColor(EditorGUIUtility.isProSkin ? "#676767" : "#ECECEC");

        /// <summary>
        /// �{�^���w�i�F�i�N���b�N�j
        /// </summary>
        public static Color ButtonBackgroundHoverPressedr =>
            GetColor(EditorGUIUtility.isProSkin ? "#4F657F" : "#B0D2FC");


        /// ----------------------------------------------------------------------------
        // Text Colors

        /// <summary>
        /// �e�L�X�g�F
        /// </summary>
        public static Color DefaultText =>
            GetColor(EditorGUIUtility.isProSkin ? "#D2D2D2" : "#090909");

        /// <summary>
        /// �e�L�X�g�F�i�G���[�j
        /// </summary>
        public static Color ErrorText =>
            GetColor(EditorGUIUtility.isProSkin ? "#D32222" : "#5A0000");

        /// <summary>
        /// �e�L�X�g�F�i�x���j
        /// </summary>
        public static Color WarningText =>
            GetColor(EditorGUIUtility.isProSkin ? "#F4BC02" : "#333308");

        /// <summary>
        /// �e�L�X�g�F�i�����N�j
        /// </summary>
        public static Color LinkText =>
            GetColor(EditorGUIUtility.isProSkin ? "#4C7EFF" : "#4C7EFF");





        /// ----------------------------------------------------------------------------
        // Private Method

        /// <summary>
        /// HTML����RGB�J���[�ւ̕ϊ�
        /// </summary>
        private static Color GetColor(string htmlColor) {
            if (!ColorUtility.TryParseHtmlString(htmlColor, out var color))
                throw new ArgumentException();

            return color;
        }
    }
}
#endif