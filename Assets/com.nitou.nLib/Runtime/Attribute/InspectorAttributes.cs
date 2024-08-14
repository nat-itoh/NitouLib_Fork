using System;
using UnityEngine;

// [�Q�l]
//  LIGHT11: Custom Attribute��Custom Property Drawer��g�ݍ��킹����Inspector�����܂��\������Ȃ��Ȃ������ƑΉ����@ https://light11.hatenadiary.com/entry/2019/03/24/012712

namespace nitou.Inspector{


    [AttributeUsage(AttributeTargets.Field | AttributeTargets.Property | AttributeTargets.Method)]
    public sealed class ReadOnlyAttribute : PropertyAttribute { }

    [AttributeUsage(AttributeTargets.Field | AttributeTargets.Property | AttributeTargets.Method)]
        public sealed class IndentAttribute : PropertyAttribute {
            public IndentAttribute(int indent = 1) => this.indent = indent;
            public readonly int indent;
        }

    [AttributeUsage(AttributeTargets.Field | AttributeTargets.Property | AttributeTargets.Method)]
    public sealed class LabelTextAttribute : PropertyAttribute {
        public string Text { get; }

        public LabelTextAttribute(string text) => Text = text;
    }


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
