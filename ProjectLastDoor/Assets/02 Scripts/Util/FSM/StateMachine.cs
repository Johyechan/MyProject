using UnityEngine;

namespace MyUtil.FSM
{
    // �ۼ���: ������
    // FSM�� �����ϴ� ���� �ӽ�
    public class StateMachine
    {
        private IState _currentState; // ���� ����
        private IState _delayChangeState; // ��� �� ����� ����

        private float _delayTime; // ��� �ð�
        private float _currentTime; // ���� �帥 �ð�

        private bool _isDelay = false; // ��Ⱑ �ʿ��� �������� Ȯ��

        // ���� ���� �Լ�
        public void ChangeState(IState state)
        {
            _currentState?.OnExit(); // ���� ���� ������

            _currentState = state; // ���� ���� ����

            _currentState?.OnEnter(); // ���� ���� ����
        }

        public void ChangeStateWhenDelayEnd(IState state, float delay)
        {
            _delayChangeState = state;
            _isDelay = true;
            _currentTime = 0;
            _delayTime = delay;
        }

        public bool IsCurrentState(IState state)
        {
            if (_currentState == state) return true;

            return false;
        }

        // �� �����Ӹ��� �ݺ��� ���� ���� ������ ���
        public void UpdateExecute()
        {
            if(_isDelay) // ��� �� �����ϴ� ������ ��
            {
                _currentTime += Time.deltaTime; // �ð� ����

                if(_currentTime >= _delayTime) // ������ �ð� �� �帥 �ð��� �����̺��� ũ�ų� ���ٸ�
                {
                    ChangeState(_delayChangeState); // �����صξ��� �����ð� ��� �� ����Ǿ�� �� ���·� �������� 
                    _isDelay = false; // ��� ���� ����
                }
            }
            _currentState.OnExecute(); // ���� ���� ������
        }
    }
}
// ������ �ۼ� ����: 2025.05.27
