using MyUtil.FSM;

namespace Game.Player.Transition
{
    // �ۼ���: ������
    // ��� ���·� �����ϴ� Ŭ����
    public class PlayerIdleTransition : PlayerTransitionBase
    {
        public PlayerIdleTransition(StateMachine machine, IState state) : base(machine, state)
        {
        }

        public override bool IsTransition()
        {
            return true;
        }
    }
}
// ������ �ۼ� ����: 2025.05.27
