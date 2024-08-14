using UnityEngine;

namespace nitou.HitSystem{

    /// <summary>
    /// �q�b�g�����i�[����f�[�^�N���X
    /// </summary>
    public class HitData{

        /// <summary>
        /// �R���^�N�g���W
        /// </summary>
        public readonly Vector3 position;
        
        /// <summary>
        /// ����
        /// </summary>
        public readonly Vector3 direction;

        // �q�b�g�X�g�b�v
        public readonly bool hitStop = false;
        public readonly float stopDuration = 0f;


        // ���������p
        private readonly float _time;

        /// <summary>
        /// �o�ߎ���
        /// </summary>
        public float ElaposedTime => Time.time - _time;


        /// ----------------------------------------------------------------------------
        // Public Method

        /// <summary>
        /// �R���X�g���N�^
        /// </summary>
        public HitData(Vector3 position, Vector3 direction) {
            this.position = position;
            this.direction = direction.normalized;

            // ���Ԃ��L�^
            _time = Time.time;
        }

        /// <summary>
        /// �R���X�g���N�^
        /// </summary>
        public HitData(Vector3 position, Vector3 direction, bool hitStop) {
            // 
            this.position = position;
            this.direction = direction.normalized;

            // �q�b�g�X�g�b�v
            this.hitStop = hitStop;
            this.stopDuration = Mathf.Max(0, 0.2f);

            // ���Ԃ��L�^
            _time = Time.time;
        }

        
        /// ----------------------------------------------------------------------------

        /// <summary>
        /// �M�Y����\������
        /// </summary>
        public void DrawGizmo(Color color) {
            Gizmos_.DrawSphere(position, 0.1f, color);
            Gizmos_.DrawRayArrow(position, direction, color);
        }
    }
}
