using System;
using UnityEngine;
using UnityEngine.UI;

namespace nitou {

    /// <summary>
    /// <see cref="RawImage"/>�^�̊�{�I�Ȋg�����\�b�h�W�D
    /// </summary>
    public static partial class RawImageExtensions {

        /// <summary>
        /// �e�N�X�`���T�C�Y�Ɋ�Â��Ďw�肵�����[�h�ŃA�X�y�N�g���ݒ肷��D
        /// </summary>
        public static void SetAspectRatio(this RawImage self, AspectRatioFitter.AspectMode aspectMode) {

            if(self.texture == null)
                throw new InvalidOperationException("The texture assigned to the RawImage is null. Please assign a texture before setting the aspect ratio.");

            var aspectRatioFitter = self.GetOrAddComponent<AspectRatioFitter>();
            aspectRatioFitter.aspectMode = aspectMode;
            aspectRatioFitter.aspectRatio = (float)self.texture.width / self.texture.height;
        }

    }
}
