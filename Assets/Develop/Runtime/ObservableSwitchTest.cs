using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;
using System.Threading;
using Cysharp.Threading.Tasks;
using UniRx;
using nitou;

// [REF]
//  Hatena: �I�y���[�^��Switch�ɂ��� https://shitakami.hateblo.jp/entry/2021/08/22/204549
//  qiita: UniTask��CancellationToken���w�肵�Ȃ���ToObservable���郁�� https://qiita.com/toRisouP/items/8ec18d73d9e8c5169587

namespace Project {

    public class ObservableSwitchTest : MonoBehaviour {

        [SerializeField] private TextMeshProUGUI _logText = null;
        [SerializeField] private TMP_InputField _inputField = null;
        [SerializeField] private Image _image = null;

        private void Start() {
            _inputField.OnValueChangedAsObservable()
                // �񓯊��ǂݍ��ݏ��������s (��CancellationDisposable��Ԃ�)
                .Select(path => ObservableConverter.FromUniTask(ct => LoadSpriteAsync(path, ct)))
                // �ŐV��IObservable�ɐ؂�ւ���
                .Switch()
                .Subscribe(sprite => _image.sprite = sprite)
                .AddTo(this);
        }

        // �X�v���C�g�ǂݍ���
        private async UniTask<Sprite> LoadSpriteAsync(string resourcePath, CancellationToken token = default) {
            var sprite = await Resources.LoadAsync<Sprite>(resourcePath) as Sprite;
            
            // ����3�b��������Ƃ���
            await UniTask.WaitForSeconds(2f, cancellationToken: token);
            return sprite;
        }
    }
}
