using System.Threading;
using Cysharp.Threading.Tasks;

namespace Demo.Sequencer {

    /// <summary>
    /// 
    /// </summary>
    public interface ISequence{

        /// <summary>
        /// �V�[�P���X���s�D
        /// </summary>
        UniTask Run(CancellationToken token = default);
    }
}
