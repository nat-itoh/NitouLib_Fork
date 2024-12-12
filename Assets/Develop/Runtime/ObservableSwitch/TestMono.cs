using UnityEngine;
using UniRx;

namespace Project {
}

public class Actor {
    // �U����
    public ReactiveProperty<int> AttackRP { get; } = new(0);
}

public class ActorSelectionController {
    // �I�𒆂̃A�N�^�[
    public ReactiveProperty<Actor> CurrentActorRP { get; } = new(null);
}


public class TestMono : MonoBehaviour {

    private ActorSelectionController _actorSelectionController = new();

    private void Start() {
        _actorSelectionController.CurrentActorRP
            .Where(actor => actor != null)
            
            // �ύX�ӏ�
            .SelectMany(actor => actor.AttackRP)
            //.Select(actor => actor.AttackRP)
            //.Switch()

            .Subscribe(attack => Debug.Log($"Actor's Attack : {attack}"))
            .AddTo(this);

        // �T���v���V�i���I
        SimulateActorSwitching();
    }

    private void SimulateActorSwitching() {
        // Actor�̐���
        var actor1 = new Actor();
        var actor2 = new Actor();

        // Actor1��I��
        _actorSelectionController.CurrentActorRP.Value = actor1;

        // Actor1��AttackRP��ύX
        actor1.AttackRP.Value = 1;
        actor1.AttackRP.Value = 2;
        actor1.AttackRP.Value = 3;

        // Actor2��I��
        _actorSelectionController.CurrentActorRP.Value = actor2;

        // Actor2��AttackRP��ύX
        actor2.AttackRP.Value = 10;
        actor2.AttackRP.Value = 20;
        actor2.AttackRP.Value = 30;

        // �Ă�Actor1��I��
        _actorSelectionController.CurrentActorRP.Value = actor1;

        // Actor1��AttackRP��ύX
        actor1.AttackRP.Value = 5;
        actor1.AttackRP.Value = 6;
        actor1.AttackRP.Value = 7;
    }
}
