#if UNITY_EDITOR
using System.IO;
using UnityEngine;
using UnityEditor;

// [�Q�l]
//  LIGHT11: �X�N���v�g����X�N���v�g�t�@�C��(.cs)�𐶐����� https://light11.hatenadiary.com/entry/2018/03/22/191516

namespace nitou.Tools.CodeGeneration{

    /// <summary>
    /// �R�[�h�����֘A�̃��\�b�h��񋟂���N���X
    /// </summary>
    public static class CodeGenerator{


        // �萔
        private const string CLASS_KEY = "#CLASSNAME#";
        private const string NAMESPACE_KEY = "#CLASSNAME#";
        private const string FILE_PATH_KEY = "#NAMESPACE#";

        /// <summary>
        /// �R�[�h�𐶐����A�w�肳�ꂽ�f�B���N�g���Ƀt�@�C���Ƃ��ĕۑ����܂��B
        /// </summary>
        public static void GenerateClass(string templatePath, string outputDirectory, CodeInfo codeInfo) {
            var templateCode = CodeTemplate.FromFile(templatePath);
            if (templateCode == null) return;

            // �e���v���[�g���̒u��
            var code = templateCode
                .Replace(CLASS_KEY, codeInfo.className)
                .Replace(NAMESPACE_KEY, codeInfo.namespaceName);
                //.Replace(FILE_PATH_KEY, filePath);

            // �o�̓f�B���N�g�������݂��Ȃ��ꍇ�͍쐬
            if (!Directory.Exists(outputDirectory)) {
                Directory.CreateDirectory(outputDirectory);
            }

            // �t�@�C���̃p�X�����肵�ď�������
            string fileName = Path.Combine(outputDirectory, $"{codeInfo.className}.cs");
            File.WriteAllText(fileName, code);

            // AssetDatabase�����t���b�V������Unity�Ƀt�@�C����F��������
            AssetDatabase.Refresh();

            Debug.Log($"�N���X��������: {fileName}");
        }
    }
}
#endif