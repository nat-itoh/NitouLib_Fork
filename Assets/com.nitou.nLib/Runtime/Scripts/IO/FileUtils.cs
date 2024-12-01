using System;
using System.IO;
using System.Text.RegularExpressions;
using System.Collections.Generic;
using System.Linq;

// [REF]
// _: �t�@�C���E�f�B���N�g���֘Autil https://ameblo.jp/ka-neda/entry-12779824591.html

namespace nitou {
    
    /// <summary>
    /// �t�@�C������Ɋւ���ėp���\�b�h�W�D
    /// </summary>
    public static class FileUtils {

        /// ----------------------------------------------------------------------------
        #region ����

        /// <summary>
        /// �t�@�C���̑��݃`�F�b�N�D
        /// </summary>
        public static void ExistsWithExp(string path) {
            if (!File.Exists(path)) {
                throw new DirectoryNotFoundException("File is not exist :" + path);
            }
        }

        /// <summary>
        /// �t�@�C���̑��݃`�F�b�N�D
        /// </summary>
        public static void ExistsWithExp(IEnumerable<string> paths) {
            paths.ForEach(ExistsWithExp);
        }
        #endregion

    }
}
