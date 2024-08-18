using System;
using UnityEngine;

// [�Q�l]
//  LIGHT11: Custom Attribute��Custom Property Drawer��g�ݍ��킹����Inspector�����܂��\������Ȃ��Ȃ������ƑΉ����@ https://light11.hatenadiary.com/entry/2019/03/24/012712

namespace nitou.Inspector{

	/// ----------------------------------------------------------------------------
	#region Simple

	/// <summary>
	/// ReadOnly��Ԃɂ���Inspector����
	/// </summary>
	[AttributeUsage(AttributeTargets.Field | AttributeTargets.Property | AttributeTargets.Method)]
	public sealed class ReadOnlyAttribute : PropertyAttribute { }

	/// <summary>
	/// �C���f���g��ݒ肷��Inspector����
	/// </summary>
	[AttributeUsage(AttributeTargets.Field | AttributeTargets.Property | AttributeTargets.Method)]
	public sealed class IndentAttribute : PropertyAttribute {
		public readonly int IndentLevel;
		public IndentAttribute(int indentLevel = 1) => this.IndentLevel = indentLevel;
	}

    #endregion


    /// ----------------------------------------------------------------------------
    #region Condition

    [AttributeUsage(AttributeTargets.Field | AttributeTargets.Property | AttributeTargets.Method)]
	public sealed class DisableInPlayModeAttribute : PropertyAttribute { }

	[AttributeUsage(AttributeTargets.Field | AttributeTargets.Property | AttributeTargets.Method)]
	public sealed class HideInPlayModeAttribute : PropertyAttribute { }

	#endregion


	/// ----------------------------------------------------------------------------
	#region Title label

	[AttributeUsage(AttributeTargets.Field | AttributeTargets.Property | AttributeTargets.Method)]
	public sealed class TitleAttribute : PropertyAttribute {
		public string TitleText { get; }
		public string SubtitleText { get; }

		public TitleAttribute(string titleText) {
			TitleText = titleText;
			SubtitleText = null;
		}

		public TitleAttribute(string titleText, string subtitle) {
			TitleText = titleText;
			SubtitleText = subtitle;
		}
	}
	#endregion


}