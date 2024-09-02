#if UNITY_EDITOR
using UnityEngine;
using UnityEditor;
using System.IO;

// [�Q�l]
//  qiita: ����g�������̃t�H���_�������N���b�N�ō쐬������@ https://qiita.com/OKsaiyowa/items/f7b2d331526e2a6938b1

namespace nitou.Tools.ProjectWindow {
    using nitou.EditorShared;

    /// <summary>
    /// �w��t�H���_�����ɋ�t�H���_�𐶐�����
    /// </summary>
    public static class BasicFolderCreater {


        /// ----------------------------------------------------------------------------
        // Public Method


        /// <summary>
        /// 
        /// </summary>
        [MenuItem(ToolBarMenu.Prefix.EditorTool + "Project Window/Create AssetData Folders")]
        public static void CreateAssetDataFolders() {

            string parentFolder = "Assets/AssetData";
            if (AssetDatabase.IsValidFolder(parentFolder)) {
                return;
            }

            // �A�Z�b�g�f�[�^�p�t�H���_
            CreateFolder(parentFolder, "Animations");
            CreateFolder(parentFolder, "Audios");
            CreateFolder(parentFolder, "Textures");
            CreateFolder(parentFolder, "Materials");
            CreateFolder(parentFolder, "Prefabs");
            CreateFolder(parentFolder, "Resources");
            CreateFolder(parentFolder, "Shaders");
        }

        /// <summary>
        /// 
        /// </summary>
        [MenuItem(ToolBarMenu.Prefix.EditorTool + "Project Window/Create Code Folders")]
        public static void CreateProjectCodeFolders() {

            string parentFolder = "Assets/_Project";
            if (AssetDatabase.IsValidFolder(parentFolder)) {
                return;
            }

            // �R�[�h�p�t�H���_
            CreateFolder(parentFolder, "_Composition");
            CreateFolder(parentFolder, "Entity");
            CreateFolder(parentFolder, "UseCase");
            CreateFolder(parentFolder, "Presentation");
            CreateFolder(parentFolder, "View");
            CreateFolder(parentFolder, "Foundation");
            CreateFolder(parentFolder, "LevelObjects");
            CreateFolder(parentFolder, "APIGateway");
        }

        /// <summary>
        /// �r���h�f�[�^�p�̃t�H���_�𐶐�����
        /// </summary>
        [MenuItem(ToolBarMenu.Prefix.EditorTool + "Project Window/Create Build Folder")]
        public static void CreateBuildFolder() {
            CreateFolder("Build/");
        }


        /// ----------------------------------------------------------------------------
        // Private Method

        private static void CreateFolder(string parentFolderPath, string folderName = "") {
            string fullPath = $"{parentFolderPath}/{folderName}";

            if (!Directory.Exists(fullPath)) {
                Directory.CreateDirectory(fullPath);
            }

            // �����t�H���_�X�V��Unity���֔��f���邽�ߎ��s
            AssetDatabase.ImportAsset(fullPath);
        }

    }

}
#endif