using UnityEngine;

namespace RPG
{
    // ��{�X�e�[�^�X��ێ�����L�����N�^�[�N���X
    public class Character {

        public string Name { get; private set; }

        public int MaxHP { get; private set; }
        public int MaxSP { get; private set; }
        
        public int Attack { get; private set; }
        public int Defense { get; private set; }
        public int Speed { get; private set; }

        /// <summary>
        /// �R���X�g���N�^�D
        /// </summary>
        public Character(string name, int maxHP, int maxSP, int attack, int defense, int speed) {
            Name = name;
            MaxHP = maxHP;
            MaxSP = maxSP;
            Attack = attack;
            Defense = defense;
            Speed = speed;
        }
    }

}
