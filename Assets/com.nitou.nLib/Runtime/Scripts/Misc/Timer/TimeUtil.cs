using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// [�Q�l]
//  _: �b�����ԁ@�ϊ��ihh:mm:ss�ϊ��j https://frog-blend.hatenablog.com/entry/2023/10/03/115056

namespace nitou {

    // ��������
    public static class TimeUtil {

        public static TimeSpan SecondToTimeSpan(int second) {
            return new TimeSpan(0, 0, second);
        }
    }
}
