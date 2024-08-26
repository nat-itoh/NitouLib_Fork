#if UNITY_EDITOR
using System.Collections.Generic;
using System.IO;
using UnityEditor;
using UnityEngine;

namespace nitou.EditorShared{

    public class AssetsLoader{

        /// ----------------------------------------------------------------------------
        // Method (�P�̃��[�h)

        /// <summary>
        /// �t�@�C���̃A�Z�b�g�p�X(�g���q���܂߂�)�ƌ^��ݒ肵�AObject��ǂݍ��ށD
        /// </summary>
        public static T Load<T>(AssetPath assetPath) where T : Object {
            return AssetDatabase.LoadAssetAtPath<T>(assetPath.ToString());
        }


        /// ----------------------------------------------------------------------------
        // Method (�������[�h)

        /// <summary>
        /// �f�B���N�g���̃p�X(Assets����)�ƌ^��ݒ肵�AObject��ǂݍ��ށB���݂��Ȃ��ꍇ�͋��List��Ԃ�
        /// </summary>
        public static List<T> LoadAll<T>(AssetPath directoryPath) where T : Object {
            var assetList = new List<T>();

            if (!directoryPath.IsDirectory()) {
                Debug_.LogWarning("�w�肵���f�B���N�g���͑��݂��܂���D");
                return assetList;
            }

            // �w�肵���f�B���N�g���ɓ����Ă���S�t�@�C�����擾(�q�f�B���N�g�����܂�)
            //string[] filePathArray = Directory.GetFiles(directoryPath, "*", SearchOption.AllDirectories);

            //// �擾�����t�@�C���̒�����A�Z�b�g�������X�g�ɒǉ�����
            //foreach (string filePath in filePathArray) {
            //    T asset = Load<T>(filePath);
            //    if (asset != null) {
            //        assetList.Add(asset);
            //    }
            //}

            return assetList;
        }
    }
}
#endif