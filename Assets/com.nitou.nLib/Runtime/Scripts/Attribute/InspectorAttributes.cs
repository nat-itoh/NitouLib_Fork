using System;
using UnityEngine;

// [�Q�l]
//  LIGHT11: Custom Attribute��Custom Property Drawer��g�ݍ��킹����Inspector�����܂��\������Ȃ��Ȃ������ƑΉ����@ https://light11.hatenadiary.com/entry/2019/03/24/012712

namespace nitou.Inspector{


    /// ----------------------------------------------------------------------------
    // Condition

    [AttributeUsage(AttributeTargets.Field | AttributeTargets.Property | AttributeTargets.Method)]
	public sealed class DisableInPlayModeAttribute : PropertyAttribute { }

	[AttributeUsage(AttributeTargets.Field | AttributeTargets.Property | AttributeTargets.Method)]
	public sealed class HideInPlayModeAttribute : PropertyAttribute { }

}
