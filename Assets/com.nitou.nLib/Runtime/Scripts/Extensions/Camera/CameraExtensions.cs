using System;
using System.Linq;
using UnityEngine;

// [�Q�l] 
//  Unity Forums: Handles.Label with constant size (not scale based on distance to camera) 

namespace nitou {

    /// <summary>
    /// Camera�̊g�����\�b�h�N���X
    /// </summary>
    public static class CameraExtensions {

        /// <summary>
        /// �A�^�b�`����Ă���AudioListener���擾����g�����\�b�h
        /// </summary>
        public static AudioListener GetOrAddAudioListener(this Camera self) {
            if (self == null) {
                throw new ArgumentNullException(nameof(self));
            }
            return self.GetOrAddComponent<AudioListener>();
        }

        /// <summary>
        /// �w�肵�����[���h���W���J�����͈͓��Ɏ��܂��Ă��邩���ׂ�
        /// </summary>
        public static bool ContaineWorldPosition(this Camera self, Vector3 position, float distance) {
            Vector3 screenPos = self.WorldToScreenPoint(position);
            return ((screenPos.x >= 0) &&
            (screenPos.x <= self.pixelWidth) &&
            (screenPos.y >= 0) &&
            (screenPos.y <= self.pixelHeight) &&
            (screenPos.z > 0) &&
            (screenPos.z < distance));
        }
    }
}
