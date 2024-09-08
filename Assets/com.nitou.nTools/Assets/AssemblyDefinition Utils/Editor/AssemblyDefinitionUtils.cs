#if UNITY_EDITOR
using System.IO;
using UnityEngine;
using UnityEditor;

// [�Q�l]
//  qiita: AssemblyDefinition.asmdef���X�N���v�g����쐬���� https://qiita.com/im0039kp/items/b6ebc1e07b04e5dd9dc1

namespace nitou.Tools.Assets {

    public static class AssemblyDefinitionUtils {

        public static void Generate(string name, string assetPath) {
            var json = new JsonAssemblyDefinition() {
                name = name,
            };

            string text = JsonUtility.ToJson(json);
            string path = Path.Combine(Application.dataPath, $"{assetPath}/{name}.asmdef");
            File.WriteAllText(path, text);
            Debug_.Log($"{assetPath}/{name}.asmdef �𐶐����܂����D", Colors.Green);

            AssetDatabase.ImportAsset($"Assets/{assetPath}/{name}.asmdef", ImportAssetOptions.ForceUpdate);
        }

    }
}
#endif


