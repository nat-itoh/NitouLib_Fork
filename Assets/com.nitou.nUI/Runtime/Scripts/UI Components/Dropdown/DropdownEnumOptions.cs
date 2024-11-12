using System;
using System.Linq;
using UniRx;
using UnityEngine;
using TMPro;

namespace nitou.UI {

    /// <summary>
    /// 
    /// </summary>
    [DisallowMultipleComponent]
    [RequireComponent(typeof(TMP_Dropdown))]
    public abstract class DropdownEnumOptions<TEnum> : MonoBehaviour, IDataHolder<TEnum>
        where TEnum : Enum {

        private TMP_Dropdown _dropdown;
        private ReactiveProperty<TEnum> _currentRP = new();

        /// <summary>
        /// �l�̕ω���ʒm����Observable
        /// </summary>
        public IObservable<TEnum> OnValueChanged => _currentRP;

        // �S�v�f
        private static readonly TEnum[] enumValues = (TEnum[])Enum.GetValues(typeof(TEnum));

        private static int GetEnumIndex(TEnum type) {
            return Array.IndexOf(enumValues, type);
        }


        /// ----------------------------------------------------------------------------
        // LifeCycle Events

        protected void Start() {
            Setup();

            // View�̍X�V
            _dropdown.onValueChanged.AsObservable()
                .Subscribe(index => {
                    if (index.IsInRange(enumValues))
                        _currentRP.Value = enumValues[index];
                    else
                        Setup();
                })
                .AddTo(this);

            // RP�̍X�V
            _currentRP
                .Subscribe(type => {
                    _dropdown.value = GetEnumIndex(type);
                    _dropdown.RefreshShownValue();
                }).AddTo(this);
        }

        private void OnDestroy() {
            _currentRP?.Dispose();
        }

        private void OnValidate() {
            if (_dropdown is null)
                _dropdown = GetComponent<TMP_Dropdown>();
        }


        /// ----------------------------------------------------------------------------
        // Private Method

        /// <summary>
        /// �Q�b�^�D
        /// </summary>
        public TEnum GetValue() {
            return _currentRP.Value;
        }

        /// <summary>
        /// �Z�b�^�D
        /// </summary>
        public void SetValue(TEnum type) {
            _currentRP.Value = type;
        }

        /// <summary>
        /// 
        /// </summary>
        private void Setup() {
            OnValidate();

            // Enum�̖��O���X�g���擾����Dropdown�̃I�v�V�����ɐݒ�
            _dropdown.options.Clear();
            _dropdown.options.AddRange(enumValues.Select(name => new TMP_Dropdown.OptionData(name.ToString())));

            // �����I�����ŏ��̍��ڂɐݒ�
            _dropdown.value = GetEnumIndex(_currentRP.Value);
            _dropdown.RefreshShownValue();
        }
    }
}
