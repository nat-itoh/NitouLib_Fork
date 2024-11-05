using UnityEngine;
using Cysharp.Threading.Tasks;

namespace RPG
{
    public class BattleTest : MonoBehaviour
    {
        private TurnManager turnManager;

        private async void Start() {

            // �L�����N�^�[�̏�����
            var playerCharacter = new Character("Hero", 100, 30, 20, 10, 5);
            var enemyCharacter = new Character("Slime", 80, 20, 15, 5, 3);

            // �o�g���[�̏�����
            var player = new Battler(playerCharacter);
            var enemy = new Battler(enemyCharacter);

            // �v���C���[���G���U��
            player.AttackTarget(enemy);

            // �x�������ĘA���ł̍U�����m�F
            await UniTask.Delay(1000);

            // �G���v���C���[���U��
            enemy.AttackTarget(player);

            /*

            // TurnManager�̏�����
            turnManager = new TurnManager();

            // �o�g���̊J�n�i�e�X�g�p�j
            await turnManager.StartBattle();
            */

        }
    }
}
