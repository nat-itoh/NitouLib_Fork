using UnityEngine;
using UnityEngine.Pool;

// [�Q�l]
//  qiita: Unity�W����ObjectPool��ėp�I�Ɏg���N���X�̍쐬 https://qiita.com/KeichiMizutani/items/ca46a40de02e87b3d8a8
//  github: game-programming-patterns-demo https://github.com/Unity-Technologies/game-programming-patterns-demo

namespace nitou.DesignPattern.Pooling{

    /// <summary>
    /// �v�[�������I�u�W�F�N�g�̃C���^�[�t�F�[�X
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IPooledObject<T> where T : class {

        public IObjectPool<T> ObjectPool { set; }
        
        public void Initialize();
        
        public void Deactivate();
    }

}
