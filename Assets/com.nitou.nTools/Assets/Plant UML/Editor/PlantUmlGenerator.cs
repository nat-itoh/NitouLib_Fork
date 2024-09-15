#if UNITY_EDITOR
using System.IO;
using UnityEngine;
using UnityEditor;

namespace nitou.Tools.PumlGenerator {

    public static class PlantUmlGenerator {
        
        public static void GenerateDiagram(string templatePath, string outputPath) {
            if (!File.Exists(templatePath)) {
                Debug.LogError($"Template not found at: {templatePath}");
                return;
            }

            string templateContent = File.ReadAllText(templatePath);

            // �������W�b�N�F�e���v���[�g�̓��e�����Ƃ�PlantUML�̃R�[�h�𐶐�
            // �����ŁA�K�v�ɉ����ăe���v���[�g�̃v���[�X�z���_�[��u�����ăJ�X�^�}�C�Y
            string generatedContent = templateContent; // �v���[�X�z���_�[�����ۂ̓��e�ɒu�����鏈����ǉ�

            File.WriteAllText(outputPath, generatedContent);
            AssetDatabase.Refresh(); // �A�Z�b�g�f�[�^�x�[�X���X�V���ĐV�����t�@�C����\��

            Debug.Log($"PlantUML diagram generated at: {outputPath}");
        }

    }
}

#endif