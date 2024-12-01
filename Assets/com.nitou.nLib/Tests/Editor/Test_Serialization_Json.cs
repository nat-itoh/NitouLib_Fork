using System;
using System.Collections.Generic;
using NUnit.Framework;
using nitou.Serialization;

namespace nitou.Tests {

    public class Test_Serialization_Json {

        [Test]
        public void �R���N�V������Json�ɕϊ��ł���() {

            // int
            var intList = new List<int> { 1, 2, 3 };
            string intJson = JsonHelper.ToJson(intList);
            Debug_.Log(intJson, Colors.Orange);
            Assert.AreEqual("{\"items\":[1,2,3]}", intJson);

            // float
            //var floatList = new List<float> { 30, 2, 3 };
            //string floatJson = JsonHelper.ToJson(floatList);
            //Assert.AreEqual("{\"items\":[1,2,3]}", floatJson);


        }

        [Test]
        public void Dictionary��Json�ɕϊ��ł���() {
            var dictionary = new Dictionary<string, int>
            {
                { "key1", 10 },
                { "key2", 20 }
            };

            string json = JsonHelper.ToJson(dictionary);
            Debug_.Log(json, Colors.Orange);

            // ���b�v�`�����l�������A�T�[�V����
            Assert.IsTrue(json.Contains("\"Key\":\"key1\""));
            Assert.IsTrue(json.Contains("\"Value\":10"));
            Assert.IsTrue(json.Contains("\"Key\":\"key2\""));
            Assert.IsTrue(json.Contains("\"Value\":20"));
        }

        [Test]
        public void Json��z��ɕϊ��ł���() {
            string json = "{\"items\":[1,2,3]}";
            int[] result = JsonHelper.FromJsonArray<int>(json);

            Assert.AreEqual(3, result.Length);
            Assert.AreEqual(1, result[0]);
            Assert.AreEqual(2, result[1]);
            Assert.AreEqual(3, result[2]);
        }

        [Test]
        public void Json�����X�g�ɕϊ��ł���() {
            string json = "{\"items\":[\"a\",\"b\",\"c\"]}";
            List<string> result = JsonHelper.FromJsonList<string>(json);

            Assert.AreEqual(3, result.Count);
            Assert.AreEqual("a", result[0]);
            Assert.AreEqual("b", result[1]);
            Assert.AreEqual("c", result[2]);
        }
    }
}
