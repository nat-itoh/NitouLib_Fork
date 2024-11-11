using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using UnityEngine;

namespace RPG {
    public class TurnManager {

        private List<Battler> _battlers;
        private Battler _currentBattler;

        private Queue<BattlerAction> _actionQueue = new();


        /// ----------------------------------------------------------------------------
        // Public Method

        /// <summary>
        /// �R���X�g���N�^�D
        /// </summary>
        public TurnManager(List<Battler> battlers) {
            _battlers = battlers;
        }


        public async UniTask StartBattle() {
            while (!IsBattleOver()) {
                // �v���C���[���̓t�F�[�Y
                await HandlePlayerInput();

                // �^�[���J�n������
                BeginTurn();

                // �o�g���[�s���t�F�[�Y
                await ExecuteActions();

                // �^�[���I��������
                EndTurn();
            }

            Debug.Log("Battle Ended");
        }


        /// ----------------------------------------------------------------------------
        // Private Method

        private async UniTask HandlePlayerInput() {
            // �v���C���[�ɓ��͂𑣂��A�s�����L���[�ɓo�^
            // �����ł͗�Ƃ��ČŒ�̍s��������
            _actionQueue.Enqueue(new BattlerAction { /* �s�����e */ });
            await UniTask.Delay(1000); // �v���C���[�̑I��ҋ@�V�~�����[�V����
        }

        private void BeginTurn() {
            Debug.Log("Turn Start");
            // ��Ԉُ�̃^�[���J�n�����ʓK�p�Ȃ�
        }

        private async UniTask ExecuteActions() {
            while (_actionQueue.Count > 0) {
                BattlerAction action = _actionQueue.Dequeue();
                await action.Execute();
            }
        }

        private void EndTurn() {
            Debug.Log("Turn End");
            // ��Ԉُ�̌o�߃^�[���X�V��A���ʏI������Ȃ�
        }

        private bool IsBattleOver() {
            // �S����HP��0�Ȃ�o�g���I��
            return false; // ���̎���
        }

    }
}
