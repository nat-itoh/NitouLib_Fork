using System.Threading;
using Cysharp.Threading.Tasks;

// [REF]
//  qiita: ���̃N���X�������������܂ő҂� - UniTaskCompletionSource�̎g�p�� https://qiita.com/watabe_h/items/e3ccd749142cb37616e2

namespace nitou {

	/// <summary>
	/// 
	/// </summary>
    public interface IReadOnlyAsyncStorage<T> {

        UniTask<T> GetAsync(CancellationToken token = default);
    }

	/// <summary>
	/// 
	/// </summary>
    public sealed class AsyncStorage<T> : IReadOnlyAsyncStorage<T> {

		private readonly UniTaskCompletionSource<T> _completionSource = new();

		/// <summary>
		/// 
		/// </summary>
		public async UniTask<T> GetAsync(CancellationToken cancellationToken = default) {
			return await _completionSource.Task.AttachExternalCancellation(cancellationToken);
		}

		/// <summary>
		/// �l��ݒ肷��D
		/// </summary>
		public bool TrySet(T content) {
			return _completionSource.TrySetResult(content);
		}
	}

}
