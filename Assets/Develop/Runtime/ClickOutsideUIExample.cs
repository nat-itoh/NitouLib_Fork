using UnityEngine;
using UnityEngine.EventSystems;
using UniRx;

public class ClickOutsideUIExample : MonoBehaviour {
    public GameObject[] uiElements; // �N���b�N���o�Ώۂ�UI�v�f

    void Start() {
        // EventSystem����S�ẴN���b�N�C�x���g���Ď�
        Observable.EveryUpdate()
            .Where(_ => Input.GetMouseButtonDown(0)) // ���N���b�N�����o
            .Select(_ => EventSystem.current.IsPointerOverGameObject()) // UI��ɃJ�[�\�������邩�`�F�b�N
            .Where(isOverUI => !isOverUI) // UI��ɂȂ��ꍇ�̂�
            .Subscribe(_ => Debug.Log("Clicked outside of specified UI elements"))
            .AddTo(this);
    }
}
