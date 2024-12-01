using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEngine;

// [�Q�l]
//  PG����: JsonUtility�Ŕz��ƃ��X�g���������� https://takap-tech.com/entry/2021/02/02/222406
//  �R�K�l�u���O: Dictionary��JsonUtility�ŕϊ��ł���悤�ɂ���N���X https://baba-s.hatenablog.com/entry/2020/11/20/080300

namespace nitou.Serialization {

    /// <summary>
    /// <see cref="JsonUtility"/>�ɋ@�\��ǉ������ėp���\�b�h�W�D
    /// </summary>
    public static class JsonHelper {

        /// ----------------------------------------------------------------------------
        #region Collection

        /// <summary>
        /// �z��܂��̓��X�g�� JSON �ɕϊ�����D
        /// </summary>
        public static string ToJson<T>(IEnumerable<T> collection, bool prettyPrint = false) {
            var wrapper = new Wrapper<T>();
            wrapper.items = collection.ToArray();
            return JsonUtility.ToJson(wrapper, prettyPrint);
        }

        /// <summary>
        /// Dictionary �� JSON �ɕϊ�����D
        /// </summary>
        public static string ToJson<TKey, TValue>(Dictionary<TKey, TValue> dictionary, bool prettyPrint = false) {
            var wrapper = new Wrapper<SerializableKeyValuePair<TKey, TValue>> {
                items = dictionary
                    .Select(kvp => new SerializableKeyValuePair<TKey, TValue>(kvp.Key, kvp.Value))
                    .ToArray()
            };
            return JsonUtility.ToJson(wrapper, prettyPrint);
        }

        /// <summary>
        /// JSON ��z��ɕϊ�����D
        /// </summary>
        public static T[] FromJsonArray<T>(string json) {
            try {
                var wrapper = JsonUtility.FromJson<Wrapper<T>>(json);
                return wrapper.items ?? Array.Empty<T>();

            } catch (Exception ex) {
                Debug.LogError($"FromJsonArray failed: {ex.Message}");
                return Array.Empty<T>();
            }
        }

        /// <summary>
        /// JSON �����X�g�ɕϊ����܂�
        /// </summary>
        public static List<T> FromJsonList<T>(string json) {
            try {
                var wrapper = JsonUtility.FromJson<Wrapper<T>>(json);
                return new List<T>(wrapper.items);

            } catch (Exception ex) {
                Debug.LogError($"FromJsonList failed: {ex.Message}");
                return new List<T>();
            }
        }

        #endregion


        /// ----------------------------------------------------------------------------
        #region File

        // JSON���w��p�X�ɕۑ�
        public static void SaveToFile(string filePath, string json) {
            try {
                File.WriteAllText(filePath, json);
                Debug.Log($"JSON saved to {filePath}");
            } catch (Exception ex) {
                Debug.LogError($"Failed to save JSON: {ex.Message}");
            }
        }

        // �w��p�X����JSON��ǂݍ���
        public static string LoadFromFile(string filePath) {
            try {
                if (!File.Exists(filePath)) {
                    Debug.LogWarning($"File not found: {filePath}");
                    return string.Empty;
                }
                return File.ReadAllText(filePath);
            } catch (Exception ex) {
                Debug.LogError($"Failed to load JSON: {ex.Message}");
                return string.Empty;
            }
        }


        #endregion


        /// ----------------------------------------------------------------------------
        [System.Serializable]
        private class Wrapper<T> {
            public T[] items;
        }

        [System.Serializable]
        private class SerializableKeyValuePair<TKey, TValue> {
            public TKey Key;
            public TValue Value;

            public SerializableKeyValuePair(TKey key, TValue value) {
                Key = key;
                Value = value;
            }
        }
    }
}
