#if UNITY_EDITOR
using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEditor;
using UnityEngine;

namespace nitou.EditorShared {
    using nitou.Shared;

    /// <summary>
    /// <see cref="Resources"/>���C�N�ɔ�Resources�t�H���_�̃A�Z�b�g��ǂݍ��ނ��߂̃N���X�i��AssetDatabase�̃��b�p�[�j
    /// </summary>
    public class AssetsLoader {

        /// ----------------------------------------------------------------------------
        #region Public Method (�P�̃��[�h)

        /// <summary>
        /// �t�@�C���̃A�Z�b�g�p�X(�g���q���܂߂�)�ƌ^��ݒ肵�AObject��ǂݍ��ށD
        /// </summary>
        public static T Load<T>(AssetPath assetPath)
            where T : Object {
            return AssetDatabase.LoadAssetAtPath<T>(assetPath.ToString());
        }

        /// <summary>
        /// �t�@�C���̃A�Z�b�g�p�X(�g���q���܂߂�)�ƌ^��ݒ肵�AObject��ǂݍ��ށD
        /// </summary>
        public static Object Load(AssetPath assetPath) {
            return Load<Object>(assetPath);
        }

        /// <summary>
        /// �t�@�C���̃A�Z�b�g�p�X(�g���q���܂߂�)�ƌ^��ݒ肵�AObject��ǂݍ��ށD
        /// </summary>
        public static T Load<T>(PackageDirectoryPath packagePath, string relativePath, string fileName)
            where T : Object {
            var path = PathUtil.Combine(packagePath.ToProjectPath(), relativePath, fileName);
            return AssetDatabase.LoadAssetAtPath<T>(path);
        }

        #endregion


        /// ----------------------------------------------------------------------------
        #region Public Method (�������[�h)

        /// <summary>
        /// �f�B���N�g���̃p�X(Assets����)�ƌ^��ݒ肵�AObject��ǂݍ��ށD���݂��Ȃ��ꍇ�͋��List��Ԃ��D
        /// </summary>
        public static List<T> LoadAll<T>(AssetPath directoryPath) where T : Object {

            if (!directoryPath.IsDirectory()) {
                Debug_.LogWarning($"The specified directory ({directoryPath}) does not exist.");
                return new List<T>();
            }

            return LoadAll_Internal<T>(directoryPath.ToProjectPath());
        }

        /// <summary>
        /// �f�B���N�g���̃p�X(Assets����)�ƌ^��ݒ肵�AObject��ǂݍ��ށD���݂��Ȃ��ꍇ�͋��List��Ԃ��D
        /// </summary>
        public static List<Object> LoadAll(AssetPath directoryPath) {
            return LoadAll<Object>(directoryPath);
        }

        public static List<T> LoadAll<T>(PackageDirectoryPath packagePath, string relativePath) where T : Object {

            var path = PathUtil.Combine(packagePath.ToProjectPath(), relativePath);
            return LoadAll_Internal<T>( path);
        }

        #endregion


        /// ----------------------------------------------------------------------------
        #region Private Method

        public static T Load<T>(string assetPath) where T : Object {
            return AssetDatabase.LoadAssetAtPath<T>(assetPath.ToString());
        }

        private static List<T> LoadAll_Internal<T>(string directoryPath) where T : Object {

            // �w�肵���f�B���N�g���ɓ����Ă���S�t�@�C�����擾(�q�f�B���N�g�����܂�)
            var filePaths = Directory.EnumerateFiles(directoryPath, "*", SearchOption.AllDirectories);

            // �擾�����t�@�C���̒�����A�Z�b�g�������X�g�ɒǉ�����
            var assetList = new List<T>();
            foreach (string filePath in filePaths) {
                T asset = Load<T>(AssetPath.FromAssetPath(filePath));
                assetList.AddIfNotNull(asset);
            }
            return assetList;
        }

        #endregion
    }
}
#endif