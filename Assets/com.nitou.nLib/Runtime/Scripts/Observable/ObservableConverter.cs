using System;
using System.Threading;
using Cysharp.Threading.Tasks;
using UniRx;
using UnityEngine;

// [REF]
//  qiita: UniTask��CancellationToken���w�肵�Ȃ���ToObservable���郁�� https://qiita.com/toRisouP/items/8ec18d73d9e8c5169587
//  _: �񓯊��R�[���o�b�N�֐��p�^�[�� https://developer.aiming-inc.com/csharp/unity-csharp-async-callback-patterns/
//  _: UniRx�ŉۑ肾����Rx��async/await�̘A�g��R3�ł͊y�ɂȂ����� https://developer.aiming-inc.com/csharp/post-10773/

namespace nitou {

    public static class ObservableConverter {

        /// <summary>
        /// UniTask.ToObservable() ��<see cref="CancellationToken"/>���w�肵�čs�����߂̃��\�b�h�D
        /// </summary>
        public static IObservable<T> FromUniTask<T>(Func<CancellationToken, UniTask<T>> func) {

            return Observable.Create<T>(observer => {

                // [NOTE] �O���ɓn��cd��UniTask���~������.
                var cd = new CancellationDisposable();

                UniTask.Void(async () => {
                    try {
                        observer.OnNext(await func(cd.Token));
                        observer.OnCompleted();
                    } catch (Exception e) {
                        observer.OnError(e);
                    }
                });
                return cd;
            });
        }

        /// <summary>
        /// UniTask.ToObservable() ��<see cref="CancellationToken"/>���w�肵�čs�����߂̃��\�b�h�D
        /// </summary>
        public static IObservable<Unit> FromUniTask(Func<CancellationToken, UniTask> func) {

            return Observable.Create<Unit>(observer => {

                // [NOTE] �O���ɓn��cd��UniTask���~������.
                var cd = new CancellationDisposable();

                UniTask.Void(async () => {
                    try {
                        await func(cd.Token);
                        observer.OnNext(Unit.Default);
                        observer.OnCompleted();
                    } catch (Exception e) {
                        observer.OnError(e);
                    }
                });
                return cd;
            });

        }

    }
}
