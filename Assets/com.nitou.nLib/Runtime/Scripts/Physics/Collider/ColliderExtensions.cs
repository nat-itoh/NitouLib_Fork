using UnityEngine;

namespace nitou{

    /// <summary>
    /// <see cref="Collider"/>�̊�{�I�Ȋg�����\�b�h�W
    /// </summary>
    public static class ColliderExtensions{

        /// ----------------------------------------------------------------------------
        #region Setter (���\�b�h�`�F�[���p)

        /// <summary>
        /// <see cref="Collider.isTrigger"/>��ݒ肷��g�����\�b�h
        /// </summary>
        public static TCollider SetTrigger<TCollider>(this TCollider self, bool isTrigger) 
            where TCollider : Collider{
            
            self.isTrigger = isTrigger;
            return self;
        }



        /// <summary>
        /// <see cref="Collider.material"/>��ݒ肷��g�����\�b�h
        /// </summary>
#if UNITY_6000_0_OR_NEWER
        public static TCollider SetMaterial<TCollider>(this TCollider self, PhysicsMaterial material)
            where TCollider : Collider {
            
            self.material = material;
            return self;
        }
#else
       public static TCollider SetMaterial<TCollider>(this TCollider self, PhysicMaterial material)
            where TCollider : Collider {
            
            self.material = material;
            return self;
        }

#endif

        #endregion


        /// ----------------------------------------------------------------------------
        #region Center Position

        /// <summary>
        /// �O���[�o�����W�ɕϊ������R���C�_�[���S���W���擾����g�����\�b�h
        /// </summary>
        public static Vector3 GetWorldCenter(this Collider self) {        
            if(self is BoxCollider box)  return box.GetWorldCenter();
            else if(self is SphereCollider sphere) return sphere.GetWorldCenter();
            else if(self is CapsuleCollider capcel) return capcel.GetWorldCenter();

            return self.transform.position;
        }
               

        

        
#endregion
    }
}
