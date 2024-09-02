
namespace nitou {

    /// <summary>
    /// UnityEditor��Toolbar���j���[�Ɋւ����`
    /// </summary>
    public static class ToolBarMenu {

        /// ----------------------------------------------------------------------------
        // �ړ���
        public static class Prefix {

            /// <summary>
            /// 
            /// </summary>
            public const string EditorWindow = "Window/Nitou/";

            /// <summary>
            /// 
            /// </summary>
            public const string EditorTool = "Tools/Nitou/";

            /// <summary>
            /// �J�����̃f�o�b�O�R�}���h�ȂǗp�̃^�O
            /// </summary>
            public const string Develop = "Develop/";


        }



        /// ----------------------------------------------------------------------------
        // �\����
        public static class Order {
            public const int VeryEarly = 100;
            public const int Early = 50;
            public const int Normal = 0;
            public const int Late = -50;
            public const int VeryLate = -100;
        }
    }
}
