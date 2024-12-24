using System.Collections.Generic;
using UnityEngine;

// [�Q�l]
//  qiita: Unity�Ŏg����֗��֐�(�g�����\�b�h)�B https://qiita.com/nmss208/items/9846525cf523fb961b48

namespace nitou {

    /// <summary>
    /// <see cref="Component"/>�^�̊�{�I�Ȋg�����\�b�h�W�D
    /// </summary>
    public static partial class ComponentExtensions {

        /// ----------------------------------------------------------------------------
        // �R���|�[�l���g�̒ǉ�

        /// <summary>
        /// AddComponent�̊g�����\�b�h�D
        /// </summary>
        public static T AddComponent<T>(this Component self) where T : Component {
            return self.gameObject.AddComponent<T>();
        }

        /// <summary>
        /// AddComponents�̊g�����\�b�h�D
        /// </summary>
        public static void AddComponents<T1, T2>(this Component self)
            where T1 : Component where T2 : Component {
            self.gameObject.AddComponents<T1, T2>();
        }

        /// <summary>
        /// AddComponents�̊g�����\�b�h�D
        /// </summary>
        public static void AddComponents<T1, T2, T3>(this Component self)
            where T1 : Component where T2 : Component where T3 : Component {
            self.gameObject.AddComponents<T1, T2, T3>();
        }

        /// <summary>
        /// GameObject���Ώۂ̃R���|�[�l���g���ꍇ�͂�����擾���C�Ȃ���Βǉ����ĕԂ��g�����\�b�h�D
        /// </summary>
        public static T GetOrAddComponent<T>(this Component self) where T : Component {
            return self.gameObject.GetOrAddComponent<T>();
        }


        /// ----------------------------------------------------------------------------
        // �R���|�[�l���g�̔j��

        /// <summary>
        /// Destory�̊g�����\�b�h�D
        /// </summary>
        public static void Destroy(this Component self) {
            Object.Destroy(self);
        }

        /// <summary>
        /// DestroyImmediate�̊g�����\�b�h�D
        /// </summary>
        public static void DestroyImmediate(this Component self) {
            Object.DestroyImmediate(self);
        }

        /// <summary>
        /// Component���A�^�b�`����Ă���GameObject��j������D
        /// </summary>
        public static void DestroyGameObject(this Component self) {
            Object.Destroy(self.gameObject);
        }


        /// ----------------------------------------------------------------------------
        // �ݒ�

        public static void SetActive(this Component self, bool active) {
            self.gameObject.SetActive(active);
        }



        /// ----------------------------------------------------------------------------
        // ����

        /// <summary>
        /// �R���|�[�l���g���L�����ǂ������m�F����g�����\�b�h
        /// </summary>
        public static bool IsEnabled(this Component self) {
            var property = self.GetType().GetProperty("enabled", typeof(bool));
            return (bool)(property?.GetValue(self, null) ?? true);
        }

        /// <summary>
        /// GameObject���Ώۂ̃��C���[�Ɋ܂܂�Ă��邩�𒲂ׂ�g�����\�b�h
        /// </summary>
        public static bool IsInLayerMask(this Component self, LayerMask layerMask) {
            return GameObjectExtensions.IsInLayerMask(self.gameObject, layerMask);
        }
    }


    /// <summary>
    /// <see cref="Behaviour"/>�^�̊�{�I�Ȋg�����\�b�h�W
    /// </summary>
    public static class BehaviourExtensions {

        /// <summary>
        /// enabled��gameObject.activeSelf���ꊇ�Őݒ肷��g�����\�b�h
        /// </summary>
        public static void SetActiveAndEnabled(this Behaviour self, bool value) {
            self.enabled = value;
            self.gameObject.SetActive(value);
        }

    }
}