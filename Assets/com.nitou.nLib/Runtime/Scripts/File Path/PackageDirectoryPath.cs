using System.IO;
using UnityEngine;

namespace nitou {

    /// <summary>
    /// ����p�b�P�[�W�̃f�B���N�g���p�X�w��p�̃N���X
    /// </summary>
    [System.Serializable]
    public sealed class PackageDirectoryPath : IUnityProjectPath{

        public enum Mode {
            // �z�z��
            Upm,
            // �J���v���W�F�N�g��
            Normal,
            // 
            NotExist,
        }

        // ���΃p�X
        private readonly string _upmRelativePath;
        private readonly string _normalRelativePath;

        private Mode _mode;

        /// <summary>
        /// Package�z�z��̃p�b�P�[�W�p�X
        /// </summary>
        public string UpmPath => $"Packages/{_upmRelativePath}";

        /// <summary>
        /// �J���v���W�F�N�g�ł̃A�Z�b�g�p�X
        /// </summary>
        public string NormalPath => $"Assets/{_normalRelativePath}";


        /// ----------------------------------------------------------------------------
        // Pubic Method

        /// <summary>
        /// �R���X�g���N�^
        /// </summary>
        public PackageDirectoryPath(string relativePath = "com.nitou.nLib") {
            _upmRelativePath = relativePath;
            _normalRelativePath = relativePath;

            // ���肷��
            _mode = CheckDirectoryLocation();
        }

        /// <summary>
        /// �R���X�g���N�^
        /// </summary>
        public PackageDirectoryPath(string upmRelativePath = "com.nitou.nLib", string normalRelativePath = "Plugins/com.nitou.nLib") {
            _upmRelativePath = upmRelativePath;
            _normalRelativePath = normalRelativePath;

            // ���肷��
            _mode = CheckDirectoryLocation();
        }


        /// ----------------------------------------------------------------------------
        // Pubic Method

        /// <summary>
        /// Project�f�B���N�g�����N�_�Ƃ����p�X
        /// </summary>
        public string ToProjectPath() {
            return _mode switch {
                Mode.Upm => UpmPath,
                Mode.Normal => NormalPath,
                _ => ""
            };
        }

        /// <summary>
        /// ��΃p�X
        /// </summary>
        public string ToAbsolutePath() => Path.GetFullPath(ToProjectPath());


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
