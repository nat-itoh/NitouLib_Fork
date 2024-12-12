using System;

// [REF]
//  �R�K�l�u���O: DateTime �������鎞�̋L�q���ȗ������� Deconstruction https://baba-s.hatenablog.com/entry/2019/09/03/230400

namespace nitou
{
    /// <summary>
    /// <see cref="DateTime"/>�^�ɑ΂���ėp�I�Ȋg�����\�b�h�W�D
    /// </summary>
    public static partial class DateTimeExtensions {

        /// <summary>
        /// �f�R���X�g���N�^�D
        /// </summary>
        public static void Deconstruct(this DateTime self, out int year, out int month, out int day) {
            year = self.Year;
            month = self.Month;
            day = self.Day;
        }
    }
}
