
namespace nitou{

    /// <summary>
    /// �͈͂�\���C���^�[�t�F�[�X
    /// </summary>
    public interface IRangeValue<TValue> 
        where TValue : struct{

        TValue Min { get; set; }
        TValue Max { get; set; }

        /// <summary>
        /// �����l
        /// </summary>
        TValue Mid { get; }
        
        /// <summary>
        /// �͈͂̒���
        /// </summary>
        TValue Length { get; }
        
        /// <summary>
        /// �͈͓��̃����_���Ȓl
        /// </summary>
        TValue Random { get; }

        /// <summary>
        /// �l���͈͓������ׂ�
        /// </summary>
        bool Contains(TValue value);
    }
}
