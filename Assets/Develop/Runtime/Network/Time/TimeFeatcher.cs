using UnityEngine;
using System.Threading;
using Cysharp.Threading.Tasks;
using nitou.Networking;

namespace Project{

    /// <summary>
    /// 
    /// </summary>
    public class TimeRequest : HttpRequest {
        public override string Path => "http://worldtimeapi.org/api/timezone/Etc/UTC";
    }

    /// <summary>
    /// 
    /// </summary>
    [System.Serializable]
    public class TimeResponse : HttpResponse {
        public string datetime; // JSON�� "datetime" �t�B�[���h���}�b�s���O
    }


    public class TimeFeatcher : MonoBehaviour {

        private HttpClient httpClient;

        async void Start() {
            httpClient = new HttpClient();

            Debug.Log("���^�[���������Ă��������D");
            await UniTask.WaitUntil(() => Input.GetKeyDown(KeyCode.Return));

            Debug.Log("�ʐM���J�n���܂��D");
            FetchTimeAsync().Forget(); // �񓯊������̊J�n
        }

        // �񓯊��Ń��b�N��API���玞�����擾
        async UniTaskVoid FetchTimeAsync() {
            var request = new TimeRequest();
            var token = new CancellationToken(); // �K�v�ɉ����ăL�����Z���������\

            // ���b�N��API�ʐM���s��
            (HttpRequest.Result result, TimeResponse response) = await httpClient.SendAsync<TimeResponse>(request, token);

            if (result.IsSuccess()) {
                Debug.Log("Current UTC Time (Mock): " + response.datetime);
            } else {
                Debug.LogError("Failed to fetch time (Mock).");
            }
        }
    }
}
