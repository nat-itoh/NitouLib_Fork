using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;
using System.Threading;
using Cysharp.Threading.Tasks;
using UniRx;
using nitou;
using nitou.UI;
using UniRx.Diagnostics;

// [REF]
//  Hatena: �I�y���[�^��Switch�ɂ��� https://shitakami.hateblo.jp/entry/2021/08/22/204549
//  qiita: UniTask��CancellationToken���w�肵�Ȃ���ToObservable���郁�� https://qiita.com/toRisouP/items/8ec18d73d9e8c5169587

namespace Project {

    public class ObservableSwitchTest : MonoBehaviour {

        [SerializeField] Image _image = null;
        [SerializeField] Sprite _defaultSprite; // �f�t�H���g�摜


        [Space]
        [SerializeField] TextMeshProUGUI _indexText;
        [SerializeField] Button _previousButton;
        [SerializeField] Button _nextButton;


        private readonly static string[] ResourceKeys = new string[]{
            "icon_a",
            "icon_b",
            "icon_c",
            "icon_d",
        };

        private ReactiveProperty<int> _currentIndex = new (0);


        private void Start() {

            _currentIndex.SubscribeToTextMeshPro(_indexText, index => $"{index}").AddTo(this);

            // �O��{�^���̐ݒ�
            _previousButton.onClick.AddListener(() => MoveIndex(-1));
            _nextButton.onClick.AddListener(() => MoveIndex(1));

            _currentIndex.
                DistinctUntilChanged()
                .Do(_ => ResetImageSprite())
                .Delay(TimeSpan.FromSeconds(1f))
                .Select(index => ResourceKeys[index])
                .Select(path => ObservableConverter.FromUniTask(ct => LoadSpriteAsync(path, ct)))
                // �ŐV��IObservable�ɐ؂�ւ���
                .Switch()
                .Subscribe(sprite => _image.sprite = sprite)
                .AddTo(this);
        }

        private void OnDestroy() {
            if(_image != null) {
                ResetImageSprite();
            }
        }


        // �X�v���C�g�ǂݍ���
        private async UniTask<Sprite> LoadSpriteAsync(string resourcePath, CancellationToken token = default) {
            Debug_.Log($"Load resource from :{resourcePath}", Colors.White);
            
            var sprite = await Resources.LoadAsync<Sprite>(resourcePath) as Sprite;

            // ����3�b��������Ƃ���
            await UniTask.WaitForSeconds(2f, cancellationToken: token);
            return sprite;
        }

        private void ResetImageSprite() {
            // ���݂̃��\�[�X�����
            if (_image.sprite != null) {
                Resources.UnloadAsset(_image.sprite);
                _image.sprite = null;
            }

            // �f�t�H���g�摜��ݒ�
            _image.sprite = _defaultSprite;
        }


        // �C���f�b�N�X���ړ�
        private void MoveIndex(int direction) {
            int newIndex = Mathf.Clamp(_currentIndex.Value + direction, 0, ResourceKeys.Length - 1);
            _currentIndex.Value = newIndex;
        }
    }
}
