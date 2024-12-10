using System;
using UniRx;
using UnityEngine;
using TMPro;
using Sirenix.OdinInspector;
using System.Globalization;

namespace nitou.UI {

    /// <summary>
    /// <see cref="Vector2"/>�̓��͂��󂯕t���邽�߂�View�D
    /// </summary>
    public sealed class Vecto2InputFieldView : InputFieldView<Vector2> {

        [Title("View")]
        [SerializeField, Indent] private TMP_InputField _xInputField;
        [SerializeField, Indent] private TMP_InputField _yInputField;

        [Title("Settings")]
        [SerializeField, Indent] private int _decimalPlaces = 2;


        /// ----------------------------------------------------------------------------
        // LifeCycle Events

        private void Awake() {
            // ViewModel�̊Ď�
            _valueRP.Subscribe(v => ApplyValue(v)).AddTo(this);

            // View�̊Ď�
            Observable.Merge(
                _xInputField.onEndEdit.AsObservable().AsUnitObservable(),
                _yInputField.onEndEdit.AsObservable().AsUnitObservable()
            )
            .Subscribe(_ => UpdateValue())
            .AddTo(this);
        }


        /// ----------------------------------------------------------------------------
        // Private Method

        private void UpdateValue() {
            Vector2 currentValue = _valueRP.Value;
            Vector2? parsedValue = TryParseValue();

            // �p�[�X�����������ꍇ�̂�ReactiveProperty�ɔ��f
            if (parsedValue.HasValue) {
                _valueRP.Value = parsedValue.Value;
            } else {
                // �p�[�X�Ɏ��s�����ꍇ�͌��̒l���ēK�p
                ApplyValue(currentValue);
            }
        }

        /// <summary>
        /// View����l��ǂݎ��D
        /// </summary>
        private Vector2? TryParseValue() {

            // parse values
            bool xParsed = float.TryParse(_xInputField.text, NumberStyles.Float, CultureInfo.InvariantCulture, out var x);
            bool yParsed = float.TryParse(_yInputField.text, NumberStyles.Float, CultureInfo.InvariantCulture, out var y);

            // �S�Ẵp�[�X�����������ꍇ�ɂ̂ݒl��Ԃ�
            if (xParsed && yParsed) {
                return new Vector2(x, y);
            }

            // �����ꂩ�̃p�[�X�Ɏ��s�����ꍇ��null��Ԃ�
            return null;
        }

        /// <summary>
        /// View�ɒl��K�p����D
        /// </summary>
        private void ApplyValue(Vector2 value) {
            _xInputField.text = value.x.ToFloatText(_decimalPlaces);
            _yInputField.text = value.y.ToFloatText(_decimalPlaces);
        }

#if UNITY_EDITOR
        private void OnValidate() {
            _decimalPlaces = Mathf.Clamp(_decimalPlaces, 0, 5);
        }
#endif
    }
}
