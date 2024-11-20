#if UNITY_EDITOR
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEditor.AssetImporters;

namespace nitou.Tools.CodeGeneration{

    [ScriptedImporter(1, "cstmp")]   // ���o�[�W�����ԍ��Ɗg���q���w��
    public class CodeTemplateImporter : ScriptedImporter {

        public override void OnImportAsset(AssetImportContext ctx) {

            // �C���|�[�g�Ώۂ̃t�@�C���p�X
            string filePath = ctx.assetPath;
            string fileName = PathUtils.GetFileName(filePath);

            // �A�Z�b�g���C���|�[�g���鏈���i��: �e�L�X�g�t�@�C���̓��e��ǂݍ��ށj
            string fileContent = System.IO.File.ReadAllText(filePath);

            // �ǂݍ��񂾓��e��ێ����� ScriptableObject �̐���
            CodeTemplateAsset asset = ScriptableObject.CreateInstance<CodeTemplateAsset>();
            asset.data = fileContent;

            // �A�Z�b�g���R���e�L�X�g�ɓo�^���AUnity�ɔF��������
            ctx.AddObjectToAsset(fileName, asset);
            ctx.SetMainObject(asset);

        }

    }


}
#endif