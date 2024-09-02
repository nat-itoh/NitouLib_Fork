
namespace nitou {

    /// <summary>
    /// "Create Asset Menu"�p�̊e���`
    /// </summary>
    public static class AssetMenu {

        /// ----------------------------------------------------------------------------
        // �ړ���
        public static class Prefix {

            /// <summary>
            /// �X�N���v�^�u���I�u�W�F�N�g
            /// </summary>
            public const string ScriptableObject = "Scriptable Objects/";

            /// <summary>
            /// �L�����N�^�[���f��
            /// </summary>
            public const string ActorModelInfo = ScriptableObject + "Actor Model/";

            /// <summary>
            /// �N���W�b�g���
            /// </summary>
            public const string CreditInfo = ScriptableObject + "Credit Info/";

            /// <summary>
            /// �V�[�����
            /// </summary>
            public const string SceneInfo = ScriptableObject + "Scene Info/";

            // ----- 

            /// <summary>
            /// �C�x���g�`�����l��
            /// </summary>
            public const string EventChannel = "Event Channel/";
            
            /// <summary>
            /// �A�j���[�V�����f�[�^
            /// </summary>
            public const string AnimationData = "Animation Data/";

            /// <summary>
            /// �L�����N�^�[����֘A
            /// </summary>
            public const string CharacterControl = "CharacterControl/";
        }


        /// ----------------------------------------------------------------------------
        // �ڔ���
        public static class Suffix {

        }


        /// ----------------------------------------------------------------------------
        // �\����
        public static class Order {
            public static readonly int VeryEarly = 100;
            public static readonly int Early = 50;
            public static readonly int Normal = 0;
            public static readonly int Late = -50;
            public static readonly int VeryLate = -100;
        }
    }

}