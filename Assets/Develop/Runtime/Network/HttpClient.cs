using System.Threading;
using Cysharp.Threading.Tasks;
using UnityEngine.Networking;

// [�Q�l]
//  qiita:  UniTask�׋���`����������Ȃ���`

namespace nitou.Networking {

    /// <summary>
    /// �ʐM�������s���N���C�A���g
    /// </summary>
    public interface IHttpClient {

        /// <summary>
        /// ���N�G�X�g�𑗐M����
        /// </summary>
        UniTask<(HttpRequest.Result result, T response)> SendAsync<T>(HttpRequest request, CancellationToken token)
            where T : HttpResponse, new();
    }


    public class HttpClient: IHttpClient{

        /// <summary>
        /// ���N�G�X�g����ʐM���s���A���X�|���X���擾����D
        /// ����/���s�ƃ��X�|���X��Ԃ��D
        /// </summary>
         public async UniTask<(HttpRequest.Result result, T response)> SendAsync<T>(HttpRequest request, CancellationToken token) 
            where T : HttpResponse, new() {

            // Web Request
            var webRequest = UnityWebRequest.Get(request.Path);
            await webRequest.SendWebRequest().ToUniTask(cancellationToken:token);

            // �ȈՔł̂��߁A�ʐM�������s�킸�ɐ����ƃf�t�H���g�̃I�u�W�F�N�g��Ԃ�
            await UniTask.Yield();
            var mockResponse = new T();

            if (webRequest.isHttpError) {

                
            }

            return (new HttpRequest.Success(), mockResponse);
        }
    }
}
