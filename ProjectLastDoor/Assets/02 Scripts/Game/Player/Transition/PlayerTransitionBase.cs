using MyUtil.FSM;
using MyUtil.Transition;

namespace Game.Player.Transition
{
    // 작성자: 조혜찬
    // 플레이어 상태 전이 클래스의 부모 클래스
    public abstract class PlayerTransitionBase : ITransition
    {
        private StateMachine _machine;

        private IState _changeState;

        public PlayerTransitionBase(StateMachine machine, IState state)
        {
            _machine = machine;
            _changeState = state;
        }

        public abstract bool IsTransition();

        protected void ChangeState(bool isNeedDelay = false, float delay = 0)
        {
            if (isNeedDelay)
                _machine.ChangeStateWhenDelayEnd(_changeState, delay);
            else
                _machine.ChangeState(_changeState);
        }
    }
}

