using System;
using System.Collections;
using System.Collections.Generic;
using UniRx;

// [REF]
//  github: ReactiveCollection.cs https://github.com/neuecc/UniRx/blob/master/Assets/Plugins/UniRx/Scripts/UnityEngineBridge/ReactiveCollection.cs#L40

namespace nitou {

    /// <summary>
    /// �z��̗v�f�̕ύX��ړ������A�N�e�B�u�ɊĎ��ł��� ReactiveArray �N���X
    /// </summary>
    public sealed class ReactiveArray<T> : IDisposable, IEnumerable<T>, IEnumerable {

        private readonly T[] _items;

        [NonSerialized] bool isDisposed = false;

        // Streem
        [NonSerialized] Subject<CollectionReplaceEvent<T>> _collectionReplace = null;
        [NonSerialized] Subject<CollectionMoveEvent<T>> _collectionMove = null;

        /// <summary>
        /// �C���f�N�T
        /// </summary>
        public T this[int index] {
            get => GetItem(index);
            set => SetItem(index, value);
        }

        /// <summary>
        /// �v�f���D
        /// </summary>
        public int Length => _items.Length;


        /// ----------------------------------------------------------------------------
        // Public Method

        /// <summary>
        /// Constructor.
        /// </summary>
        public ReactiveArray(int length) {
            _items = new T[length];
        }

        /// <summary>
        /// Constructor.
        /// </summary>
        public ReactiveArray(IList<T> list) {
            if (list is null) throw new ArgumentNullException(nameof(list));

            _items = new T[list.Count];
            for (int i = 0; i < list.Count; i++) {
                _items[i] = list[i];
            }
        }

        /// <summary>
        /// �I������
        /// </summary>
        public void Dispose() {
            if (!isDisposed) {
                SubjectUtil.DisposeSubject(ref _collectionReplace);
                SubjectUtil.DisposeSubject(ref _collectionMove);

                isDisposed = true;
            }
        }

        /// <summary>
        /// �w��C���f�b�N�X�̗v�f���擾����D
        /// </summary>
        public T GetItem(int index) {
            if (isDisposed) throw new ObjectDisposedException(nameof(ReactiveArray<T>));
            if (index.IsOutRange(_items)) throw new ArgumentOutOfRangeException(nameof(index));
            return _items[index];
        }

        /// <summary>
        /// �w��C���f�b�N�X�ɗv�f��ݒ肷��D
        /// </summary>
        public void SetItem(int index, T value) {
            if (isDisposed) throw new ObjectDisposedException(nameof(ReactiveArray<T>));
            if (index.IsOutRange(_items)) throw new ArgumentOutOfRangeException(nameof(index));

            var oldValue = _items[index];
            _items[index] = value;

            // �C�x���g�ʒm
            _collectionReplace?.OnNext(new CollectionReplaceEvent<T>(index, oldValue, value));
        }

        /// <summary>
        /// �v�f���ړ�����D
        /// </summary>
        public void Move(int oldIndex, int newIndex) {
            if (isDisposed) throw new ObjectDisposedException(nameof(ReactiveArray<T>));
            if (oldIndex.IsOutRange(_items) || newIndex.IsOutRange(_items)) {
                throw new ArgumentOutOfRangeException();
            }

            var item = _items[oldIndex];
            // �z����̗v�f���V�t�g
            if (oldIndex < newIndex) {
                for (int i = oldIndex; i < newIndex; i++) {
                    _items[i] = _items[i + 1];
                }
            } else {
                for (int i = oldIndex; i > newIndex; i--) {
                    _items[i] = _items[i - 1];
                }
            }

            _items[newIndex] = item;

            // Move �C�x���g�𔭍s
            _collectionMove?.OnNext(new CollectionMoveEvent<T>(oldIndex, newIndex, item));
        }


        /// ----------------------------------------------------------------------------
        // Public Method (Event Streem)

        /// <summary>
        /// 
        /// </summary>
        public IObservable<CollectionReplaceEvent<T>> ObserveReplace() {
            if (isDisposed) return Observable.Empty<CollectionReplaceEvent<T>>();
            return _collectionReplace ?? (_collectionReplace = new Subject<CollectionReplaceEvent<T>>());
        }

        /// <summary>
        /// 
        /// </summary>
        public IObservable<CollectionMoveEvent<T>> ObserveMove() {
            if (isDisposed) return Observable.Empty<CollectionMoveEvent<T>>();
            return _collectionMove ?? (_collectionMove = new Subject<CollectionMoveEvent<T>>());
        }


        /// ----------------------------------------------------------------------------
        // Public Method (Enumerable)

        /// <summary>
        /// �z��̗񋓂��T�|�[�g���邽�߂� IEnumerable<T> �̎���
        /// </summary>
        public IEnumerator<T> GetEnumerator() {
            if (isDisposed) throw new ObjectDisposedException(nameof(ReactiveArray<T>));
            return ((IEnumerable<T>)_items).GetEnumerator();
        }

        /// <summary>
        /// ��W�F�l���b�N IEnumerable �̎���
        /// </summary>
        IEnumerator IEnumerable.GetEnumerator() {
            return GetEnumerator();
        }
    }
}
