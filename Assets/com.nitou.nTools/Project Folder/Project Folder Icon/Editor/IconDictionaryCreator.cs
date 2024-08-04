#if UNITY_EDITOR
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEditor;

// [�Q�l]
//  Docswell: AssetPostprocessor���S�ɗ������� https://www.docswell.com/s/henjiganai/5714J5-AssetPostprocessor#p8
//  qiita: �G�f�B�^�[�g���ŁA�ǂݍ��ރA�Z�b�g�̃p�X���n�[�h�R�[�h���Ȃ����߂� https://qiita.com/tsukimi_neko/items/3d57e3808acb88e11c39
//  �@�� �i��AssetPostprocessor��Unity.Object�H��e�Ɏ����Ȃ����߁C�V���A���C�Y�ΏۊO�݂����j

namespace nitou.Tools.ProjectWindow {

    /// <summary>
    /// �t�H���_�A�C�R���摜���Ǘ�����Dictionay�𐶐�����
    /// </summary>
    internal class IconDictionaryCreator : AssetPostprocessor {

        // ���\�[�X���
        private const string AssetsPath = "com.nitou.nTools/Project Folder/Project Folder Icon/Icons";
        private const string PackagePath = "Packages/" + AssetsPath;
        internal static Dictionary<string, Texture> IconDictionary;


        /// ----------------------------------------------------------------------------
        // Internal Method


        /// <summary>
        /// Dictionary�̐���
        /// </summary>
        internal static void BuildDictionary() {

            // [NOTE]
            // ���J������Assets�����C�z�z���Packages�����ɑ��݂���p�b�P�[�W�����݂���
            //string iconFolderPath = DetermineIconPath();
            //if (string.IsNullOrEmpty(iconFolderPath)) {
            //    Debug.LogError("Icon folder not found.");
            //    return;
            //}


            var dictionary = new Dictionary<string, Texture>();

            //FileInfo[] info = new DirectoryInfo(iconFolderPath).GetFiles("*.png");
            //foreach (FileInfo f in info) {
            //    var texture = (Texture)AssetDatabase.LoadAssetAtPath(GetRelativePath(iconFolderPath, f.FullName), typeof(Texture2D));
            //    dictionary.Add(Path.GetFileNameWithoutExtension(f.Name), texture);
            //}
            //IconDictionary = dictionary;


            var dir = new DirectoryInfo(Application.dataPath + "/" + AssetsPath);
            FileInfo[] info = dir.GetFiles("*.png");
            foreach (FileInfo f in info) {
                var texture = (Texture)AssetDatabase.LoadAssetAtPath($"Assets/{AssetsPath}/{f.Name}", typeof(Texture2D));
                dictionary.Add(Path.GetFileNameWithoutExtension(f.Name), texture);
            }

            IconDictionary = dictionary;
        }

        /*

        /// <summary>
        /// �t���p�X���瑊�΃p�X���擾����
        /// </summary>
        private static string GetRelativePath(string rootPath, string fullPath) {
            if (fullPath.StartsWith(rootPath)) {
                return "Assets" + fullPath.Substring(Application.dataPath.Length);
            }
            return fullPath;
        }

        /// <summary>
        /// �A�C�R���̃p�X�����肷��
        /// </summary>
        private static string DetermineIconPath() {
            // Assets�t�H���_���̃p�X���m�F
            string assetsFullPath = Path.Combine(Application.dataPath, AssetsPath);
            if (Directory.Exists(assetsFullPath)) {
                return assetsFullPath;
            }

            // Packages�t�H���_���̃p�X���m�F
            string packageFullPath = Path.Combine(Application.dataPath.Replace("Assets", ""), PackagePath);
            if (Directory.Exists(packageFullPath)) {
                return packageFullPath;
            }

            return string.Empty;
        }

        */



        /// <summary>
        /// �w�肵���L�[�ɑΉ�����A�C�R���摜���擾����
        /// </summary>
        public static (bool isExist, Texture texture) GetIconTexture(string fileNameKey) {

            // �t�@�C���������S��v�̏ꍇ
            if (IconDictionary.ContainsKey(fileNameKey)) {
                return (true, IconDictionary[fileNameKey]);
            }

            // ���K�\���Ή� (���Ƃ肠�������ߑł��̎���)
            if (fileNameKey[0] == '_' && fileNameKey.Length > 1) {
                fileNameKey = fileNameKey.Substring(1);
                if (IconDictionary.ContainsKey(fileNameKey))
                    return (true, IconDictionary[fileNameKey]);
            }

            return (false, null);
        }


        /// ----------------------------------------------------------------------------
        // Private Method

        /// <summary>
        /// �A�Z�b�g���C���|�[�g������̏���
        /// </summary>
        private static void OnPostprocessAllAssets(string[] importedAssets, string[] deletedAssets, string[] movedAssets, string[] movedFromAssetPaths) {
            if (!ContainsIconAsset(importedAssets) &&
                !ContainsIconAsset(deletedAssets) &&
                !ContainsIconAsset(movedAssets) &&
                !ContainsIconAsset(movedFromAssetPaths)) {
                return;
            }

            BuildDictionary();
        }

        /// <summary>
        /// �t�@�C�����̌���
        /// </summary>
        private static bool ContainsIconAsset(string[] assets) {
            foreach (string str in assets) {
                if (ReplaceSeparatorChar(Path.GetDirectoryName(str)) == "Assets/" + AssetsPath) {
                    return true;
                }
            }
            return false;
        }

        private static string ReplaceSeparatorChar(string path) {
            return path.Replace("\\", "/");
        }
    }
}
#endif