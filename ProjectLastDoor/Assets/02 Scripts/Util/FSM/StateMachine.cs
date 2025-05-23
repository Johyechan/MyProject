using UnityEngine;

// FSM 네임스페이스
namespace MyUtil.FSM
{
    // 작성자: 조혜찬
    // FSM을 관리하는 상태 머신
    public class StateMachine
    {
        private IState _currentState; // 현재 상태

        // 상태 변경 함수
        public void ChangeState(IState state)
        {
            _currentState?.OnExit(); // 현재 상태 나가기

            _currentState = state; // 현재 상태 변경

            _currentState?.OnEnter(); // 현재 상태 들어가기
        }

        // 매 프레임마다 반복할 현재 상태 실행중 기능
        public void UpdateExecute()
        {
            _currentState.OnExecute(); // 현재 상태 실행중
        }
    }
}

