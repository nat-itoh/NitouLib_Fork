using System;
using UniRx;
using UniRx.Triggers;
using UnityEngine;

namespace Project {
    public class RepetTest : MonoBehaviour {

        void Start() {

            // Z�L�[�̓��͂��ω�������ʒm����Observable
            var zKeyOnChanged = this.UpdateAsObservable()
                .Select(_ => Input.GetKey(KeyCode.Z))
                .DistinctUntilChanged()
                .Skip(1);

            // Z�L�[��1�b�ȏ㉟���ꂽ��ʒm����Observable
            var zKeyLongPressStart = zKeyOnChanged
                .Throttle(TimeSpan.FromSeconds(1))
                .Where(x => x);

            // Z�L�[�������ꂽ��ʒm����Observable
            var zKeyRelease = zKeyOnChanged.Where(x => !x);

            // 1�b�ȏ�Z�L�[������������Ă���ԁA���\�b�h�����s����
            this.UpdateAsObservable()
                .SkipUntil(zKeyLongPressStart)  // �����������܂őҋ@
                .TakeUntil(zKeyRelease)     // �L�[�������ꂽ��I��
                .RepeatUntilDestroy(this)
                .Subscribe(_ => {
                    Debug.Log("Long press state!");
                }).AddTo(this);

            var streem = new Subject<Unit>();

            // 1
            streem.ThrottleFirst(TimeSpan.FromSeconds(1f))
                .Subscribe();

            // 2



        }

    }
}
