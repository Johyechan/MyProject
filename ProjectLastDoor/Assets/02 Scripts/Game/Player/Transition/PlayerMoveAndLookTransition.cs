using MyUtil.FSM;

namespace Game.Player.Transition
{
    // �ۼ���: ������
    // �÷��̾� �̵� �� �ü� ���·� �����ϴ� Ŭ����
    public class PlayerMoveAndLookTransition : PlayerTransitionBase
    {
        public PlayerMoveAndLookTransition(StateMachine machine, IState state) : base(machine, state)
        {
        }

        public override bool IsTransition()
        {
            throw new System.NotImplementedException();
        }
    }
}
// ������ �ۼ� ����: 2025.05.27
