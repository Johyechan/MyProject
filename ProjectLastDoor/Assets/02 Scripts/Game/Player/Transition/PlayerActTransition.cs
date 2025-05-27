using Game.Manager;
using MyUtil.FSM;

namespace Game.Player.Transition
{
    // 작성자: 조혜찬
    // 플레이어 모든 행동 상태로 전이하는 클래스
    public class PlayerActTransition : PlayerTransitionBase
    {
        private PlayerVariables _variables;

        public PlayerActTransition(StateMachine machine, IState state, PlayerVariables variables) : base(machine, state)
        {
            _variables = variables;
        }

        public override bool IsTransition()
        {
            if(!GameManager.Instance.IsInteractionOn && !_variables.IsStart) // 상호작용 중인 상태가 아니며 시작 상태도 아닐경우
            {
                ChangeState(); // 상태 전이
                return true; // 행동 상태로 전이했다고 또는 행동 상태여야 한다고 반환
            }

            return false; // 행동 상태로 전이하지 않았다고 반환
        }
    }
}
// 마지막 작성 일자: 2025.05.27
