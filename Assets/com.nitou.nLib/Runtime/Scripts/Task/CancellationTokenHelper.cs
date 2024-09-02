using System.Threading;

// [�Q�l]
//  Zenn: UniRx/UniTask��S https://zenn.dev/tmb/articles/e4fb3fe350852f

namespace nitou {

    /// <summary>
    /// CancellationTokenSource�C���X�^���X�����ւ��ČJ��Ԃ��g�p���邽�߂̃��b�p�[
    /// </summary>
    public class CancellationTokenHelper {
        
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
        /// �R���X�g���N�^
        /// </summary>
        public CancellationTokenHelper() {
            Reset();
        }

        /// <summary>
        /// �f�X�g���N�^
        /// </summary>
        ~CancellationTokenHelper() {
            Dispose();
        }

        /// <summary>
        /// ���Z�b�g
        /// </summary>
        public void Reset() {
            Dispose();
            Cts = new CancellationTokenSource();
        }

        /// <summary>
        /// �j��
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
