using UniRx;
using UnityEngine;

namespace nitou {

    /// <summary>
    /// <see cref="Subject{T}"/>�^�̊�{�I�Ȋg�����\�b�h�W�D
    /// </summary>
    public static partial class SubjectUtils {

        /// <summary>
        /// <see cref="Subject{T}.OnCompleted"/>�𔭍s����I�������D
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
