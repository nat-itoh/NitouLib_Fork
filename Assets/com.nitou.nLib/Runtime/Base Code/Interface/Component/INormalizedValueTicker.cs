
namespace nitou{

    /// <summary>
    /// ���K�����ꂽ�l (0~1) �Ɋ�Â��ċ쓮����I�u�W�F�N�g
    /// </summary>
    public interface INormalizedValueTicker {

        /// <summary>
        /// ���K�����ꂽ�l
        /// </summary>
        public NormalizedValue Rate { get; set; }
    }
}
