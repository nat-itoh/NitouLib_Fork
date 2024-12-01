using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using JetBrains.Annotations;

// [�Q�l]
//  �R�K�l�u���O: Dictionary��JsonUtility�ŕϊ��ł���悤�ɂ���N���X https://baba-s.hatenablog.com/entry/2020/11/20/080300

namespace nitou.Serialization {

    /// <summary>
    /// 
    /// </summary>
    [Serializable]
    public class JsonDictionary<TKey, TValue> : ISerializationCallbackReceiver {
                
        [UsedImplicitly] 
        [SerializeField] KeyValuePair[] dictionary = default;

        private Dictionary<TKey, TValue> _dictionary;

        public Dictionary<TKey, TValue> Dictionary => _dictionary;


        /// ----------------------------------------------------------------------------
        // Public Method

        public JsonDictionary(Dictionary<TKey, TValue> dictionary) {
            _dictionary = dictionary;
        }

        void ISerializationCallbackReceiver.OnBeforeSerialize() {
            dictionary = _dictionary
                    .Select(x => new KeyValuePair(x.Key, x.Value))
                    .ToArray();
        }

        void ISerializationCallbackReceiver.OnAfterDeserialize() {
            _dictionary = dictionary.ToDictionary(x => x.Key, x => x.Value);
            dictionary = null;
        }


        /// ----------------------------------------------------------------------------
        // Inner class 

        [Serializable]
        private struct KeyValuePair {
            [SerializeField] [UsedImplicitly] private TKey key;
            [SerializeField] [UsedImplicitly] private TValue value;

            public TKey Key => key;
            public TValue Value => value;

            public KeyValuePair(TKey key, TValue value) {
                this.key = key;
                this.value = value;
            }
        }
    }
}