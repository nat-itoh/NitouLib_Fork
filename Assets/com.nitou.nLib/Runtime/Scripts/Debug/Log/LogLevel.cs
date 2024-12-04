using UnityEngine;

namespace nitou
{
    /// <summary>
    /// ���O�̕��ށD
    /// </summary>
    public enum LogLevel
    {
        // �J������ Debug �p���O�\���Ɏg�p
        Debug,
        // �ʏ�̃��O�\���Ɏg�p
        Info, 
        // �x���\���Ɏg�p
        Warning,
        // �G���[�\���Ɏg�p
        Error,
    }


    /// <summary>
    /// Logger �p�̃^�O��ށB
    /// </summary>
    public enum LoggerTag {
        GENERAL,
        AUDIO,
        ANIMATION,
    }
}
