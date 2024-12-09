using System;
using Cysharp.Threading.Tasks;
using UniRx;

namespace nitou.GameSystem {

    public enum ProcessState {
        NotStarted,
        Running,
        Paused,
        Cancelled,
        Completed
    }


    /// <summary>
    /// 
    /// </summary>
    public interface IProcess : IDisposable{

        /// <summary>
        /// ���݂̃X�e�[�g�D
        /// </summary>
        //public IReadOnlyReactiveProperty<ProcessState> State { get; }

        /// <summary>
        /// �I�����̒ʒm�D
        /// </summary>
        public UniTask<ProcessResult> ProcessFinished { get; }

        /// <summary>
        /// �J�n����D
        /// </summary>
        public void Run();
        
        /// <summary>
        /// �|�[�Y����D
        /// </summary>
        public void Pause();

        /// <summary>
        /// �|�[�Y��������D
        /// </summary>
        public void UnPause();

        /// <summary>
        /// �L�����Z������D
        /// </summary>
        public void Cancel(CancelResult cancelResult = null);
    }

}
