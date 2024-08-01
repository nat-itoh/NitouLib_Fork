using System;
using System.Collections.Generic;
using System.Linq;

namespace nitou {
    
    /// <summary>
    /// <see cref="Type"/>�^�ɑ΂���ėp���\�b�h�W
    /// </summary>
    public static class TypeUtil {

        /// ----------------------------------------------------------------------------
        #region �^���

        /// <summary>
        /// �f�t�H���g�R���X�g���N�^�������Ă��邩�m�F����
        /// </summary>
        public static bool HasDefaultConstructor(Type type) {
            return type.GetConstructors().Any(t => t.GetParameters().Count() == 0);
        }

        /// <summary>
        /// ���N���X��C���^�[�t�F�[�X���擾����
        /// </summary>
        public static IEnumerable<Type> GetBaseClassesAndInterfaces(Type type, bool includeSelf = false) {
            if (includeSelf) yield return type;

            if (type.BaseType == typeof(object)) {
                foreach (var interfaceType in type.GetInterfaces()) {
                    yield return interfaceType;
                }
            } else {
                foreach (var baseType in Enumerable.Repeat(type.BaseType, 1)
                    .Concat(type.GetInterfaces())
                    .Concat(GetBaseClassesAndInterfaces(type.BaseType))
                    .Distinct()) {
                    yield return baseType;
                }
            }
        }
        #endregion


        /// ----------------------------------------------------------------------------
        #region ����       
        
        /// <summary>
        /// �f�t�H���g�l���擾����g�����\�b�h
        /// </summary>
        public static object GetDefaultValue(this Type self) {
            if (!self.IsValueType) return null;
            return Activator.CreateInstance(self);
        }

        /// <summary>
        /// �f�t�H���g�̃C���X�^���X�𐶐�����g�����\�b�h
        /// </summary>
        public static object CreateDefaultInstance(Type type) {
            if (type == typeof(string)) return "";
            if (type.IsSubclassOf(typeof(UnityEngine.Object))) return null;
            return Activator.CreateInstance(type);
        }

        #endregion

    }
}
