using System.Linq;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

namespace nitou{
    using nitou.DesignPattern.Pooling;

    /// <summary>
    /// Raycaster�֘A�̊�{�I�Ȋg�����\�b�h�W
    /// </summary>
    public static class RaycasterExtensions {

        /// <summary>
        /// Raycast�̊g�����\�b�h�D
        /// �i���񃊃X�g�𐶐����邽�߁A��{�I�ɂ͈����Ƀ��X�g���󂯎��ʏ�ł��g�p����D�j
        /// </summary>
        public static List<RaycastResult> Raycast(this BaseRaycaster self, PointerEventData pointerEventData) {
            List<RaycastResult> results = new();
            self.Raycast(pointerEventData, results);
            return results;
        }

        /// <summary>
        /// �w�肵���X�N���[�����W��UI�����邩�ǂ������ׂ�
        /// </summary>
        public static bool OverlapUI(this IEnumerable<GraphicRaycaster> raycasters, PointerEventData pointerEventData) {

            var results = ListPool<RaycastResult>.New();
            bool isOverlap = false;

            try {
                // �eRaycaster�ŏd�Ȃ蔻����s��
                foreach (var raycaster in raycasters.WithoutNull()) {
                    raycaster.Raycast(pointerEventData, results);
                    if (results.Count > 0) {
                        isOverlap = true;
                        break;
                    }
                }
            } finally {
                results.Free();
            }
            return isOverlap;
        }

        /// <summary>
        /// �w�肵��Raycaster�̒�����A�d�Ȃ�̂���R���|�[�l���g���擾����
        /// </summary>
        public static T GetOverlapComponent<T>(this IEnumerable<BaseRaycaster> raycasters, PointerEventData pointerEventData)
            where T : class {
            
            var results = ListPool<RaycastResult>.New();
            T target = default;

            try {
                foreach (var raycaster in raycasters.WithoutNull()) {
                    raycaster.Raycast(pointerEventData, results);
                    if (results.IsEmpty()) continue;

                    // �ŏ��Ɍ��������d�Ȃ�̂���R���|�[�l���g���擾
                    target = results.FirstOrDefault(r => r.gameObject.GetComponent<T>() != null).gameObject?.GetComponent<T>();
                    if (target != null) break; // �R���|�[�l���g�����������烋�[�v���I��
                }
            } finally {
                results.Free();
            }

            return target; // ������Ȃ������ꍇ�̓f�t�H���g�l��Ԃ�
        }

        /// <summary>
        /// GraphicRaycaster�̃��X�g����Drag�R���|�[�l���g���擾���܂��B
        /// </summary>
        public static T GetDragAtPosition<T>(this IEnumerable<BaseRaycaster> raycasters, PointerEventData pointerEventData) {
            return raycasters
                .Where(raycaster => raycaster != null)
                .SelectMany(raycaster => {
                    var results = new List<RaycastResult>();
                    raycaster.Raycast(pointerEventData, results);
                    return results;
                })
                .Select(result => result.gameObject.GetComponentInParent<T>())
                .FirstOrDefault(drag => drag != null);
        }



        /// <summary>
        /// <see cref="GraphicRaycaster"/>��Canvas��sortingOrder���Ƀ\�[�g����
        /// </summary>
        public static IEnumerable<GraphicRaycaster> OrderBySortingOrder(this IEnumerable<GraphicRaycaster> raycasters) {
            return raycasters
                // SortingOrder�ŏ����Ƀ\�[�g
                .OrderBy(raycaster =>  raycaster.sortOrderPriority);
        }
    }


    /// <summary>
    /// <see cref="RaycastResult"/>�^�̊�{�I�Ȋg�����\�b�h�W
    /// </summary>
    public static class RaycastResultExtensions {

    }


}
