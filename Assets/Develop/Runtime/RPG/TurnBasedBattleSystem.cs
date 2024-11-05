using System;
using Cysharp.Threading.Tasks;
using UnityEngine;

namespace Rpg {

    public class TurnBasedBattleSystem : MonoBehaviour {
        
        public Character player;
        public Character enemy;
        private bool isBattleOver = false;

        private async void Start() {
            await StartBattle();
        }

        private async UniTask StartBattle() {
            Debug.Log("�o�g���J�n�I");
            while (!isBattleOver) {
                await PlayerTurn();
                if (isBattleOver) break;

                await EnemyTurn();
                if (isBattleOver) break;
            }
        }

        private async UniTask PlayerTurn() {
            Debug.Log("�v���C���[�̃^�[��");
            // ���͑ҋ@�i��: �U���I����҂j
            var action = await WaitForPlayerAction();

            // ���͂ɉ����čs������
            switch (action) {
                case PlayerAction.Attack:
                    await PerformAttack(player, enemy);
                    break;
                case PlayerAction.Defend:
                    await PerformDefense(player);
                    break;
            }

            // ���s����
            if (enemy.Health <= 0) {
                Debug.Log("�v���C���[�̏����I");
                isBattleOver = true;
            }
        }

        private async UniTask EnemyTurn() {
            Debug.Log("�G�̃^�[��");

            // �G�̍s������ (��: �����_���ōU��)
            await UniTask.Delay(TimeSpan.FromSeconds(1));
            await PerformAttack(enemy, player);

            // ���s����
            if (player.Health <= 0) {
                Debug.Log("�v���C���[�̔s�k�c");
                isBattleOver = true;
            }
        }

        private async UniTask<PlayerAction> WaitForPlayerAction() {
            // �{�^�����͂̑ҋ@�Ȃǂ̏���
            await UniTask.WaitUntil(() => Input.GetKeyDown(KeyCode.A)); // �U��
            return PlayerAction.Attack;
        }

        private async UniTask PerformAttack(Character attacker, Character defender) {
            Debug.Log($"{attacker.Name} �� {defender.Name} �ɍU���I");
            await UniTask.Delay(TimeSpan.FromSeconds(1)); // �A�j���[�V�����Đ�
            defender.TakeDamage(attacker.AttackPower);
            Debug.Log($"{defender.Name} ��HP: {defender.Health}");
        }

        private async UniTask PerformDefense(Character character) {
            Debug.Log($"{character.Name} �͖h��̑Ԑ���������I");
            await UniTask.Delay(TimeSpan.FromSeconds(1)); // �A�j���[�V�����Đ�
            character.Defend();
        }
    }

    public enum PlayerAction {
        Attack,
        Defend
    }

    public class Character {
        public string Name { get; set; }
        public int Health { get; set; }
        public int AttackPower { get; set; }

        public void TakeDamage(int damage) {
            Health -= damage;
        }

        public void Defend() {
            // �h�䎞�̏���
        }
    }

}