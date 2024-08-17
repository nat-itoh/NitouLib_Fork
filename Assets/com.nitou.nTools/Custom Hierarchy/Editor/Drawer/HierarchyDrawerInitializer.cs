#if UNITY_EDITOR
using System;
using System.Linq;
using UnityEditor;

// [�Q�l]
//  hatena: TypeCache���g���Ďw�肵���A�g���r���[�g���t���Ă���^�������Ɏ擾���� https://light11.hatenadiary.com/entry/2021/04/26/202054
//  �͂Ȃ���: TypeCache��p����"����̑����Ń}�[�N����Ă���^�⃁�\�b�h" �� "����̃N���X��C���^�[�t�F�C�X����h������^"�ɑf�����A�N�Z�X���� https://www.hanachiru-blog.com/entry/2023/12/08/120000

namespace nitou.Tools.Hierarchy.EditorSctipts {

    internal static class HierarchyDrawerInitializer {

        [InitializeOnLoadMethod]
        private static void Initialize() {

            // �w�肵���^���p���܂��͂܂��̓C���^�[�t�F�[�X���������Ă���^���擾
            var drawers = TypeCache.GetTypesDerivedFrom<HierarchyDrawer>()
                .Where(x => !x.IsAbstract)
                .Select(x => (HierarchyDrawer)Activator.CreateInstance(x));

            // �ꊇ�ŕ`�揈����o�^
            foreach (var drawer in drawers) {
                EditorApplication.hierarchyWindowItemOnGUI += drawer.OnGUI;
            }
        }
    }
}
#endif