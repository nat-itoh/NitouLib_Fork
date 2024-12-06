using System.Threading;
using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using UnityEngine;
using UnityEngine.Playables;


namespace Demo.Sequencer {

    public class SceneEntryPoint : MonoBehaviour {

        [SerializeField] PlayableDirector _director;


        private  async void Start() {

        }


        public async UniTask PlayTimelineAsync() {

            if(_director == null){
                Debug.LogError("PlayableDirector���ݒ肳��Ă��܂���B");
                return;
            }

            // 
            _director.Play();

            await UniTask.WaitUntil(() => _director.state != PlayState.Playing);

            Debug.Log("�^�C�����C�����I�����܂����D");
        }


    }
}
