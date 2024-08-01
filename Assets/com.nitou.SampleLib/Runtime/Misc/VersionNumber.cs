using System.Linq;
using System.Collections;
using System.Collections.Generic;

// [�Q�l]
//  �R�K�l�u���O: �o�[�W�����ԍ����Ǘ�����\���̗̂�

namespace nitou {

    /// <summary>
    /// �v���W�F�N�g�̃o�[�W�����ԍ����Ǘ�����\����
    /// </summary>
    public readonly struct VersionNumber {

        private readonly string _version;

        public int Major { get; }
        public int Minor { get; }
        public int Patch { get; }


        /// ----------------------------------------------------------------------------
        // Public Methord

        /// <summary>
        /// �R���X�g���N�^
        /// </summary>
        public VersionNumber(string version) {

            var array = version
                .Split(".")
                .Select(x => int.TryParse(x, out int result) ? result : default)
                .ToArray();

            Major = array.ElementAtOrDefault(0);
            Minor = array.ElementAtOrDefault(1);
            Patch = array.ElementAtOrDefault(2);
            _version = $"{Major}.{Minor}.{Patch}";
        }

        /// <summary>
        /// �R���X�g���N�^
        /// </summary>
        public VersionNumber(int major, int minor, int patch) {
            Major = major;
            Minor = minor;
            Patch = patch;
            _version = $"{Major}.{Minor}.{Patch}";
        }

        /// <summary>
        /// �ÖٓI�L���X�g
        /// </summary>
        public static implicit operator string(in VersionNumber versionNumber) {
            return versionNumber._version;
        }

        /// <summary>
        /// ������ւ̕ϊ�
        /// </summary>
        public override string ToString() {
            return _version;
        }

    }
}
