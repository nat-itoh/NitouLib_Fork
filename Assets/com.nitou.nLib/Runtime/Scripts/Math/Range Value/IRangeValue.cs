
using System;

namespace nitou {

    /// <summary>
    /// �͈͂�\���C���^�[�t�F�[�X�D
    /// </summary>
    public interface IRangeValue<TValue>
        where TValue : struct {

        /// <summary>
        /// �ŏ��l�D
        /// </summary>
        TValue Min { get; set; }

        /// <summary>
        /// �ő�l�D
        /// </summary>
        TValue Max { get; set; }

        /// <summary>
        /// �����l�D
        /// </summary>
        TValue Mid { get; }

        /// <summary>
        /// �͈͂̒����D
        /// </summary>
        TValue Length { get; }

        /// <summary>
        /// �͈͓��̃����_���Ȓl�D
        /// </summary>
        TValue Random { get; }

        /// <summary>
        /// �l���͈͓������ׂ�D
        /// </summary>
        bool Contains(TValue value);
    }


    public static class RangeVelueExtensions {

        /// <summary>
        /// �͈͂� 0 ���� 1 �͈̔͂ɐ��K������g�����\�b�h�D
        /// </summary>
        public static float GetNormalized<TValue>(this IRangeValue<TValue> range, TValue value)
            where TValue : struct, IConvertible {
            var min = Convert.ToSingle(range.Min);
            var max = Convert.ToSingle(range.Max);
            var current = Convert.ToSingle(value);

            return (current - min) / (max - min);
        }

        /// <summary>
        /// �w�肳�ꂽ�l��V�����͈͂ɃX�P�[������g�����\�b�h�D
        /// </summary>
        public static TValue ScaleToRange<TValue>(this IRangeValue<TValue> range, TValue value, IRangeValue<TValue> newRange)
            where TValue : struct, IConvertible {
            var normalized = range.GetNormalized(value);
            var newMin = Convert.ToSingle(newRange.Min);
            var newMax = Convert.ToSingle(newRange.Max);

            return (TValue)Convert.ChangeType(newMin + (newMax - newMin) * normalized, typeof(TValue));
        }
    }
}
