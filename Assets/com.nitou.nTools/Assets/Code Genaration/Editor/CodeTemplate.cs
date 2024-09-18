using System.IO;
using UnityEngine;

namespace nitou.Tools
{
    public static class CodeTemplate{


        public static readonly string CODE_TEMPLATE = @"
            public class #CLASS_NAME#{
              public void #METHOD_NAME#() {
              }
            }
            ";

        public static string FromFile(string templatePath) {

            // �e���v���[�g�t�@�C���̓ǂݍ���
            if (!File.Exists(templatePath)) {
                Debug.LogError($"�e���v���[�g�t�@�C����������܂���: {templatePath}");
                return null;
            }

            return File.ReadAllText(templatePath);
        }
    }
}
