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
        /// �t�@�C���̃p�X(Assets����A�g���q���܂߂�)�ƌ^��ݒ肵�AObject��ǂݍ��ށB���݂��Ȃ��ꍇ��Null��Ԃ�
        /// </summary>
        public static T Load<T>(string path) where T : Object {
            return AssetDatabase.LoadAssetAtPath<T>(path);
        }

        /// <summary>
        /// �t�@�C���̃p�X(Assets����A�g���q���܂߂�)��ݒ肵�AObject��ǂݍ��ށB���݂��Ȃ��ꍇ��Null��Ԃ�
        /// </summary>
        public static Object Load(string path) {
            return Load<Object>(path);
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
        public static List<Object> LoadAll(string directoryPath) {
            return LoadAll<Object>(directoryPath);
        }
    }

}

#endif