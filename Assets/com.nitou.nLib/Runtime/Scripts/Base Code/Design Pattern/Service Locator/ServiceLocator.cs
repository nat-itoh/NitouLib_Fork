using System;
using System.Collections.Generic;

// [REF]
//  qiita: Unity�ŃT�[�r�X���P�[�^�[(ServiceLocator)�����p���� https://qiita.com/ozaki_shinya/items/9eb0f827caa6a4108888
//  Hatena: ServiceLocator��DependencyInjection�p�^�[����DIContainer https://www.nuits.jp/entry/servicelocator-vs-dependencyinjection

namespace nitou.DesignPattern {

    /// <summary>
    /// �V���v���Ȏ����̃T�[�r�X���P�[�^�D
    /// </summary>
    public static class ServiceLocator {

        // For singleton instance
        private readonly static Dictionary<Type, object> _instanceDict = new();

        // For instance creation on demand
        private readonly static Dictionary<Type, Type> _typeDict = new();

        /// <summary>
        /// Registers a singleton instance.
        /// Recalling this method will overwrite the existing registration.
        /// </summary>
        /// <typeparam name="T">type</typeparam>
        /// <param name="instance">instance</param>
        public static void Register<T>(T instance) 
            where T : class {
            
            if (instance is null)
                throw new ArgumentNullException(nameof(instance));

            _instanceDict[typeof(T)] = instance;
        }

        /// <summary>
        /// Registers a type.
        /// Instances will be created on demand when resolved.
        /// </summary>
        /// <typeparam name="TContract">Abstract type</typeparam>
        /// <typeparam name="TConcrete">Concrete type</typeparam>
        public static void Register<TContract, TConcrete>()
            where TConcrete : TContract, new()
            where TContract : class {
            _typeDict[typeof(TContract)] = typeof(TConcrete);
        }

        /// <summary>
        /// Retrieves a registered instance by specifying the type.
        /// </summary>
        /// <typeparam name="T">type</typeparam>
        /// <returns>instance</returns>
        public static T Resolve<T>() where T : class {
            T instance = default;
            Type type = typeof(T);

            if (_instanceDict.ContainsKey(type)) {
                // Returns a pre-created singleton instance
                instance = _instanceDict[type] as T;
                return instance;
            }

            if (_typeDict.ContainsKey(type)) {
                // Creates and returns a new instance
                instance = Activator.CreateInstance(_typeDict[type]) as T;
                return instance;
            }

            if (instance == null) {
                Debug_.LogWarning($"Locator: {typeof(T).Name} not found.");
            }
            return instance;
        }

        /// <summary>
        /// Clear caches.
        /// </summary>
        public static void ClearAll() {
            _instanceDict.Clear();
            _typeDict.Clear();
        }
    }
}
