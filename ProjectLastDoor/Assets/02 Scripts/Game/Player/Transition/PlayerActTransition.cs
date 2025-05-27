using Game.Manager;
using MyUtil.FSM;

namespace Game.Player.Transition
{
    // �ۼ���: ������
    // �÷��̾� ��� �ൿ ���·� �����ϴ� Ŭ����
    public class PlayerActTransition : PlayerTransitionBase
    {
        private PlayerVariables _variables;

        public PlayerActTransition(StateMachine machine, IState state, PlayerVariables variables) : base(machine, state)
        {
            _variables = variables;
        }

        public override bool IsTransition()
        {
            if(!GameManager.Instance.IsInteractionOn && !_variables.IsStart) // ��ȣ�ۿ� ���� ���°� �ƴϸ� ���� ���µ� �ƴҰ��
            {
                ChangeState(); // ���� ����
                return true; // �ൿ ���·� �����ߴٰ� �Ǵ� �ൿ ���¿��� �Ѵٰ� ��ȯ
            }

            return false; // �ൿ ���·� �������� �ʾҴٰ� ��ȯ
        }
    }
}
// ������ �ۼ� ����: 2025.05.27
