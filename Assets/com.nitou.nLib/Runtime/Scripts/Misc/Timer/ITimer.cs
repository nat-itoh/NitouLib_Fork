using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace nitou{

    /// <summary>
    /// �^�C�}�[�̊�{������`�����C���^�[�t�F�[�X
    /// </summary>
    public interface ITimer {
        public void Start();
        public void Stop();
        public void Reset();
    }
}
