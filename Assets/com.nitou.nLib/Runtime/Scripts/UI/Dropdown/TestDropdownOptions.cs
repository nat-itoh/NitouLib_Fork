using System;
using UniRx;
using UnityEngine;
using TMPro;

namespace nitou {

    public enum MyType {
        ModeA,�@ModeB,�@ModeC,�@ModeD,
    }

    // �h���N���X
    public sealed class TestDropdownOptions : DropdownEnumOptions<MyType> {}
}