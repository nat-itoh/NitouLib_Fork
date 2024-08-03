using UnityEngine;

namespace nitou {

    /// <summary>
    /// Vector2�̊e���� (x,y) ��Ɨ����ăC���X�y�N�^�\�������鑮��
    /// </summary>
    [System.AttributeUsage(
        System.AttributeTargets.Field, 
        AllowMultiple = false, 
        Inherited = true
    )]
    public class BreakVector2Attribute : PropertyAttribute {

        public string xLabel, yLabel;

        public BreakVector2Attribute(string xLabel, string yLabel) {
            this.xLabel = xLabel;
            this.yLabel = yLabel;
        }
    }
}
