using System;
using System.IO;
using UnityEngine;

// [�Q�l]
//  _:��΃p�X�� Assets �p�X�̕ϊ����\�b�h https://www.create-forever.games/unity-absolute-path-assets-path/#google_vignette

namespace nitou {

    // [��{�@�\]
    // �A�Z�b�g�p�X�̕ێ�: �A�Z�b�g�p�X��\���������ێ�����B
    // �p�X�̕ϊ�: AssetDatabase�p�̃A�Z�b�g�p�X�ƁASystem.IO�p�̃t�@�C���V�X�e���p�X�Ƃ̑��ݕϊ����ȒP�ɍs����B
    // �p�X����: �p�X�̌����A���΃p�X�Ɛ�΃p�X�̕ϊ��A�g���q�̕ύX��폜�ȂǁA��{�I�ȃp�X���삪�\�B
    // �p�X�̌���: �A�Z�b�g�p�X���������t�H�[�}�b�g�ł��邩�A���݂��邩�����؂ł���B

    [System.Serializable]
    public sealed class AssetPath {

        // "Assets/�ȉ��̑��΃p�X"
        [SerializeField] private string _relativePath = "";

        private const string PREFIX = "Assets/";


        // ����J�̃R���X�g���N�^
        private AssetPath(string relativePath) {
            _relativePath = relativePath!=null ? relativePath.Replace("\\", "/") : "";
        }


        /// --------------------------------------------------------------------
        #region Factory Methods

        public static AssetPath Empty() => new AssetPath("");

        public static AssetPath FromAssetPath(string assetPath) {
            if (assetPath == null) throw new ArgumentNullException(nameof(assetPath));

            if (!assetPath.StartsWith("Assets/")) {
                throw new ArgumentException("");
            }
            return new AssetPath(assetPath.Substring("Assets/".Length));
        }

        /// <summary> 
        /// "Assets/"�ȉ��̑��΃p�X���w�肵�Đ�������
        /// </summary>
        public static AssetPath FromRelativePath(string relativePath) {
            if (relativePath == null) throw new ArgumentNullException(nameof(relativePath));

            if (relativePath.StartsWith("Assets/")) {
                relativePath = relativePath.Substring("Assets/".Length);
            }
            return new AssetPath(relativePath);
        }

        /// <summary> 
        /// "Assets/"�ȉ��̑��΃p�X���w�肵�Đ�������
        /// </summary>
        public static AssetPath FromRelativePath(string relativeDirectoryPath, string assetName) {
            if (relativeDirectoryPath == null) throw new ArgumentNullException(nameof(relativeDirectoryPath));
            if (assetName == null) throw new ArgumentNullException(nameof(assetName));

            if (relativeDirectoryPath.StartsWith("Assets/")) {
                relativeDirectoryPath = relativeDirectoryPath.Substring("Assets/".Length);
            }
            return new AssetPath($"{relativeDirectoryPath}/{assetName}");
        }

        /// <summary>
        /// ��΃p�X���琶������
        /// </summary>
        public static AssetPath FromAbsolutePath(string absolutePath) {
            string relativePath = absolutePath.Replace(Application.dataPath, "").TrimStart('\\', '/');
            return new AssetPath(relativePath);
        }

        /// <summary>
        /// �C�ӂ̃A�Z�b�g���琶������
        /// </summary>
        public static AssetPath FromAsset(UnityEngine.Object asset) {
            if (asset == null) throw new ArgumentNullException(nameof(asset));

            string assetPath = "";
#if UNITY_EDITOR
            assetPath = UnityEditor.AssetDatabase.GetAssetPath(asset);
            if (string.IsNullOrEmpty(assetPath)) {
                throw new ArgumentException("The provided asset is not a valid asset in the Assets folder.");
            }
#endif

            return FromRelativePath(assetPath);
        }
        #endregion


        /// --------------------------------------------------------------------
        #region Convert to string

        /// <summary>
        /// ���΃p�X
        /// </summary>
        public string ToRelativePath() => _relativePath;

        /// <summary>
        /// �A�Z�b�g�p�X
        /// </summary>
        public string ToAssetDatabasePath() => "Assets/" + _relativePath;

        /// <summary>
        /// ��΃p�X
        /// </summary>
        public string ToAbsolutePath() => Path.GetFullPath(Path.Combine(Application.dataPath, _relativePath));
        
        public override string ToString() => this.ToAssetDatabasePath();
        #endregion


        /// --------------------------------------------------------------------

        public AssetPath ChangeExtension(string newExtension) {
            return new AssetPath(Path.ChangeExtension(_relativePath, newExtension));
        }

        public AssetPath RemoveExtension() {
            return ChangeExtension(null);
        }

        public AssetPath Combine(string additionalPath) {
            return new AssetPath(Path.Combine(_relativePath, additionalPath).Replace("\\", "/"));
        }


        /// --------------------------------------------------------------------
        #region Check

        /// <summary>
        /// 
        /// </summary>
        public bool IsValidAssetPath() {
            return !string.IsNullOrEmpty(_relativePath);
        }

        /// <summary>
        /// �t�@�C�������݂��邩�m�F����
        /// </summary>
        public bool Exists() {
            return this.IsFile() || this.IsDirectory();
        }

        /// <summary>
        /// �p�X�Ƀt�@�C�������݂��邩�m�F����
        /// </summary>
        public bool IsFile() {
            return File.Exists(this.ToAbsolutePath());
        }

        /// <summary>
        /// �p�X�Ƀt�H���_�����݂��邩�m�F����
        /// </summary>
        public bool IsDirectory() {
            return Directory.Exists(this.ToAbsolutePath());
        }

        #endregion


        /// --------------------------------------------------------------------
        #region Equality Overrides

        public override bool Equals(object obj) {
            if (obj is AssetPath other) {
                return string.Equals(_relativePath, other._relativePath, StringComparison.OrdinalIgnoreCase);
            }
            return false;
        }

        public override int GetHashCode() => _relativePath.GetHashCode(StringComparison.OrdinalIgnoreCase);

        public static bool operator ==(AssetPath left, AssetPath right) => Equals(left, right);
        
        public static bool operator !=(AssetPath left, AssetPath right) => !Equals(left, right);
        #endregion
    }
}


/// --------------------------------------------------------------------
#if UNITY_EDITOR
namespace nitou.EditorScripts {
    using UnityEditor;

    [CustomPropertyDrawer(typeof(AssetPath))]
    public class AssetPathDrawer : PropertyDrawer {

        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label) {
            // "relativePath"�v���p�e�B�𐳂����擾����
            var relativePathProperty = property.FindPropertyRelative("_relativePath");

            // "Assets/" �̃��x����\��
            EditorGUI.LabelField(new Rect(position.x, position.y, 50, position.height), "Assets/");

            // ���΃p�X�̓��̓t�B�[���h��\��
            EditorGUI.PropertyField(
                new Rect(position.x + 50, position.y, position.width - 50, position.height),
                relativePathProperty,
                GUIContent.none
            );
        }
    }
}
#endif