#if UNITY_EDITOR
using System.IO;
using UnityEngine;
using UnityEditor;

namespace nitou.Tools.CodeGeneration{

    /// <summary>
    /// �R�[�h�����֘A�̃��\�b�h��񋟂���N���X
    /// </summary>
    public static class CodeGenerator{

        public struct ClassInfo {
            public string className;
            public string namespaceName;
        }


        /// <summary>
        /// �R�[�h�𐶐����A�w�肳�ꂽ�f�B���N�g���Ƀt�@�C���Ƃ��ĕۑ����܂��B
        /// </summary>
        /// <param name="templatePath">�e���v���[�g�t�@�C���̃p�X</param>
        /// <param name="outputDirectory">�������ꂽ�t�@�C���̕ۑ���f�B���N�g��</param>
        /// <param name="className">���������N���X�̖��O</param>
        /// <param name="filePath">�t�@�C�����̃x�[�X�i�g���q�Ȃ��j</param>
        /// <param name="namespaceName">���������N���X�̖��O���</param>
        public static void GenerateClass(string templatePath, string outputDirectory,string filePath, ClassInfo classInfo) {
            // �e���v���[�g�t�@�C���̓ǂݍ���
            if (!File.Exists(templatePath)) {
                Debug.LogError($"�e���v���[�g�t�@�C����������܂���: {templatePath}");
                return;
            }

            string templateContent = File.ReadAllText(templatePath);

            // �e���v���[�g���̒u��
            templateContent = templateContent.Replace("#CLASSNAME#", classInfo.className);
            templateContent = templateContent.Replace("#FILEPATH#", filePath);
            templateContent = templateContent.Replace("#NAMESPACE#", classInfo.namespaceName);

            // �o�̓f�B���N�g�������݂��Ȃ��ꍇ�͍쐬
            if (!Directory.Exists(outputDirectory)) {
                Directory.CreateDirectory(outputDirectory);
            }

            // �t�@�C���̃p�X�����肵�ď�������
            string fileName = Path.Combine(outputDirectory, $"{classInfo.className}.cs");
            File.WriteAllText(fileName, templateContent);

            // AssetDatabase�����t���b�V������Unity�Ƀt�@�C����F��������
            AssetDatabase.Refresh();

            Debug.Log($"�N���X��������: {fileName}");
        }

    }
}
#endif