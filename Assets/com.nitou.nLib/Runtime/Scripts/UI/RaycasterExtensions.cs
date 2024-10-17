using System.Linq;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using nitou.DesignPattern.Pooling;

namespace nitou
{
    /// <summary>
    /// 
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

    }
}
