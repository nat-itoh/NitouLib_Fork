using System;
using UnityEngine;
using nitou.GameSystem; // �C���ł�SimpleProcessBase�N���X���g�p

public class GameManager : MonoBehaviour {
    [SerializeField] private PauseMenuView pauseMenuController;

    private IProcess gameProcess;

    private async void Start() {
        // �Q�[���v���Z�X���쐬
        gameProcess = new GameProcess();

        // �|�[�Y���j���[��������
        pauseMenuController.Initialize(Unpause, Quit);

        // �Q�[���J�n
        gameProcess.Run();

        var result = await gameProcess.ProcessFinished;
    }

    private void Update() {
        // �|�[�Y����
        if (Input.GetKeyDown(KeyCode.Escape)) {
            if (gameProcess.State.Value == ProcessState.Running) {
                Pause();
            } 
            else if (gameProcess.State.Value == ProcessState.Paused) {
                Unpause();
            }
        }
    }

    private void Pause() {
        gameProcess.Pause();
        pauseMenuController.ShowPauseMenu();
    }

    private void Unpause() {
        pauseMenuController.HidePauseMenu();
        gameProcess.UnPause();
    }

    private void Quit() {
        gameProcess.Cancel(new CancelResult("User quit the game."));
        Application.Quit();
    }
}


public class GameProcess : SimpleProcessBase {
    protected override void OnStart() {
        Debug.Log("Game started!");
    }

    protected override void OnPause() {
        Debug.Log("Game paused!");
        Time.timeScale = 0f; // ���Ԃ��~�߂�

    }

    protected override void OnUnPause() {
        Debug.Log("Game resumed!");
        Time.timeScale = 1f; // ���Ԃ��ĊJ
    }

    protected override void OnCancel(CancelResult cancelResult) {
        Debug.Log($"Game cancelled: {cancelResult.Message}");
    }

    protected override void OnDispose() {
        Debug.Log("Game process disposed.");
    }
}
