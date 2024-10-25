using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.Linq;
using UnityEngine;
using nitou;

namespace Project {

    public class RobotErrorManager : MonoBehaviour {

        private List<string> errorList = new ();
        private bool isCommunicating = true;
        
        private const float CommunicationInterval = 2f; // �ʐM�����i�b�j


        private void Start() {
            // �G���[�擾�������J�n
            StartReceivingErrors().Forget();
        }


        private async UniTaskVoid StartReceivingErrors() {
            // Timer���g�p���Ĉ��Ԋu�ŏ������s��
            await foreach (var _ in UniTaskAsyncEnumerable.Timer(System.TimeSpan.FromSeconds(CommunicationInterval), System.TimeSpan.FromSeconds(CommunicationInterval))
                .WithCancellation(this.GetCancellationTokenOnDestroy())) {
                if (!isCommunicating) {
                    Debug_.Log("Communication stopped.", Colors.Orange);
                    break;
                }

                // ���{�b�g����G���[�����擾
                Debug.Log("---------------------------------------.");
                Debug.Log("Attempting to get errors from the robot.");
                var newErrors = await GetErrorsFromRobotAsync();

                // �擾�����G���[�������C�����X�g�ɒǉ�
                lock (errorList) {
                    errorList.AddRange(newErrors);
                    Debug.Log($"Added {newErrors.Count} errors. Total errors: {errorList.Count}");
                }
            }
        }

        /// <summary>
        /// ��̓I�ȒʐM����
        /// </summary>
        private async UniTask<List<string>> GetErrorsFromRobotAsync() {
            // ���{�b�g�ƒʐM���ăG���[�����擾���鏈��������
            await UniTask.Delay(100); // �ʐM���Ԃ̃V�~�����[�V����
            var simulatedErrors = new List<string> { "Error1", "Error2" }; // ���̃G���[���
            Debug.Log($"Received {simulatedErrors.Count} errors from the robot.");
            return simulatedErrors;
        }

        private void OnDestroy() {
            // �ʐM���~
            isCommunicating = false;
            Debug.Log("RobotErrorManager is being destroyed.");
        }
    }
}
