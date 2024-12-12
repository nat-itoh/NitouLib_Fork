using System;
using UnityEngine;
using UniRx;
using UniRx.Triggers;

namespace Project {
}

public class ObservableCollider : MonoBehaviour {

    private void Start() {
        var targetObservable =
            // IObservable<Collider>�^
            this.OnCollisionEnterAsObservable()
            // IObservable<IObservable<Vector3>>�^
            // �i��Collider����IObservable<Vector3>������Ă���j
            .Select(collider => CreatePositionObservable(collider.gameObject));

        targetObservable
            .Switch()
            .Subscribe(targetPos => {
                    // �Ώۂ�ǐ�
                    var newPosition = Vector3.Lerp(transform.position, targetPos, Time.deltaTime);
                transform.position = newPosition;
            })
            .AddTo(this);
    }

    // 
    private IObservable<Vector3> CreatePositionObservable(GameObject target) {
        return target.UpdateAsObservable()  // ���t���[���Ď�
            .Select(_ => target.transform.position);
    }
}
