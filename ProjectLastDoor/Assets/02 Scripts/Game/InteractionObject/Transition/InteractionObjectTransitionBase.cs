using MyUtil.FSM;
using MyUtil.Transition;
using UnityEngine;

namespace Game.InteractionObject.Transition
{
    // �ۼ���: ������
    // ��ȣ�ۿ� ��ü ������ �θ� Ŭ����
    public abstract class InteractionObjectTransitionBase : ITransition
    {
        private StateMachine _machine; // ���� ���� �ӽ�

        private IState _changeState; // �ٲ� ����

        // �����ڿ��� ���� �ʱ�ȭ
        public InteractionObjectTransitionBase(StateMachine machine, IState changeState)
        {
            _machine = machine;
            _changeState = changeState;
        }

        public abstract bool IsTransition(); // ���� ���� ���� Ȯ�� �Լ�

        // ���� ����, �Ű������� ���� ������ �� ���� ��ȭ���� ������ �Լ�
        protected void ChangeState(bool isNeedDelay = false, float delay = 0f)
        {
            if (_machine.IsCurrentState(_changeState)) // �̹� �����ؾ��� ���¶�� �׳� �����Ű �ʰ� ����
                return;

            if (isNeedDelay) // ���¸� ���� ��Ű�� �� ��� �ð��� �ʿ��Ѱ�?
                _machine.ChangeStateWhenDelayEnd(_changeState, delay); // ��� �� ���� ����
            else // �ƴ϶��
                _machine.ChangeState(_changeState); // �ٷ� ���� ����
        }
    }
}
// ������ �ۼ� ����: 2025.05.28
