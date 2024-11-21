using System;
using System.Collections;
using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using System.Threading;
using UniRx;

namespace nitou {

    /// <summary>
    /// ��莞�Ԍo�߂����v�f���폜����R���N�V����
    /// </summary>
    public class TimedCollection<T> : IEnumerable<T>, IDisposable {

        /// <summary>
        /// �i�[�p�̃f�[�^�N���X
        /// </summary>
        private class TimedItem {
            public T Item { get; }
            public DateTime ExpirationTime { get; }

            public TimedItem(T item, DateTime expirationTime) {
                Item = item;
                ExpirationTime = expirationTime;
            }
        }

        private readonly List<TimedItem> _items = new();
        private readonly TimeSpan _timeout;

        // ���������p
        private bool _isProcessing = false;
        private readonly Subject<T> _onItemRemoved = new();
        private CancellationTokenSource _cts;

        /// <summary>
        /// ���݂̗v�f��
        /// </summary>
        public int Count => _items.Count;

        /// <summary>
        /// �f�[�^����菜�����Ƃ��̃C�x���g�ʒm
        /// </summary>
        public IObservable<T> OnItemRemoved => _onItemRemoved;


        /// ----------------------------------------------------------------------------
        // Public Method

        /// <summary>
        /// Constructor.
        /// </summary>
        public TimedCollection(TimeSpan timeout) {
            _timeout = timeout;
            _cts = new CancellationTokenSource();
        }
        
        /// <summary>
        /// �I������
        /// </summary>
        public void Dispose() {
            _cts.Cancel();  // �^�X�N���L�����Z��
            _cts.Dispose();
            _onItemRemoved.OnCompleted(); // �X�g���[���̊�����ʒm
            _onItemRemoved.Dispose(); // ���\�[�X�̉��
        }


        /// ----------------------------------------------------------------------------
        // Private Method (�R���N�V��������)

        /// <summary>
        /// Add item.
        /// </summary>
        public void Add(T item) {
            var expirationTime = DateTime.UtcNow + _timeout;
            _items.Add(new TimedItem(item, expirationTime));

            if (!_isProcessing) {
                _isProcessing = true;
                RemoveExpiredItemsAsync(_cts.Token).Forget();
            }
        }

        /// <summary>
        /// Remove item.
        /// </summary>
        public bool Remove(T item) {
            var timedItem = _items.Find(t => EqualityComparer<T>.Default.Equals(t.Item, item));
            if (timedItem != null) {
                _items.Remove(timedItem);
                _onItemRemoved.OnNext(timedItem.Item); // �A�C�e�����O�̒ʒm
                return true;
            }
            return false;
        }

        public IEnumerator<T> GetEnumerator() {
            foreach (var timedItem in _items) {
                yield return timedItem.Item;
            }
        }

        IEnumerator IEnumerable.GetEnumerator() {
            return GetEnumerator();
        }


        /// ----------------------------------------------------------------------------
        // Private Method

        private async UniTaskVoid RemoveExpiredItemsAsync(CancellationToken cancellationToken) {
            try {
                while (_items.Count > 0) {
                    await UniTask.Delay(TimeSpan.FromSeconds(1), cancellationToken: cancellationToken);

                    var now = DateTime.UtcNow;
                    var expiredItems = _items.FindAll(item => item.ExpirationTime <= now);
                    foreach (var expiredItem in expiredItems) {
                        _items.Remove(expiredItem);
                        _onItemRemoved.OnNext(expiredItem.Item); // �A�C�e�����O�̒ʒm
                    }
                }
            } catch (OperationCanceledException) {
                // �^�X�N���L�����Z�����ꂽ�ꍇ�̏���
            } finally {
                _isProcessing = false;
            }
        }
    }
}