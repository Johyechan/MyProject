using MyUtil.FSM;

namespace Game.Player.Transition
{
    // �ۼ���: ������
    // ��� ���·� �����ϴ� Ŭ����
    public class PlayerStartTransition : PlayerTransitionBase
    {
        private PlayerVariables _variables;

        public PlayerStartTransition(StateMachine machine, IState state, PlayerVariables variables) : base(machine, state)
        {
            _variables = variables;
        }

        // ���� ���� ���� Ȯ�� �Լ�
        public override bool IsTransition()
        {
            if(_variables.IsStart) // ���� �����̶��
            {
                ChangeState(); // ���� ����
                return true; // ���� ���·� ���� �ߴ� �Ǵ� ���� ���¿��� �Ѵٰ� ��ȯ
            }

            return false; // ���� ���·� ���� ���� �ʾҴٰ� ��ȯ
        }
    }
}
// ������ �ۼ� ����: 2025.05.27
