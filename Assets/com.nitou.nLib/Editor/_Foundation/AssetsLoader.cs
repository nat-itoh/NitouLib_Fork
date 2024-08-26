#if UNITY_EDITOR
using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEditor;
using UnityEngine;

namespace nitou.EditorShared{

    /// <summary>
    /// <see cref="Resources"/>���C�N�ɔ�Resources�t�H���_�̃A�Z�b�g��ǂݍ��ނ��߂̃N���X�i��AssetDatabase�̃��b�p�[�j
    /// </summary>
    public class AssetsLoader{

        /// ----------------------------------------------------------------------------
        #region Public Method (�P�̃��[�h)

        /// <summary>
        /// �t�@�C���̃A�Z�b�g�p�X(�g���q���܂߂�)�ƌ^��ݒ肵�AObject��ǂݍ��ށD
        /// </summary>
        public static T Load<T>(AssetPath assetPath) where T : Object {
            return AssetDatabase.LoadAssetAtPath<T>(assetPath.ToString());
        }

        /// <summary>
        /// �t�@�C���̃A�Z�b�g�p�X(�g���q���܂߂�)�ƌ^��ݒ肵�AObject��ǂݍ��ށD
        /// </summary>
        public static Object Load(AssetPath assetPath){
            return Load<Object>(assetPath);
        }
        #endregion


        /// ----------------------------------------------------------------------------
        #region Public Method (�������[�h)

        /// <summary>
        /// �f�B���N�g���̃p�X(Assets����)�ƌ^��ݒ肵�AObject��ǂݍ��ށD���݂��Ȃ��ꍇ�͋��List��Ԃ��D
        /// </summary>
        public static List<T> LoadAll<T>(AssetPath directoryPath) where T : Object {
            var assetList = new List<T>();

            if (!directoryPath.IsDirectory()) {
                Debug_.LogWarning($"The specified directory ({directoryPath}) does not exist.");
                return assetList;
            }

            // �w�肵���f�B���N�g���ɓ����Ă���S�t�@�C�����擾(�q�f�B���N�g�����܂�)
            // ��Directory.GetFiles�̓A�Z�b�g�p�X�Ŏw��\
            var filePaths = Directory.EnumerateFiles(directoryPath.ToAssetDatabasePath(), "*", SearchOption.AllDirectories);
            Debug_.ListLog(filePaths.ToList());

            // �擾�����t�@�C���̒�����A�Z�b�g�������X�g�ɒǉ�����
            foreach (string filePath in filePaths) {
                T asset = Load<T>(AssetPath.FromAssetPath(filePath));
                assetList.AddIfNotNull(asset);
            }
            Debug_.ListLog(assetList.Select(s => s.name).ToList());

            return assetList;
        }

        /// <summary>
        /// �f�B���N�g���̃p�X(Assets����)�ƌ^��ݒ肵�AObject��ǂݍ��ށD���݂��Ȃ��ꍇ�͋��List��Ԃ��D
        /// </summary>
        public static List<Object> LoadAll(AssetPath directoryPath) {
            return LoadAll<Object>(directoryPath);
        }
        #endregion
    }
}
#endif