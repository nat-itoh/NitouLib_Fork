using System;
using System.Collections.Generic;

// [�Q�l]
//  qiita: Unity�ŃT�[�r�X���P�[�^�[(ServiceLocator)�����p���� https://qiita.com/ozaki_shinya/items/9eb0f827caa6a4108888

namespace nitou.DesignPattern {

    /// <summary>
    /// �V���v���Ȏ����̃T�[�r�X���P�[�^
    /// </summary>
    public static class ServiceLocator {

        // �P��C���X�^���X�p
        private static Dictionary<Type, object> _instanceDict = new ();

        // �s�x�C���X�^���X�����p
        private static Dictionary<Type, Type> _typeDict = new�@();

        /// <summary>
        /// �P��C���X�^���X��o�^����
        /// �Ăђ����Ə㏑���o�^����
        /// </summary>
        /// <typeparam name="T">�^</typeparam>
        /// <param name="instance">�C���X�^���X</param>
        public static void Register<T>(T instance) where T : class {
            _instanceDict[typeof(T)] = instance;
        }

        /// <summary>
        /// �^��o�^����
        /// ���̃��\�b�h�œo�^�����Resolve�����Ƃ��ɓs�x�C���X�^���X��������
        /// </summary>
        /// <typeparam name="TContract">���ی^</typeparam>
        /// <typeparam name="TConcrete">��^</typeparam>
        public static void Register<TContract, TConcrete>() where TContract : class {
            _typeDict[typeof(TContract)] = typeof(TConcrete);
        }

        /// <summary>
        /// �^���w�肵�ēo�^����Ă���C���X�^���X���擾����
        /// </summary>
        /// <typeparam name="T">�^</typeparam>
        /// <returns>�C���X�^���X</returns>
        public static T Resolve<T>() where T : class {
            T instance = default;

            Type type = typeof(T);

            if (_instanceDict.ContainsKey(type)) {
                // ���O�ɐ������ꂽ�P��C���X�^���X��Ԃ�
                instance = _instanceDict[type] as T;
                return instance;
            }

            if (_typeDict.ContainsKey(type)) {
                // �C���X�^���X�𐶐����ĕԂ�
                instance = Activator.CreateInstance(_typeDict[type]) as T;
                return instance;
            }

            if (instance == null) {
                Debug_.LogWarning($"Locator: {typeof(T).Name} not found.");
            }
            return instance;
        }
    }
}
