using System;
using System.Threading;
using System.Threading.Tasks;
using Cysharp.Threading.Tasks;
using UniRx;
using UnityEngine;


public class Actor {
    // �U����
    public ReactiveProperty<int> AttackRP { get; } = new(0);
}

public class ActorSelectionController {
    // �I�𒆂̃A�N�^�[
    public ReactiveProperty<Actor> CurrentActorRP { get; } = new(null);
}


public class TestMono : MonoBehaviour {

    private ActorSelectionController _actorSelectionController = new();

    private void Start() {

        var observable = Observable.Create<char>(observer => {
            var cd = new CancellationDisposable();

            // �񓯊����� (���L���v�`�����͂���)
            Task.Run(async () => {
                for (var i = 0; i < 26; i++) {
                    await Task.Delay(TimeSpan.FromSeconds(1), cancellationToken: cd.Token);
                    observer.OnNext((char)('A'+i));
                }
                observer.OnCompleted();
            }, cancellationToken: cd.Token);
            return cd;
        });


        observable.Subscribe(x => Debug.Log(x)).AddTo(this);
    }


    private IObservable<int> CreateCountObservable(int count) {

        if (count <= 0) return Observable.Empty<int>();

        return Observable.CreateWithState<int, int>(state: count,
            (maxCount, observer) => {
                for (int i =0; i<maxCount; i++) {
                    observer.OnNext(i);
                }

                observer.OnCompleted();
                return Disposable.Empty;
            });
    }

}
