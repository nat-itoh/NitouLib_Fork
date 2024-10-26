using System;
using System.Collections.Generic;
using UnityEngine;

// [�Q�l]
//  qiita: ���Ȃ��痝������UniRx https://qiita.com/mattak/items/106dfd0974653aa06fbc#5-observable

namespace nitou.DesignPattern.Observer {

    // �Ď���
    public interface IObserver<T> {

        // �f�[�^������
        void OnNext(T value);

        // �G���[������
        void OnError(Exception error);

        // �f�[�^�͂������Ȃ�
        void OnComplete();
    }

    // �Ď��\�ł��邱�Ƃ�����
    public interface IObservable<T> {

        // �Ď��҂��w�ǂ���
        IDisposable Subscribe(IObserver<T> observer);
    }


    // �Ď��Ώ�
    public interface ISubject<T> : IObserver<T>, IObservable<T> { }


    /// <summary>
    /// 
    /// </summary>
    public class Subject<T> : ISubject<T> {

        private List<IObserver<T>> observers = new();

        #region IObserver
        public void OnNext(T next) {
            foreach (var observer in this.observers) {
                observer.OnNext(next);
            }
        }

        public void OnError(Exception error) {
            foreach (var observer in this.observers) {
                observer.OnError(error);
            }

            this.observers.Clear();
        }

        public void OnComplete() {
            foreach (var observer in this.observers) {
                observer.OnComplete();
            }

            this.observers.Clear();
        }
        #endregion

        #region IObservable
        public IDisposable Subscribe(IObserver<T> observer) {
            this.observers.Add(observer);
            // �w�ǊǗ���class��Ԃ�
            return new Subscription(this, observer);
        }
        #endregion

        private void Unsubscribe(IObserver<T> observer) {
            this.observers.Remove(observer);
        }


        // �w�ǊǗ�������class. Dispose()���ĂԂ��Ƃōw�ǂ���߂�
        class Subscription : IDisposable {

            private IObserver<T> _observer;
            private Subject<T> _subject;

            public Subscription(Subject<T> subject, IObserver<T> observer) {
                this._subject = subject;
                this._observer = observer;
            }

            public void Dispose() {
                this._subject.Unsubscribe(this._observer);
            }
        }
    }


    public class Observable<T> : IObservable<T> {

        // �������e���f���Q�[�g�ŕێ����邽�߁CCold�ȐU�镑��������
        private Func<IObserver<T>, IDisposable> creator;


        private Observable(Func<IObserver<T>, IDisposable> creator) {
            this.creator = creator;
        }

        public IDisposable Subscribe(IObserver<T> observer) {
            // Subscribe�����u�ԂɊ֐������s����̂�����
            return this.creator(observer);
        }

        // Observable�𒼐ړn�������Ȃ����߁ACreate���\�b�h������Ă���.
        public static IObservable<T> Create(Func<IObserver<T>, IDisposable> creator) {
            return new Observable<T>(creator);
        }
    }


    public class Observer<T> : IObserver<T> {

        private Action<T> _next;
        private Action<Exception> _error;
        private Action _complete;


        private Observer(Action<T> next, Action<Exception> error, Action complete) {
            _next = next;
            _error = error;
            _complete = complete;
        }


        public void OnNext(T value) {
            _next?.Invoke(value);
        }

        public void OnError(Exception error) {
            _error?.Invoke(error);
        }

        public void OnComplete() {
            _complete?.Invoke();
        }


        public static IObserver<T> Create(Action<T> next, Action<Exception> error, Action complete) {
            return new Observer<T>(next, error, complete);
        }
    }


    // �w�ǉ���������肪�Ȃ��Ƃ��ɕԂ� Disposable
    public class EmptyDisposable : IDisposable {
        public void Dispose() { }
    }

    // �����̍u�ǂ������؂�ɉ������邽�߂� Disposable
    public class CollectionDisposable : IDisposable {
        
        private IList<IDisposable> _disposables;

        public CollectionDisposable(IList<IDisposable> disposables) {
            this._disposables = disposables;
        }

        public void Dispose() {
            foreach (var disposable in this._disposables) {
                disposable.Dispose();
            }
        }
    }





    namespace Demo {

        internal class TestMain {

            public void Main() {

                var observable = Observable<string>.Create(observer => {

                    // �l�^���񓚏o�����爬���Ē�
                    Debug.Log("�l�^���𓀂��܂�");
                    observer.OnNext("�Ԃ�");
                    observer.OnComplete();
                    return new EmptyDisposable();
                });

            }


        }


    }

}
