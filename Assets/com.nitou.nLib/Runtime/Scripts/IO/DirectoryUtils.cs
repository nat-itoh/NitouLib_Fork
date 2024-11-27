using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;

// [REF]
//  �R�K�l�u���O: ��؂蕶���ɃX���b�V�����g�p���Ďw�肵���f�B���N�g�����̃t�@�C������Ԃ��֐� https://baba-s.hatenablog.com/entry/2015/07/29/100000
//  _: C#�t�@�C���^�t�H���_����p�B�����Ɏg����T���v���R�[�h�t�� https://resanaplaza.com/2024/02/23/%E3%80%90%E5%AE%9F%E8%B7%B5%E3%80%91c%E3%83%95%E3%82%A1%E3%82%A4%E3%83%AB%EF%BC%8F%E3%83%95%E3%82%A9%E3%83%AB%E3%83%80%E6%93%8D%E4%BD%9C%E8%A1%93%E3%80%82%E3%81%99%E3%81%90%E3%81%AB%E4%BD%BF%E3%81%88/#google_vignette

namespace nitou {

    /// <summary>
    /// �f�B���N�g������Ɋւ���ėp���\�b�h�W
    /// </summary>
    public static class DirectoryUtils {

        /// ----------------------------------------------------------------------------
        #region ����

        /// <summary>
        /// �f�B���N�g�����݃`�F�b�N�D
        /// </summary>
        public static void ExistsWithExp(string path) {
            if (!Directory.Exists(path)) {
                throw new DirectoryNotFoundException("Directory is not exist :" + path);
            }
        }

        /// <summary>
        /// �f�B���N�g�����݃`�F�b�N�D
        /// </summary>
        public static void ExistsWithExp(IEnumerable<string> paths) {
            paths.ForEach(ExistsWithExp);
        }
        #endregion


        /// ----------------------------------------------------------------------------
        #region �R�s�[

        //// [REF] Microsoft Learn: �f�B���N�g�����R�s�[���� https://learn.microsoft.com/ja-jp/dotnet/standard/io/how-to-copy-directories

        /// <summary>
        /// �f�B���N�g�����ċA�I�ɃR�s�[����D
        /// </summary>
        public static void CopyDirectory(string sourceDir, string destDir) {

            // �R�s�[��̃t�H���_�����݂��Ȃ��ꍇ�͍쐬����
            if (!Directory.Exists(destDir)) {
                Directory.CreateDirectory(destDir);
            }

            // Copy files
            foreach (string file in Directory.GetFiles(sourceDir)) {
                try {
                    string destFile = Path.Combine(destDir, Path.GetFileName(file));
                    File.Copy(file, destFile, true); 
                } catch (Exception ex) {
                    // �G���[�����������ꍇ�̓G���[���b�Z�[�W��\�����ď������p������
                    Debug_.LogWarning("�t�@�C���̃R�s�[���ɃG���[���������܂���: " + ex.Message);
                }
            }

            // Copy directories
            foreach (string folder in Directory.GetDirectories(sourceDir)) {
                try {
                    string destFolder = Path.Combine(destDir, Path.GetFileName(folder));
                    CopyDirectory(folder, destFolder); // �T�u�t�H���_���ċA�I�ɃR�s�[����
                } catch (Exception ex) {
                    // �G���[�����������ꍇ�̓G���[���b�Z�[�W��\�����ď������p������
                    Debug_.LogWarning("�t�H���_�̃R�s�[���ɃG���[���������܂���: " + ex.Message);
                }
            }
        }

        #endregion


        /// <summary>
        /// �f�B���N�g�������D
        /// </summary>
        public static List<string> Find(string directoryPath) {
            ExistsWithExp(directoryPath);
            return Directory.GetDirectories(directoryPath).ToList();
        }




        //public static string GetUniqDirectoryName() {


        //}


        /// <summary>
        /// <para>�w�肵���f�B���N�g�����̃t�@�C���̖��O (�p�X���܂�) ��Ԃ��܂�</para>
        /// <para>�p�X�̋�؂蕶���́u\\�v�ł͂Ȃ��u/�v�ł�</para>
        /// </summary>
        public static string[] GetFiles(string path) {
            return Directory
                .GetFiles(path)
                .Select(c => c.Replace("\\", "/"))
                .ToArray();
        }

        /// <summary>
        /// <para>�w�肵���f�B���N�g�����̎w�肵�������p�^�[���Ɉ�v����t�@�C���� (�p�X���܂�) ��Ԃ��܂�</para>
        /// <para>�p�X�̋�؂蕶���́u\\�v�ł͂Ȃ��u/�v�ł�</para>
        /// </summary>
        public static string[] GetFiles(string path, string searchPattern) {
            return Directory
                .GetFiles(path, searchPattern)
                .Select(c => c.Replace("\\", "/"))
                .ToArray();
        }

        /// <summary>
        /// <para>�w�肵���f�B���N�g���̒�����A�w�肵�������p�^�[���Ɉ�v���A</para>
        /// <para>�T�u�f�B���N�g�����������邩�ǂ��������肷��l�����t�@�C���� (�p�X���܂�) ��Ԃ��܂�</para>
        /// <para>�p�X�̋�؂蕶���́u\\�v�ł͂Ȃ��u/�v�ł�</para>
        /// </summary>
        public static string[] GetFiles(string path, string searchPattern, SearchOption searchOption) {
            return Directory
                .GetFiles(path, searchPattern, searchOption)
                .Select(c => c.Replace("\\", "/"))
                .ToArray();
        }

    }
}
