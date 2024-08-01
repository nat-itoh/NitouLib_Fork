using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;

// [�Q�l]
//  PG����: ���u�Q�[����N���b�J�[�Q�[���ɏo�Ă���P�ʂ�\������ https://takap-tech.com/entry/2023/03/25/235545

namespace nitou {

    /// <summary>
    /// �P�ʂ��Ǘ�����N���X
    /// </summary>
    public class UnitMgr {

        // �ő�̌���
        private readonly int _maxDigit = 1000;
        // �P�ʂ̃��X�g
        private static string[] _units;


        /// ----------------------------------------------------------------------------
        // Public Method

        /// <summary>
        /// �R���X�g���N�^
        /// </summary>
        public UnitMgr(int maxDigit) {
            _maxDigit = maxDigit;
        }

        /// <summary>
        /// �P�ʂ�����������
        /// </summary>
        private void Init() {
            if (_units == null) // ���ڂɏ�����
            {
                _units = CreateUnits(_maxDigit).ToArray();
            }
        }


        /// ----------------------------------------------------------------------------
        // Public Method (�P�ʂ̎擾)

        /// <summary>
        /// �w�肵���ʒu�̒P�ʂ��擾����
        /// </summary>
        public string GetUnit(int index) {
            Init();
            if (index >= _units.Length) {
                return "ERROR";
            }
            return _units[index];
        }

        /// <summary>
        /// �w�肵���ʒu�̒P�ʂ�Span�Ƃ��Ď擾����
        /// </summary>
        public ReadOnlySpan<char> GetUnitSpan(int index) {
            Init();
            if (index >= _units.Length) {
                //Trace.WriteLine("Overflow");
                return "ERROR";
            }
            return _units[index].AsSpan();
        }


        /// ----------------------------------------------------------------------------
        // Public Method (�P�ʂ̐ݒ�)

        /// <summary>
        /// �w�肵�����̕������P�ʂ𐶐�����
        /// </summary>
        private IEnumerable<string> CreateUnits(int count) {
            var sb = new StringBuilder();
            string f(int i) {
                sb.Clear();
                int d = i;
                while (d > 0) {
                    int mod = (d - 1) % 26;
                    sb.Insert(0, Convert.ToChar(97 + mod));
                    d = (d - mod) / 26;
                }
                return sb.ToString();
            }
            yield return "";
            yield return "K";
            yield return "M";
            yield return "B";
            yield return "T";
            for (int i = 1; i < count - 4; i++) {
                yield return f(i);
            }
        }
    }



    public static partial class BigIntegerExtensions {

        // �T�|�[�g����ő�̌���
        private const int MaxDigit = 1024; // 10^512�܂�
        private const char Dot = '.';
        private const string Error = "ERROR";

        // �P�ʂ̃��X�g
        private static readonly UnitMgr conv = new (MaxDigit);

        // 1234564789 �� 1.234b �̂悤�Ȍ`���ɕϊ�����
        // ** Span��p���ĉ\�Ȍ��胁�����A���P�[�V������}����悤�Ɏ������Ă���
        public static string ToReadableString(this BigInteger src) {

            Span<char> buffer = stackalloc char[MaxDigit];
            if (!src.TryFormat(buffer, out int length)) {
                return Error; // �T�|�[�g���Ă錅���𒴂���
            }
            if (length < 7) // 7�������͂��̂܂ܐ�����Ԃ�
            {
                return buffer.Slice(0, length).ToString();
            }

            // 7���ȏ�͌����ɉ����ĉ��H����
            int _len = length - 1;
            ReadOnlySpan<char> unitSpan = conv.GetUnitSpan(_len / 3);
            int d = _len % 3;

            // ���ʂ����邢�����
            Span<char> result = stackalloc char[5 + d + unitSpan.Length];

            d++;
            var a = buffer.Slice(0, d);
            var c = buffer.Slice(d, 3);

            a.CopyTo(result);
            result[a.Length] = Dot;
            c.CopyTo(result.Slice(a.Length + 1));
            unitSpan.CopyTo(result.Slice(a.Length + 1 + c.Length));
            return result.ToString();
        }
    }
}