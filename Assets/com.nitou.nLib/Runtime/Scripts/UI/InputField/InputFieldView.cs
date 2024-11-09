using System;
using UniRx;
using UnityEngine;
using TMPro;
using Sirenix.OdinInspector;

namespace nitou.UI{

    public abstract class InputFieldView<T> : MonoBehaviour, IDataHolder<T>{

        // [NOTE] ��̓I�ȃR���|�[�l���g��RP�̕R�Â��͔h���N���X���ōs���D


        protected readonly ReactiveProperty<T> _valueRP = new();

        /// <summary>
        /// �l���X�V���ꂽ�Ƃ��ɒʒm����Observable�D
        /// </summary>
        public IObservable<T> OnValueChanged => _valueRP;


        /// ----------------------------------------------------------------------------
        // LifeCycle Events

        protected virtual void OnDestroy() {
            _valueRP.Dispose();
        }


        /// ----------------------------------------------------------------------------
        // Protected Method

        public virtual T GetValue() {
            return _valueRP.Value;
        }

        public virtual void SetValue(T newValue) {
            _valueRP.Value = newValue;
        }

        public virtual void ResetValue() {
            _valueRP.Value = default(T);
        }
    }
}
