#if UNITY_EDITOR
using System.IO;
using UnityEditor;
using UnityEngine;

namespace nitou.Tools.PumlGenerator {
    using nitou.Tools.Shared;

    public static class PlantUmlGeneratorMenu {
        
        private const string MenuPath = "Assets/Create/PlantUML/";

        // ���\�[�X���
        private const string RelativeFolderPath = "Assets/Plant UML/Editor/Templates";


        [MenuItem(MenuPath + "Class Diagram", priority = -100)]
        private static void GenerateClassDiagram() {
            GenerateDiagramFromTemplate("Template_ClassDiagram.puml");
        }

        [MenuItem(MenuPath + "Sequence Diagram", priority = -100)]
        private static void GenerateSequenceDiagram() {
            GenerateDiagramFromTemplate("Template_SequenceDiagram.puml");
        }


        private static void GenerateDiagramFromTemplate(string templateName) {
            string templatePath = GetTemplatePath(templateName);
            string outputPath = GetSelectedFolderPath(templateName);

            if (string.IsNullOrEmpty(outputPath)) {
                Debug.LogError("No valid folder selected.");
                return;
            }

            PlantUmlGenerator.GenerateDiagram(templatePath, outputPath);
        }

        /// <summary>
        /// 
        /// </summary>
        private static string GetTemplatePath(string templateName) {


            // �e���v���[�g�̃p�X��Ԃ��B���[�U�[���Ǝ��̃e���v���[�g��ǉ��ł���悤�Ƀf�B���N�g����ݒ�
            return Path.Combine(NitouTools.pacakagePath.ToProjectPath(), RelativeFolderPath, templateName);
        }

        /// <summary>
        /// 
        /// </summary>
        private static string GetSelectedFolderPath(string fileName) {
            // �I�𒆂̃t�H���_�̃p�X���擾
            string folderPath = AssetDatabase.GetAssetPath(Selection.activeObject);

            if (string.IsNullOrEmpty(folderPath) || !AssetDatabase.IsValidFolder(folderPath)) {
                folderPath = "Assets"; // �f�t�H���g�̃t�H���_
            }

            return Path.Combine(folderPath, fileName);
        }
    }
}

#endif