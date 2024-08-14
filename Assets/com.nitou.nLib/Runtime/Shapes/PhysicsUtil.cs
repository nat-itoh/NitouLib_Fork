using UnityEngine;

namespace nitou{

    public static class PhysicsUtil{

        /// <summary>
        /// <see cref="Shapes.Box"/>�ƌ������Ă���<see cref="Collider"/>��S�Ď擾���ăL���b�V������
        /// </summary>
        public static int OverlapBoxNonAlloc(Shapes.Box box, Collider[] results,int layerMask) {

            return Physics.OverlapBoxNonAlloc(
                box.position,
                box.size.Half(),
                results,
                box.rotation,
                layerMask);
        }

        /// <summary>
        /// <see cref="Shapes.Box"/>�ƌ������Ă���<see cref="Collider"/>��S�Ď擾���ăL���b�V������
        /// </summary>
        public static int OverlapBoxNonAlloc(Transform trans, Shapes.Box box, Collider[] results, int layerMask) {

            var position = box.GetWorldPosition(trans);
            var rotation = box.GetWorldRotaion(trans);

            return Physics.OverlapBoxNonAlloc(
                position,
                box.size.Half(),
                results,
                rotation,
                layerMask);
        }



    }
}
