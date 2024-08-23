using System;
using System.Collections;
using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using System.Threading;
using UniRx;

public class TimedCollection<T> : IEnumerable<T>, IDisposable {

    private class TimedItem {
        public T Item { get; }
        public DateTime ExpirationTime { get; }

        public TimedItem(T item, DateTime expirationTime) {
            Item = item;
            ExpirationTime = expirationTime;
        }
    }

    private readonly List<TimedItem> _items = new ();
    private readonly TimeSpan _timeout;

    // 
    private bool _isProcessing = false;
    private CancellationTokenSource _cts;

    /// <summary>
    /// �f�[�^����菜�����Ƃ��̃C�x���g�ʒm
    /// </summary>
    public IObservable<T> OnItemRemoved => _onItemRemoved;
    private readonly Subject<T> _onItemRemoved = new ();

    /// ----------------------------------------------------------------------------
        // Public Method


    public TimedCollection(TimeSpan timeout) {
        _timeout = timeout;
        _cts = new CancellationTokenSource();
    }

    public void Add(T item) {
        var expirationTime = DateTime.UtcNow + _timeout;
        _items.Add(new TimedItem(item, expirationTime));

        if (!_isProcessing) {
            _isProcessing = true;
            RemoveExpiredItemsAsync(_cts.Token).Forget();
        }
    }

    public bool Remove(T item) {
        var timedItem = _items.Find(t => EqualityComparer<T>.Default.Equals(t.Item, item));
        if (timedItem != null) {
            _items.Remove(timedItem);
            _onItemRemoved.OnNext(timedItem.Item); // �A�C�e�����O�̒ʒm
            return true;
        }
        return false;
    }

    public int Count => _items.Count;

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

    public IEnumerator<T> GetEnumerator() {
        foreach (var timedItem in _items) {
            yield return timedItem.Item;
        }
    }

    IEnumerator IEnumerable.GetEnumerator() {
        return GetEnumerator();
    }

    public void Dispose() {
        _cts.Cancel();  // �^�X�N���L�����Z��
        _cts.Dispose();
        _onItemRemoved.OnCompleted(); // �X�g���[���̊�����ʒm
        _onItemRemoved.Dispose(); // ���\�[�X�̉��
    }
}
