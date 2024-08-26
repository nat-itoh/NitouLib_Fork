using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using nitou;

namespace Project
{
    public class AssetPathTest : MonoBehaviour{

        
        void Start()
        {

            // AssetPath�N���X�̎g�p��
            var relativePath = "Textures/MyTexture.png";
            var assetPath = AssetPath.FromRelativePath(relativePath);
            Debug_.Log(relativePath);
            Debug_.Log(assetPath.ToAssetDatabasePath());
            Debug_.Log(assetPath.ToAbsolutePath());
            Debug_.Log(assetPath.ToSystemIOPath());


            // System.IO�p�̃p�X�ɕϊ�
            string systemPath = assetPath.ToSystemIOPath();

            // �g���q��ύX
            var newAssetPath = assetPath.ChangeExtension(".jpg");

            // �p�X�̌���
            bool isValid = assetPath.IsValidAssetPath();

            // �A�Z�b�g�����݂��邩�m�F
            bool exists = assetPath.Exists();


        }



    }
}
