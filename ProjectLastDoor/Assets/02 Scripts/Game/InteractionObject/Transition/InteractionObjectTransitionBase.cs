using MyUtil.FSM;
using MyUtil.Transition;
using UnityEngine;

namespace Game.InteractionObject.Transition
{
    // 작성자: 조혜찬
    // 상호작용 객체 전이의 부모 클래스
    public abstract class InteractionObjectTransitionBase : ITransition
    {
        private StateMachine _machine; // 상태 전이 머신

        private IState _changeState; // 바꿀 상태

        // 생성자에서 변수 초기화
        public InteractionObjectTransitionBase(StateMachine machine, IState changeState)
        {
            _machine = machine;
            _changeState = changeState;
        }

        public abstract bool IsTransition(); // 상태 전이 조건 확인 함수

        // 상태 전이, 매개변수에 따라 딜레이 후 상태 변화까지 가능한 함수
        protected void ChangeState(bool isNeedDelay = false, float delay = 0f)
        {
            if (_machine.IsCurrentState(_changeState)) // 이미 변경해야할 상태라면 그냥 변경시키 않고 리턴
                return;

            if (isNeedDelay) // 상태를 전이 시키기 전 대기 시간이 필요한가?
                _machine.ChangeStateWhenDelayEnd(_changeState, delay); // 대기 후 상태 전이
            else // 아니라면
                _machine.ChangeState(_changeState); // 바로 상태 전이
        }
    }
}
// 마지막 작성 일자: 2025.05.28
