using System.Collections.Generic;
using UnityEngine;

namespace nitou{

    public interface ISmoothDampValue<TValue>
        where TValue : struct{

        /// <summary>
        /// ���������ꂽ�l���擾����
        /// </summary>
        public TValue GetNext(TValue target, float smoothTime);

        /// <summary>
        /// ���������ꂽ�l���擾����
        /// </summary>
        public TValue GetNext(TValue target, float smoothTime, float maxSpeed);

        /// <summary>
        /// ���������ꂽ�l���擾����
        /// </summary>
        public TValue GetNext(TValue target, float smoothTime, float maxSpeed, float deltaTime);
    }
}
