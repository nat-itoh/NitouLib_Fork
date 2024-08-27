using System.IO;
using UnityEngine;

namespace nitou {

    [System.Serializable]
    public sealed class PackageDirectoryPath : IUnityProjectPath{

        public enum Mode {
            Upm,
            Normal,
            NotExist,
        }

        // Package�z�z��̑��΃p�X ("Packages/...")
        private readonly string _upmRelativePath;

        // �J���v���W�F�N�g�ł̑��΃p�X ("Assets/...")
        private readonly string _normalRelativePath;

        private Mode _mode;


        public string UpmPath => $"Packages/{_upmRelativePath}";
        public string NormalPath => $"Assets/{_normalRelativePath}";


        /// ----------------------------------------------------------------------------
        // Pubic Method

        /// <summary>
        /// �R���X�g���N�^
        /// </summary>
        public PackageDirectoryPath(string upmRelativePath = "com.nitou.nLib", string normalRelativePath = "nLib") {
            _upmRelativePath = upmRelativePath;
            _normalRelativePath = normalRelativePath;

            // ���肷��
            _mode = CheckDirectoryLocation();
        }
            
        public string ToProjectPath() {
            throw new System.NotImplementedException();
        }

        public string ToAbsolutePath() {
            throw new System.NotImplementedException();
        }


        /// ----------------------------------------------------------------------------
        // Private Method

        /// <summary>
        /// �f�B���N�g���̈ʒu�𔻒肷��
        /// </summary>
        private Mode CheckDirectoryLocation() {

            if (Directory.Exists(UpmPath)) return Mode.Upm;
            if (Directory.Exists(NormalPath)) return Mode.Normal;

            Debug.LogError($"Directory not found in both UPM and normal paths: \n" +
                    $"  [{UpmPath}] and \n" +
                    $"  [{NormalPath}]");
            return Mode.NotExist;
        }
    }
}
