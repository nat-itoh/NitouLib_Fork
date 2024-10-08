using System.Reflection;
using System.Linq;

namespace nitou.Tools.ProjectWindow {

    /// <summary>
    /// �t���O���`���Ă���N���X
    /// </summary>
    public interface IFlagContainer {}


    /// <summary>
    /// <see cref="IFlagContainer"/>�ɑ΂���g�����\�b�h
    /// </summary>
    public static class FlagContainerExtensions {

        public static bool GetFlagValue(this IFlagContainer container, string flagName) {
            var field = container.GetType().GetField(flagName);
            return field != null && (bool)field.GetValue(container);
        }

        public static void SetFlagValue(this IFlagContainer container, string flagName, bool value) {
            var field = container.GetType().GetField(flagName);
            if (field != null && field.FieldType == typeof(bool)) {
                field.SetValue(container, value);
            }
        }

        /// <summary>
        /// �t���O���̃��X�g���擾����
        /// </summary>
        public static string[] GetFlagNames(this IFlagContainer container) {
            return container.GetType().GetFields(BindingFlags.Public | BindingFlags.Instance)
                             .Where(f => f.FieldType == typeof(bool))
                             .Select(f => f.Name)
                             .ToArray();
        }
    }
}
