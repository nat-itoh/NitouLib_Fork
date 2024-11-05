using UnityEngine;

namespace RPG {

    // �퓬�p�̃L�����N�^�[�N���X�iBattler�j
    public class Battler {
        
        private readonly Character _character;
        

        public int CurrentHP { get; private set; }
        
        public int CurrentSP { get; private set; }


        public int AttackPower => _character.Attack;
        
        public int DefensePower => _character.Defense;


        /// ----------------------------------------------------------------------------
        // Public Method

        public Battler(Character character) {
            this._character = character;
            CurrentHP = character.MaxHP;
            CurrentSP = character.MaxSP;
        }

        // �_���[�W�v�Z
        public void TakeDamage(int damage) {
            CurrentHP -= damage;
            if (CurrentHP < 0)
                CurrentHP = 0;

            Debug.Log($"{_character.Name} took {damage} damage! Remaining HP: {CurrentHP}");
        }

        // �ΏۂɍU�����s��
        public void AttackTarget(Battler target) {
            int damage = CalculateDamage(target);
            target.TakeDamage(damage);
        }

        // �_���[�W�v�Z��
        private int CalculateDamage(Battler target) {
            int baseDamage = AttackPower - target.DefensePower;
            return Mathf.Max(1, baseDamage); // �Œ�ł�1�_���[�W��^����
        }
    }
}
