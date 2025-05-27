using Game.Manager;
using MyUtil.FSM;

namespace Game.Player.Transition
{
    // �ۼ���: ������
    // �÷��̾� ��ȣ��� ���� ���·� �����ϴ� Ŭ����
    public class PlayerInteractionTransition : PlayerTransitionBase
    {
        public PlayerInteractionTransition(StateMachine machine, IState state) : base(machine, state)
        {
        }

        public override bool IsTransition()
        {
            if(GameManager.Instance.IsInteractionOn) // ���� ��ȣ�ۿ��� �Ǿ��ٸ�
            {
                ChangeState(); // ���� ����
                return true; // ��ȣ�ۿ� ���� ���·� ���� �ߴ� �Ǵ� ��ȣ�ۿ����� ���¿��� �Ѵٰ� ��ȯ
            }

            return false; // ��ȣ�ۿ� ���� ���·� �������� �ʾҴٰ� ��ȯ
        }
    }
}
// ������ �ۼ� ����: 2025.05.27
