#if UNITY_EDITOR
using System.IO;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

// [�Q�l]
//  kan�̃�����: Resources�ȊO����A�Z�b�g�����[�h����֗��N���X https://kan-kikuchi.hatenablog.com/entry/NonResources

namespace nitou.EditorShared {

    /// <summary>
    /// <see cref="AssetDatabase"/>�̃��b�p�[
    /// </summary>
    public static class NonResources {

        /// ----------------------------------------------------------------------------
        // Method (�P�̃��[�h)

        /// <summary>
        /// �t�@�C���̃A�Z�b�g�p�X(�g���q���܂߂�)�ƌ^��ݒ肵�AObject��ǂݍ��ށD
        /// </summary>
        public static T Load<T>(string path) where T : Object {
            return AssetDatabase.LoadAssetAtPath<T>(path);
        }

        /// <summary>
        /// �t�@�C���̃p�X(Assets����A�g���q���܂߂�)�ƌ^��ݒ肵�AObject��ǂݍ��ށD
        /// </summary>
        public static T Load<T>(string assetName, string relativePath) where T : Object {
            return AssetDatabase.LoadAssetAtPath<T>($"{relativePath}/{assetName}");
        }

        public static T Load<T>(string assetName, string relativePath, PackageFolderInfo packageInfo) where T : Object {
            string path = GetAssetPathInPackage(relativePath, assetName, packageInfo);
            return (path != null) ? AssetDatabase.LoadAssetAtPath<T>(path) : null;
        }


        /// ----------------------------------------------------------------------------
        // Method (�������[�h)

        /// <summary>
        /// �f�B���N�g���̃p�X(Assets����)�ƌ^��ݒ肵�AObject��ǂݍ��ށB���݂��Ȃ��ꍇ�͋��List��Ԃ�
        /// </summary>
        public static List<T> LoadAll<T>(string directoryPath) where T : Object {
            var assetList = new List<T>();

            // �w�肵���f�B���N�g���ɓ����Ă���S�t�@�C�����擾(�q�f�B���N�g�����܂�)
            string[] filePathArray = Directory.GetFiles(directoryPath, "*", SearchOption.AllDirectories);

            // �擾�����t�@�C���̒�����A�Z�b�g�������X�g�ɒǉ�����
            foreach (string filePath in filePathArray) {
                T asset = Load<T>(filePath);
                if (asset != null) {
                    assetList.Add(asset);
                }
            }

            return assetList;
        }

        /// <summary>
        /// �f�B���N�g���̃p�X(Assets����)��ݒ肵�AObject��ǂݍ��ށB���݂��Ȃ��ꍇ�͋��List��Ԃ�
        /// </summary>
        public static List<T> LoadAll<T>(string relativePath, PackageFolderInfo packageInfo) where T : Object {
            return LoadAll<T>(GetDirectoryPathInPackage(relativePath, packageInfo));
        }



        /// ----------------------------------------------------------------------------
        // Private Method

        /// <summary>
        /// 
        /// </summary>
        private static string GetAssetPathInPackage(string relativePath, string assetName, PackageFolderInfo packageInfo) {

            var fullRelativePath = $"{relativePath}/{assetName}";

            // �z�z��ł̃p�X
            var upmPath = $"Packages/{packageInfo.upmFolderName}/{fullRelativePath}";
            // �J���v���W�F�N�g���ł̃p�X
            var normalPath = $"Assets/{packageInfo.normalFolderName}/{fullRelativePath}";

            // 
            if (File.Exists(Path.GetFullPath(upmPath))) {
                return upmPath;
            }
            // 
            else if (File.Exists(Path.GetFullPath(normalPath))) {
                return normalPath;
            }
            // 
            else {
                Debug.LogError($"File not found in both UPM and normal paths: \n" +
                    $"  [{upmPath}] and \n" +
                    $"  [{normalPath}]");
                return null;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        private static string GetDirectoryPathInPackage(string relativePath, PackageFolderInfo packageInfo) {
            // �z�z��ł̃p�X
            var upmPath = $"Packages/{packageInfo.upmFolderName}/{relativePath}";
            // �J���v���W�F�N�g���ł̃p�X
            var normalPath = $"Assets/{packageInfo.normalFolderName}/{relativePath}";

            // 
            if (Directory.Exists(Path.GetFullPath(upmPath))) {
                return upmPath;
            }
            // 
            else if (Directory.Exists(Path.GetFullPath(normalPath))) {
                return normalPath;
            }
            // 
            else {
                Debug.LogError($"Directory not found in both UPM and normal paths: \n" +
                    $"  [{upmPath}] and \n" +
                    $"  [{normalPath}]");
                return null;
            }
        }

    }


    public struct PackageFolderInfo {
        
        public readonly string upmFolderName;
        public readonly string normalFolderName;

        public PackageFolderInfo(string upmFolderName = "com.nitou.nLib", string normalFolderName = "nLib") {
            this.upmFolderName = upmFolderName;
            this.normalFolderName = normalFolderName;
        }
    }
}

#endif