using System.Collections.Generic;
using UnityEngine;

namespace nitou {

    public static class CameraUtil {

        /// <summary>
        /// �o�^����Ă���S�Ă�<see cref="Camera">�J����</see>���A�N�e�B�u��Ԃɐݒ肷��
        /// </summary>
        public static void DeactivateAllCamera() {
            Camera.allCameras.ForEach(c => c.gameObject.SetActive(false));
        }

        /// <summary>
        /// �o�^����Ă���S�Ă�<see cref="AudioListener">�I�[�f�B�I���X�i�[</see>���A�N�e�B�u��Ԃɐݒ肷��
        /// </summary>
        public static void DeactivateAllAudioListeners() {
            Camera.allCameras.ForEach(x => x.GetOrAddAudioListener().enabled = false);
        }
    }
}
