using System;
using UnityEngine;
using TMPro;

namespace nitou.UI.Demo {

    public enum MyType {
        ModeA,�@ModeB,�@ModeC,�@ModeD,
    }

    // �h���N���X
    public sealed class TestDropdownOptions : DropdownEnumOptions<MyType> {}
}