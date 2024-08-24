using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

// [�Q�l]
//  qiita: C#(Unity)�ł̃t�@�C���p�X�̎擾 https://qiita.com/oishihiroaki/items/1a082f3bb32f2e3d88a0
//  �͂Ȃ���: ��΃p�X��Assets/~�ɕϊ����� https://www.hanachiru-blog.com/entry/2018/10/12/204022
//  _ : �t���p�X��Assets�p�X�ɕϊ�������@ https://mizutanikirin.net/unity-assetspath

namespace nitou {

    /// <summary>
    /// �p�X�擾�Ɋւ���ėp���\�b�h�W
    /// </summary>
    public static class PathUtil {

        /// --------------------------------------------------------------------
        // �擾

        /// <summary>
        /// �t�@�C���p�X����t�@�C�������擾����
        /// </summary>
        public static string GetFileName(string filePath) =>
            System.IO.Path.GetFileName(filePath);

        /// <summary>
        /// �t�@�C���p�X����g���q���擾����
        /// </summary>
        public static string GetExtension(string filePath) =>
            System.IO.Path.GetExtension(filePath);

        /// <summary>
        /// �w�肵���t�H���_���̑S�t�@�C���p�X���擾����
        /// </summary>
        public static string[] GetFilesInFolder(string folderPath) {
            return System.IO.Directory.GetFiles(folderPath, "*");
        }


        /// --------------------------------------------------------------------
        #region �p�X�̕ϊ��istring�g�����\�b�h�j

        /// <summary>
        /// �t���p�X���A�Z�b�g�ȉ��p�X(Asset/..)�ɕϊ�����
        /// </summary>
        public static string ToAssetsPath(this string fullPath) {
            // "Assets/"�ʒu���擾
            int startIndex = fullPath.IndexOf("Assets/", System.StringComparison.Ordinal);
            if (startIndex == -1) {
                startIndex = fullPath.IndexOf("Assets\\", System.StringComparison.Ordinal);
            }

            // ���܂܂�Ȃ��ꍇ�́C�󕶎���Ԃ�
            if (startIndex == -1) return "";

            // ���H��p�X��Ԃ�
            string assetPath = fullPath.Substring(startIndex);
            return assetPath;
        }

        /// <summary>
        /// ������̔z��� 1 �̃p�X�Ɍ������܂�
        /// </summary>
        public static string Combine(params string[] paths) {
            return paths
                .Aggregate((a, b) => Path.Combine(a, b))
                .Replace("\\", "/");
        }

        #endregion

        /// --------------------------------------------------------------------
        // Private Method

        private static string GetParentDirectory(string filepath, int n = 1) {
            string dir = filepath;
            for (int i = 0; i < n; i++) {
                dir = System.IO.Directory.GetParent(dir).FullName;
            }
            return dir.ToAssetsPath();
        }


        /// --------------------------------------------------------------------
#if UNITY_EDITOR

        /// <summary>
        /// �I�𒆂̃A�Z�b�g�̃p�X���擾����
        /// </summary>
        public static string GetSelectedAssetPath() =>
            AssetDatabase.GetAssetPath(Selection.activeInstanceID);


        /// --------------------------------------------------------------------
        #region �p�X�̕ϊ��istring�g�����\�b�h�j

        /// <summary>
        /// �A�Z�b�g�p�X���擾����
        /// </summary>
        public static string GetAssetPath(this ScriptableObject scriptableObject) {
            var mono = MonoScript.FromScriptableObject(scriptableObject);
            return AssetDatabase.GetAssetPath(mono).Replace("\\", "/");
        }

        /// <summary>
        /// �A�Z�b�g�̐e�t�H���_�p�X���擾����
        /// </summary>
        public static string GetAssetParentFolderPath(this ScriptableObject scriptableObject, int n = 1) {
            var filePath = scriptableObject.GetAssetPath();

            return GetParentDirectory(filePath, n);
        }
        #endregion


        /// --------------------------------------------------------------------
        // 

        /// <summary>
        /// �t�H���_�̃A�Z�b�g�p�X���������Ď擾����
        /// </summary>
        public static string GetFolderPath(string folderName, string parentFolderName) {

            // ���S�t�@�C����������������Ȃ̂ɒ���
            string[] guids = AssetDatabase.FindAssets(folderName);
            foreach (var guid in guids) {

                // �Ώۃt�H���_���
                var folderPath = AssetDatabase.GUIDToAssetPath(guid);

                // �e�t�H���_���
                var parentFolderPath = System.IO.Path.GetDirectoryName(folderPath);
                var parentFolder = System.IO.Path.GetFileName(parentFolderPath);

                // �e�t�H���_�܂ň�v���Ă���Ȃ�C�m��Ƃ���
                if (parentFolder == parentFolderName) {
                    return folderPath;
                }
            }

            return "";
        }

#endif





    }

}