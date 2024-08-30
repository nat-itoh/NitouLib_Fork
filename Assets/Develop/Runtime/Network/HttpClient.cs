using System.Threading;
using Cysharp.Threading.Tasks;

namespace nitou.Networking {

    public interface IHttpClient {

        UniTask<(HttpRequest.Result result, T respose)> SendAsync<T>(HttpRequest request, CancellationToken token)
            where T : HttpResponse, new();
    }


    public class HttpClient{

        /// <summary>
        /// ���N�G�X�g����ʐM���s���A���X�|���X���擾����
        /// ����/���s�ƃ��X�|���X��Ԃ�
        /// </summary>
        /// <param name="request"></param>
        /// <param name="token"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public async UniTask<(HttpRequest.Result result, T response)> Call<T>(HttpRequest request, CancellationToken token) where T : HttpResponse, new() {
            // await UnityWebRequest.Get(); // �{���͒ʐM�������s��

            // �ȈՔł̂��߁A�ʐM�������s�킸�ɐ����ƃf�t�H���g�̃I�u�W�F�N�g��Ԃ�
            await UniTask.Yield();
            var mockResponse = new T();
            return (new HttpRequest.Success(), mockResponse);
        }
    }
}
