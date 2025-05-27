using MyUtil.FSM;

namespace Game.Player.Transition
{
    // 작성자: 조혜찬
    // 대기 상태로 전이하는 클래스
    public class PlayerIdleTransition : PlayerTransitionBase
    {
        public PlayerIdleTransition(StateMachine machine, IState state) : base(machine, state)
        {
        }

        public override bool IsTransition()
        {
            return true;
        }
    }
}
// 마지막 작성 일자: 2025.05.27
