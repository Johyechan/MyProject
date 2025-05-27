using MyUtil.FSM;
using MyUtil.Transition;

namespace Game.Player.Transition
{
    // �ۼ���: ������
    // �÷��̾� ���� ���� Ŭ������ �θ� Ŭ����
    public abstract class PlayerTransitionBase : ITransition
    {
        private StateMachine _machine; // ���� ���� �ӽ�

        private IState _changeState; // �ٲ� ����

        public PlayerTransitionBase(StateMachine machine, IState state)
        {
            _machine = machine;
            _changeState = state;
        }

        public abstract bool IsTransition(); // ���� ���� ���� Ȯ�� �Լ�

        // ���� ���� �Լ�
        protected void ChangeState(bool isNeedDelay = false, float delay = 0) // �����̰� �ʿ����� Ȯ�� �� �ʿ��ϴٸ� ������ ���� ����
        {
            if (_machine.IsCurrentState(_changeState)) // ���� �̹� ���� ���°� ���ؾ��ϴ� ���¿� �����ϴٸ� ���� ���� ���� �ʰ� ���� 
                return;

            if (isNeedDelay) // ���� �����̰� �ʿ��ϴٸ�
                _machine.ChangeStateWhenDelayEnd(_changeState, delay); // ������ �� ���� ����
            else // �ƴ϶��
                _machine.ChangeState(_changeState); // �ٷ� ���� ����
        }
    }
}
// ������ �ۼ� ����: 2025.05.27
