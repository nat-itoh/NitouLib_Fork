using UnityEngine;

namespace nitou.HitSystem {
    using nitou.BachProcessor;
    public partial class NestedField {


        private class NestedFieldSystem :
            SystemBase<NestedField, NestedFieldSystem>,
            IEarlyUpdate {

            /// <summary>
            /// 1�x�Ɍ��o�ł���R���W�����̍ő吔.
            /// </summary>
            private const int CAPACITY = 50;

            private readonly Collider[] _results = new Collider[CAPACITY];

            /// <summary>
            /// �V�X�e���̎��s����
            /// </summary>
            int ISystemBase.Order => 0;

            /// ----------------------------------------------------------------------------
            // Method

            private void OnDestroy() => UnregisterAllComponents();

            /// <summary>
            /// �X�V����
            /// </summary>
            void IEarlyUpdate.OnUpdate() {

                // Initialize components
                foreach (var component in Components) {
                    component.PrepareFrame();
                }

                // Update collision detection using Physics
                foreach (var component in Components) {
                    component.OnUpdate(in _results);
                }


            }
        }
    }
}
