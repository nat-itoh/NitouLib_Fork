using System;
using System.Collections.Generic;
using UnityEngine;

namespace nitou.DesignPattern.Observer {

    // Next�̒l�ɂ���Ēʒm���邩���Ȃ�����ύX����
    public class WhereObservable<T> : IObservable<T> {

        private Func<T, bool> _operation;
        private IObservable<T> _observable;

        public WhereObservable(IObservable<T> observable, Func<T, bool> operation) {
            this._operation = operation;
            this._observable = observable;
        }

        public IDisposable Subscribe(IObserver<T> observer) {
            var disposable = this._observable.Subscribe(Observer<T>.Create(
                next => {
                    // next�̒l�ɂ���āA���ɏ����𗬂����ǂ���������. operation��bool��ԋp����
                    if (this._operation(next)) observer.OnNext(next);
                },
                error => observer.OnError(error),
                () => observer.OnComplete()
            ));

            return disposable;
        }
    }

    // Next�̒l��ʂ̒l�ɕύX���� Operator
    public class SelectObservable<T1, T2> : IObservable<T2> {
        private Func<T1, T2> _operation;
        private IObservable<T1> _observable;

        public SelectObservable(IObservable<T1> observable, Func<T1, T2> operation) {
            this._operation = operation;
            this._observable = observable;
        }

        public IDisposable Subscribe(IObserver<T2> observer) {
            var disposable = this._observable.Subscribe(Observer<T1>.Create(
                next => {
                    // next�̒l��operator�ɂ���ĕʂ̒l�ɕύX����
                    var next2 = this._operation(next);
                    observer.OnNext(next2);
                },
                error => observer.OnError(error),
                () => observer.OnComplete()
            ));

            return disposable;
        }
    }

    // 1�̒l���󂯎���āAN��(0�ȏ�)�̒l�𗬂� Observable
    public class SelectManyObservable<TNext1, TNext2> : IObservable<TNext2> {
        private Func<TNext1, IObservable<TNext2>> operation;
        private IObservable<TNext1> observable;

        public SelectManyObservable(IObservable<TNext1> observable, Func<TNext1, IObservable<TNext2>> operation) {
            this.observable = observable;
            this.operation = operation;
        }

        public IDisposable Subscribe(IObserver<TNext2> observer) {
            var disposables = new List<IDisposable>();
            var disposable1 = this.observable.Subscribe(Observer<TNext1>.Create(
                next1 => {
                    // next�̒l�𗬂��ƁAobservable���A���Ă���. ������w�ǂ��Ď��֓`����
                    var disposable2 = this.operation(next1).Subscribe(Observer<TNext2>.Create(
                            next2 => observer.OnNext(next2),
                            error => observer.OnError(error),
                            () => observer.OnComplete()
                        ));
                    disposables.Add(disposable2);
                },
                error => observer.OnError(error),
                () => observer.OnComplete()
            ));
            disposables.Add(disposable1);
            return new CollectionDisposable(disposables);
        }
    }




    public static class IObservableExtension {

        public static IObservable<TNext> Where<TNext>(this IObservable<TNext> observable,
            Func<TNext, bool> operation) {
            return new WhereObservable<TNext>(observable, operation);
        }

        public static IObservable<TNext2> Select<TNext1, TNext2>(this IObservable<TNext1> observable,
            Func<TNext1, TNext2> operation) {
            return new SelectObservable<TNext1, TNext2>(observable, operation);
        }

        // �l��1�󂯎���āAIObservable�ɕϊ����� Operator
        public static IObservable<TNext2> SelectMany<TNext1, TNext2>(
            this IObservable<TNext1> observable, Func<TNext1, IObservable<TNext2>> operation) {
            return new SelectManyObservable<TNext1, TNext2>(observable, operation);
        }

        // �l��1�󂯎���āA�����̒l�ɕ������ė��� Operator
        public static IObservable<TNext2> SelectMany<TNext1, TNext2>(
            this IObservable<TNext1> observable, Func<TNext1, IEnumerable<TNext2>> operation) {
            return new SelectManyObservable<TNext1, TNext2>(observable, next1 => {
                return Observable<TNext2>.Create(observer => {
                    var next2enumerable = operation(next1);

                    foreach (var next2 in next2enumerable) {
                        observer.OnNext(next2);
                    }

                    return new EmptyDisposable();
                });
            });
        }
    }


}
