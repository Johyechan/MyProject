using UnityEngine;

// FSM ���ӽ����̽�
namespace MyUtil.FSM
{
    // �ۼ���: ������
    // FSM�� �����ϴ� ���� �ӽ�
    public class StateMachine
    {
        private IState _currentState; // ���� ����

        // ���� ���� �Լ�
        public void ChangeState(IState state)
        {
            _currentState?.OnExit(); // ���� ���� ������

            _currentState = state; // ���� ���� ����

            _currentState?.OnEnter(); // ���� ���� ����
        }

        // �� �����Ӹ��� �ݺ��� ���� ���� ������ ���
        public void UpdateExecute()
        {
            _currentState.OnExecute(); // ���� ���� ������
        }
    }
}

