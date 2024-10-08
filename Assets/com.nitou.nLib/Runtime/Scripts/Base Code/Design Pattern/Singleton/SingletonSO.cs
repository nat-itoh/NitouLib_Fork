using UnityEngine;

// [�Q�l]
//  youtube: The BEST Unity Feature You Don't Know About - Scriptable Object Singletons Tutorial https://www.youtube.com/watch?v=6kWUGEQiMUI&t=100s
//  github: ciwolsey/ScriptableObjectSingleton.cs https://gist.github.com/ciwolsey/3bd0189a8bbc76e3f7242b51473ff3f6
//  _: �V���O���g����ScriptableObject���������� https://mackysoft.net/singleton-scriptableobject/

namespace nitou.DesignPattern {

    /// <summary>
    /// �O���[�o���A�N�Z�X�����V���O���g����Scriptable Object
    /// ���B�ꐫ�̓R�[�h�ŒS�ۂ���Ă��Ȃ��̂ɒ���
    /// </summary>
    public class SingletonSO<T> : ScriptableObject where T : SingletonSO<T> {

        private static T _instance;
        public static T Instance {
            get {
                if (_instance == null) {
                    T[] assets = Resources.LoadAll<T>("");

                    if (assets == null || assets.Length < 1) {
                        throw new System.Exception($"Resouces�t�H���_����{typeof(T)}�^�̃A�Z�b�g��������܂���ł���");

                    } else if (assets.Length > 1) {
                        Debug.LogWarning($"{typeof(T)}�^�̃A�Z�b�g���������݂��Ă��܂�");
                    }
                    _instance = assets[0];
                }

                return _instance;
            }
        }
    }


}