using System;
using System.Threading;
using Cysharp.Threading.Tasks;
using UniRx;
using UnityEngine;
using UnityEngine.UI;



public class RetryOnErrorExample : MonoBehaviour {
    void Start() {
        Observable.Timer(TimeSpan.FromSeconds(3))  // 3�b��ɊJ�n
            .SelectMany(_ => FetchAsync().ToObservable())  // �񓯊��̃f�[�^�擾���\�b�h
            .Retry(3)  // �ő�3�񃊃g���C
            .Catch<string, Exception>((ex) => {  // ���ׂĎ��s�����ꍇ�̏���
                Debug.Log("3�񎸔s���܂���: " + ex.Message);
                return Observable.Empty<string>();  // �G���[���ɋ��Observable��Ԃ�
            })
            .Subscribe(
                result => Debug.Log("����: " + result),  // ���������ꍇ�̏���
                error => Debug.Log("�G���[����: " + error.Message)  // �G���[�������̏���
            );
    }

    // �񓯊��f�[�^�擾���\�b�h�i��j
    private async UniTask<string> FetchAsync() {
        // �����ł̓G���[�𔭐������Ă݂܂��i�{���̓f�[�^�擾�����������j
        bool isSuccess = UnityEngine.Random.Range(0, 2) == 0;  // �����_���ɐ���/���s�����߂�
        Debug.Log("try fetch");
        await UniTask.WaitForSeconds(1);  // �[���I�Ȕ񓯊�����
        if (isSuccess) {
            return "�f�[�^�擾����";
        } else {
            throw new Exception("�f�[�^�擾���s");
        }
    }
}





// 5
public class DataBindingExample : MonoBehaviour {
    private ReactiveProperty<string> inputText = new ReactiveProperty<string>("");

    void Start() {
        // ������inputText�̕ύX��1�b���ƂɃ��O�ɏo�͂����悤�ɐݒ�
    }

    public void OnInputChanged(string text) {
        inputText.Value = text;
    }
}


// 6
public class TimedFeedbackExample : MonoBehaviour {
    public Button targetButton;

    void Start() {
        // �����ɁA�{�^���������Ă���5�b�ȓ���2��ڂ̉������s���邩�`�F�b�N���郍�W�b�N���L�q
    }
}




// 7
public class AsyncOperationExample : MonoBehaviour {
    public Button fetchDataButton;

    void Start() {
        // �{�^�����N���b�N�Ŕ񓯊�������J�n�A�ēx�N���b�N�ŃL�����Z�����郍�W�b�N���L�q
    }

    private async UniTask FetchDataAsync(CancellationToken token) {
        // �񓯊��Ńf�[�^���擾�����Ƃ���3�b�ҋ@
        await UniTask.Delay(3000, cancellationToken: token);
        Debug.Log("Data fetched");
    }
}




// 8 


// 9 
