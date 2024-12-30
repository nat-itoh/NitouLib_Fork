﻿using System;
using System.Runtime.CompilerServices;

// [参考]
//  hatena: 実は関数を呼び出すのにコストがかかってた？！ https://sat-box.hatenablog.jp/entry/2022/05/20/133607

namespace nitou {

    public static class Error {

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void ArgumentNullException<T>(T value) {
            if (value == null) throw new ArgumentNullException();
        }
    }
}
