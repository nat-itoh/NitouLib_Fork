using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

// [�Q�l]
//  �R�K�l�u���O: ��؂蕶���ɃX���b�V�����g�p���Ďw�肵���f�B���N�g�����̃t�@�C������Ԃ��֐� https://baba-s.hatenablog.com/entry/2015/07/29/100000

namespace nitou {

    /// <summary>
    /// �f�B���N�g������Ɋւ���ėp���\�b�h�W
    /// </summary>
    public static class DirectoryUtil{

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
