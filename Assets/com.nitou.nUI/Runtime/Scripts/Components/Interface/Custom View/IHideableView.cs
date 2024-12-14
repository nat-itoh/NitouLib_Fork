using System.Threading;
using Cysharp.Threading.Tasks;
using DG.Tweening;
using UnityEngine;

namespace nitou.UI.Components {

    /// <summary>
    /// �\���E��\���̐؂�ւ����\�Ȋ�{UI�D
    /// </summary>
    public interface IHideableView {

        /// <summary>
        /// �\����ԂɑJ�ڂ���D
        /// </summary>
        public Tweener DOShow(float duration);

        /// <summary>
        /// ��\����ԂɑJ�ڂ���D
        /// </summary>
        public Tweener DOHide(float duration);
    }
}
