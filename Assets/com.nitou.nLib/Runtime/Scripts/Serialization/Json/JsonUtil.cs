using System.Collections.Generic;
using UnityEngine;

// [�Q�l]
//  PG����: JsonUtility�Ŕz��ƃ��X�g���������� https://takap-tech.com/entry/2021/02/02/222406
//  �R�K�l�u���O: Dictionary��JsonUtility�ŕϊ��ł���悤�ɂ���N���X https://baba-s.hatenablog.com/entry/2020/11/20/080300

namespace nitou.Serialization{

    /// <summary>
    /// <see cref="JsonUtility"/>�ɋ@�\��ǉ����郉�b�p�[
    /// </summary>
    public static class JsonUtil{

        /// ----------------------------------------------------------------------------
        #region Collection

        public static T[] FromJsonArray<T>(string json) {
            Wrapper<T> wrapper = JsonUtility.FromJson<Wrapper<T>>(json);
            return wrapper.items;
        }

        public static string ToJson<T>(T[] array) {
            Wrapper<T> wrapper = new Wrapper<T>();
            wrapper.items = array;
            return JsonUtility.ToJson(wrapper);
        }

        public static List<T> FromJsonList<T>(string json) {
            Wrapper<T> wrapper = JsonUtility.FromJson<Wrapper<T>>(json);
            return new List<T>(wrapper.items);
        }

        public static string ToJson<T>(List<T> list) {
            Wrapper<T> wrapper = new Wrapper<T>();
            wrapper.items = list.ToArray();
            return JsonUtility.ToJson(wrapper);
        }

        [System.Serializable]
        private class Wrapper<T> {
            public T[] items;
        }
        #endregion


    }
}
