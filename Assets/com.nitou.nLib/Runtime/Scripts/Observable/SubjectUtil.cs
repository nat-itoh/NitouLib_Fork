using UniRx;
using UnityEngine;

namespace nitou {
    /// <summary>
    /// <see cref="Subject{T}"/>�^�̊�{�I�Ȋg�����\�b�h�W
    /// </summary>
    public static class SubjectUtil {

        /// <summary>
        /// 
        /// </summary>
        public static void DisposeSubject<T>(ref Subject<T> subject) {

            if (subject != null) {

                try {
                    subject.OnCompleted();
                } finally {
                    subject.Dispose();
                    subject = null;
                }
            }

        }

    }
}
