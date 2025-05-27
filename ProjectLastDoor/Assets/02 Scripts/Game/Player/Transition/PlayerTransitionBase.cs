using MyUtil.FSM;
using MyUtil.Transition;

namespace Game.Player.Transition
{
    // 작성자: 조혜찬
    // 플레이어 상태 전이 클래스의 부모 클래스
    public abstract class PlayerTransitionBase : ITransition
    {
        private StateMachine _machine; // 상태 전이 머신

        private IState _changeState; // 바꿀 상태

        public PlayerTransitionBase(StateMachine machine, IState state)
        {
            _machine = machine;
            _changeState = state;
        }

        public abstract bool IsTransition(); // 상태 전이 조건 확인 함수

        // 상태 전이 함수
        protected void ChangeState(bool isNeedDelay = false, float delay = 0) // 딜레이가 필요한지 확인 후 필요하다면 딜레이 값을 지정
        {
            if (_machine.IsCurrentState(_changeState)) // 만약 이미 현재 상태가 변해야하는 상태와 동일하다면 상태 전이 하지 않고 리턴 
                return;

            if (isNeedDelay) // 만약 딜레이가 필요하다면
                _machine.ChangeStateWhenDelayEnd(_changeState, delay); // 딜레이 후 상태 전이
            else // 아니라면
                _machine.ChangeState(_changeState); // 바로 상태 전이
        }
    }
}
// 마지막 작성 일자: 2025.05.27
