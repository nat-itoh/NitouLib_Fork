using System;
using System.Linq;
using System.Collections.Generic;
using UnityEngine;

// [�Q�l]
//  qiita: Dictionary�̊g�����\�b�h 36�I https://qiita.com/soi/items/6ce0e0ddefdd062c026a
//  �R�K�l�u���O: Dictionary��foreach�Ŏg�����̋L�q���ȗ�������Deconstruction https://baba-s.hatenablog.com/entry/2019/09/03/231000

namespace nitou {

    /// <summary>
    /// <see cref="Dictionary{TKey, TValue}"/>�^�̊�{�I�Ȋg�����\�b�h�W
    /// </summary>
    public static partial class DictionaryExtensions {

        /// <summary>
        /// �f�R���X�g���N�^�D
        /// </summary>
        public static void Deconstruct<TKey, TValue>(this KeyValuePair<TKey, TValue> self, out TKey key,out TValue value) {
            key = self.Key;
            value = self.Value;
        }


        /// ----------------------------------------------------------------------------
        // �v�f�̒ǉ�

        /// <summary>
        /// <see cref="KeyValuePair{TKey, TValue}"/>�Ƃ��ėv�f��ǉ�����g�����\�b�h
        /// </summary>
        public static void Add<TKey, TValue>(this IDictionary<TKey, TValue> dict, KeyValuePair<TKey, TValue> pair)
            => dict.Add(pair.Key, pair.Value);

        /// <summary>
        /// <see cref="KeyValuePair{TKey, TValue}"/>�Ƃ��ĕ����̗v�f��ǉ�����g�����\�b�h
        /// </summary>
        public static void AddRange<TKey, TValue>(this IDictionary<TKey, TValue> dict, IEnumerable<KeyValuePair<TKey, TValue>> pairs) {
            foreach (var kv in pairs) {
                dict.Add(kv);
            }
        }

        /// <summary>
        /// �L�[���܂܂�Ă��Ȃ��ꍇ�̂ݗv�f��ǉ�����g�����\�b�h
        /// </summary>
        public static bool TryAdd<TKey, TValue>(this IDictionary<TKey, TValue> dict, TKey key, TValue value) {
            if (!dict.ContainsKey(key)) {
                dict.Add(key, value);
                return true;
            }

            return false;
        }

        /// <summary>
        /// �L�[���܂܂�Ă��Ȃ��ꍇ�̂ݗv�f��ǉ�����g�����\�b�h
        /// </summary>
        public static bool TryAdd<TKey, TValue>(this IDictionary<TKey, TValue> dict, TKey key, Func<TKey, TValue> valueFactory) {
            if (!dict.ContainsKey(key)) {
                dict.Add(key, valueFactory(key));
                return true;
            }

            return false;
        }

        /// <summary>
        /// �L�[���܂܂�Ă��Ȃ��ꍇ�ɐV�K�v�f��ǉ�����g�����\�b�h
        /// </summary>
        public static bool TryAddNew<TKey, TValue>(this IDictionary<TKey, TValue> dict, TKey key) where TValue : new() 
            => dict.TryAdd(key, _ => new TValue());

        /// <summary>
        /// �L�[���܂܂�Ă��Ȃ��ꍇ�Ƀf�t�H���g�l��ǉ�����g�����\�b�h
        /// </summary>
        public static bool TryAddDefault<TKey, TValue>(this IDictionary<TKey, TValue> dict, TKey key)
            => dict.TryAdd(key, default(TValue));


        /// ----------------------------------------------------------------------------
        // �v�f�̍폜

        /// <summary>
        /// value���w�肵�ėv�f���폜����g�����\�b�h
        /// </summary>
        public static void RemoveByValue<TKey, TValue>(this IDictionary<TKey, TValue> dict, TValue value) {
            var removeKeys = dict
                .Where(x => EqualityComparer<TValue>.Default.Equals(x.Value, value))
                .Select(x => x.Key)
                .ToArray();

            foreach (var key in removeKeys) {
                dict.Remove(key);
            }
        }


        /// ----------------------------------------------------------------------------
        // �v�f�̎擾

        /// <summary>
        /// �w�肵���L�[�i�[���ꂢ��ꍇ�͂��̒l�C�Ȃ���΃f�t�H���g�l���擾����
        /// </summary>
        public static TValue GetValueOrDefault<TKey, TValue>(this IDictionary<TKey, TValue> self, TKey key) {
            return self.TryGetValue(key, out TValue result) ? result : default;
        }

        public static TValue GetValueOrAdd<TKey, TValue>(this IDictionary<TKey, TValue> dict, TKey key, TValue value) {
            dict.TryAdd(key, value);
            return dict[key];
        }

        public static TValue GetValueOrAdd<TKey, TValue>(this IDictionary<TKey, TValue> dict, TKey key, Func<TKey, TValue> valueFactory) {
            dict.TryAdd(key, valueFactory);
            return dict[key];
        }

        /// <summary>
        /// �w�肵���L�[�i�[���ꂢ��ꍇ�͂��̒l�C�Ȃ���΃f�t�H���g�l��ǉ����Ď擾����g�����\�b�h
        /// </summary>
        public static TValue GetValueOrAddNew<TKey, TValue>(this IDictionary<TKey, TValue> dict, TKey key) where TValue : new() {
            dict.TryAddNew(key);
            return dict[key];
        }

        /// <summary>
        /// �L�[���܂܂�Ă��Ȃ��ꍇ�Ƀf�t�H���g�l��ǉ����Ď擾����g�����\�b�h
        /// </summary>
        public static TValue GetValueOrAddDefault<TKey, TValue>(this IDictionary<TKey, TValue> dict, TKey key) {
            dict.TryAddDefault(key);
            return dict[key];
        }

        
        /// ----------------------------------------------------------------------------
        // ���̑�

        /// <summary>
        /// �w�肳�ꂽ�L�[���i�[����Ă���ꍇ��action���Ăяo���g�����\�b�h
        /// </summary>
        public static void SafeCall<TKey, TValue>(this IDictionary<TKey, TValue> self, TKey key, Action<TValue> action) {
            if (!self.ContainsKey(key)) {
                return;
            }
            action(self[key]);
        }




        /// ----------------------------------------------------------------------------
        #region Demo

        /*

        private static Dictionary<string, int> CreateSourceDictionary()
        => new Dictionary<string, int> {
            ["A"] = 10,
            ["B"] = 20,
            ["C"] = 99,
        };

        [UnityEditor.MenuItem("sssss/sss")]
        public static void Test() {

            var dict = CreateSourceDictionary();

            Debug_.Log("--------------");
            Debug_.DictLog(dict);

            dict.TryAdd("A",1000);
            dict.TryAdd("F",1000);

            Debug_.Log("--------------");


            Debug_.Log(dict.GetValueOrDefault("F"));
            Debug_.Log(dict.GetValueOrDefault("X"));
        }

        */
        
        #endregion

    }
}