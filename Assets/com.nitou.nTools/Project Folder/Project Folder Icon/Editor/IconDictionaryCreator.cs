#if UNITY_EDITOR
using System.Collections.Generic;
using System.Linq;
using System.IO;
using UnityEngine;
using UnityEditor;

// [�Q�l]
//  Docswell: AssetPostprocessor���S�ɗ������� https://www.docswell.com/s/henjiganai/5714J5-AssetPostprocessor#p8
//  qiita: �G�f�B�^�[�g���ŁA�ǂݍ��ރA�Z�b�g�̃p�X���n�[�h�R�[�h���Ȃ����߂� https://qiita.com/tsukimi_neko/items/3d57e3808acb88e11c39
//  �@�� �i��AssetPostprocessor��Unity.Object�H��e�Ɏ����Ȃ����߁C�V���A���C�Y�ΏۊO�݂����j

namespace nitou.Tools.ProjectWindow {
    using nitou.Tools.Shared;
    using nitou.EditorShared;

    /// <summary>
    /// �t�H���_�A�C�R���摜���Ǘ�����Dictionay�𐶐�����
    /// </summary>
    internal class IconDictionaryCreator : AssetPostprocessor {

        // ���\�[�X���
        private const string relativeFolderPath = "Project Folder/Project Folder Icon/Icons";
        internal static Dictionary<string, Texture> _iconDictionary;


        /// ----------------------------------------------------------------------------
        // Internal Method

        /// <summary>
        /// Dictionary�̐���
        /// </summary>
        internal static void BuildDictionary() {

            var texs = AssetsLoader.LoadAll<Texture2D>(PackageInfo.packagePath, relativeFolderPath);
            //var texs = NonResources.LoadAll<Texture2D>(relativeFolderPath, NitouTools.pacakageInfo);
            _iconDictionary = texs.ToDictionary(texture => texture.name, texture => (Texture)texture);
        }

        /// <summary>
        /// �w�肵���L�[�ɑΉ�����A�C�R���摜���擾����
        /// </summary>
        internal static (bool isExist, Texture texture) GetIconTexture(string fileNameKey) {

            // �t�@�C���������S��v�̏ꍇ
            if (_iconDictionary.ContainsKey(fileNameKey)) {
                return (true, _iconDictionary[fileNameKey]);
            }

            // ���K�\���Ή� (���Ƃ肠�������ߑł��̎���)
            if (fileNameKey[0] == '_' && fileNameKey.Length > 1) {
                fileNameKey = fileNameKey.Substring(1);
                if (_iconDictionary.ContainsKey(fileNameKey))
                    return (true, _iconDictionary[fileNameKey]);
            }

            return (false, null);
        }
    }
}
#endif