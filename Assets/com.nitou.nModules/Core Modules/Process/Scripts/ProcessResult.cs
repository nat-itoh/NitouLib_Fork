
namespace nitou.GameSystem {

    /// <summary>
    /// ���ʃf�[�^�̊��N���X
    /// </summary>
    public abstract class ProcessResult {
        public bool IsSuccess() => this is CompleteResult;
        public bool IsCanceled() => this is CancelResult;
    }

    /// <summary>
    /// �������̌��ʃf�[�^
    /// </summary>
    public class CompleteResult : ProcessResult { }

    /// <summary>
    /// �L�����Z�����̌��ʃf�[�^
    /// </summary>
    public class CancelResult : ProcessResult {

        public readonly string message;

        public CancelResult(string message) {
            this.message = message;
        }

        public CancelResult() : this(string.Empty) { }
    }

}
