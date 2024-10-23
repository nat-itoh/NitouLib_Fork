using System.Collections.Generic;
using UniRx;
using UnityEngine;
using nitou;

namespace Project{

    public class UniRxTester : MonoBehaviour{


        private void Start() {
            // ReactiveArray �̏����� (����5)
            ReactiveArray<float> reactiveArray = new ReactiveArray<float>(new List<float> { 0.1f, 0.2f, 0.3f, 0.4f, 0.5f });

            // Replace �C�x���g�̍w��
            reactiveArray.ObserveReplace().Subscribe(replaceEvent => {
                Debug.Log($"Item replaced at index {replaceEvent.Index}: {replaceEvent.OldValue} -> {replaceEvent.NewValue}");
            }).AddTo(this); // MonoBehaviour�Ƀ��C�t�^�C�����o�C���h

            // Move �C�x���g�̍w��
            reactiveArray.ObserveMove().Subscribe(moveEvent => {
                Debug.Log($"Item moved from index {moveEvent.OldIndex} to {moveEvent.NewIndex}: {moveEvent.Value}");
            }).AddTo(this);

            // �������̃e�X�g��������s
            Debug.Log("Initial array:");
            PrintArray(reactiveArray);

            // �C���f�b�N�X2�̗v�f��0.35�ɕύX
            reactiveArray.SetItem(2, 0.35f);

            reactiveArray[3] = 10f;
            reactiveArray.SetItem(3, 99);

            // �C���f�b�N�X1�̗v�f���C���f�b�N�X4�Ɉړ�
            reactiveArray.Move(1, 4);

            // ���ʂ̔z���\��
            Debug.Log("Updated array:");
            PrintArray(reactiveArray);
        }

        // �z��̓��e���o�͂���w���p�[���\�b�h
        private void PrintArray(ReactiveArray<float> array) {
            for (int i = 0; i < array.Count; i++) {
                Debug.Log($"Index {i}: {array[i]}");
            }
        }





    }
}
