using UnityEngine;

namespace nitou {

    /// <summary>
    /// "Component Menu"�̃L�[���[�h��` (��AddComponentMenu�����̌Ăяo�����Ɏg�p����)
    /// </summary>
    public static partial class ComponentMenu {

        /// ----------------------------------------------------------------------------
        // �ړ���
        public static partial class Prefix {

            // Default Category
            public const string Audio = "Audio/";
            public const string Phisics = "Phisics/";


            public const string EventChannel = "Event Channel/";

        }

        
        /// ----------------------------------------------------------------------------
        // �ڔ���
        public static class Suffix {

        }


        /// ----------------------------------------------------------------------------
        // �\����
        public static class Order {

            public const int EventChannel = 0;

        }
    }

}