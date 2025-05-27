using UnityEngine;

namespace MyUtil.FSM
{
    // 작성자: 조혜찬
    // FSM을 관리하는 상태 머신
    public class StateMachine
    {
        private IState _currentState; // 현재 상태
        private IState _delayChangeState; // 대기 후 변경될 상태

        private float _delayTime; // 대기 시간
        private float _currentTime; // 현재 흐른 시간

        private bool _isDelay = false; // 대기가 필요한 상태인지 확인

        // 상태 변경 함수
        public void ChangeState(IState state)
        {
            _currentState?.OnExit(); // 현재 상태 나가기

            _currentState = state; // 현재 상태 변경

            _currentState?.OnEnter(); // 현재 상태 들어가기
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

        // 매 프레임마다 반복할 현재 상태 실행중 기능
        public void UpdateExecute()
        {
            if(_isDelay) // 대기 후 변경하는 상태일 때
            {
                _currentTime += Time.deltaTime; // 시간 축적

                if(_currentTime >= _delayTime) // 축적된 시간 즉 흐른 시간이 딜레이보다 크거나 같다면
                {
                    ChangeState(_delayChangeState); // 저장해두었던 일정시간 대기 후 변경되어야 할 상태로 상태전이 
                    _isDelay = false; // 대기 상태 종료
                }
            }
            _currentState.OnExecute(); // 현재 상태 실행중
        }
    }
}
// 마지막 작성 일자: 2025.05.27
