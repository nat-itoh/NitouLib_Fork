using System.Threading;

// [REF]
//  Zenn: UniRx/UniTask��S https://zenn.dev/tmb/articles/e4fb3fe350852f

namespace nitou {

    /// <summary>
    /// CancellationTokenSource�C���X�^���X�����ւ��ČJ��Ԃ��g�p���邽�߂̃��b�p�[�D
    /// </summary>
    public sealed class CancellationTokenHelper {
        
        /// <summary>
        /// �\�[�X
        /// </summary>
        public CancellationTokenSource Cts { get; private set; }

        /// <summary> 
        /// �g�[�N�� 
        /// </summary>
        public CancellationToken Token => Cts.Token;


        /// ----------------------------------------------------------------------------
        // Public Method

        /// <summary>
        /// �R���X�g���N�^�D
        /// </summary>
        public CancellationTokenHelper() {
            Reset();
        }

        /// <summary>
        /// �f�X�g���N�^�D
        /// </summary>
        ~CancellationTokenHelper() {
            Dispose();
        }

        /// <summary>
        /// ���Z�b�g�D
        /// </summary>
        public void Reset() {
            Dispose();
            Cts = new CancellationTokenSource();
        }

        /// <summary>
        /// �j���D
        /// </summary>
        public void Dispose() {
            if (Cts != null) {
                Cts.Cancel();
                Cts.Dispose();
                Cts = null;
            }
        }
    }
}
