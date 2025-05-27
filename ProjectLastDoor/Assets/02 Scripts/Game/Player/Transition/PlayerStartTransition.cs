using MyUtil.FSM;

namespace Game.Player.Transition
{
    // 작성자: 조혜찬
    // 대기 상태로 전이하는 클래스
    public class PlayerStartTransition : PlayerTransitionBase
    {
        private PlayerVariables _variables;

        public PlayerStartTransition(StateMachine machine, IState state, PlayerVariables variables) : base(machine, state)
        {
            _variables = variables;
        }

        // 상태 전이 조건 확인 함수
        public override bool IsTransition()
        {
            if(_variables.IsStart) // 만약 시작이라면
            {
                ChangeState(); // 상태 전이
                return true; // 시작 상태로 전이 했다 또는 시작 상태여야 한다고 반환
            }

            return false; // 시작 상태로 전이 하지 않았다고 반환
        }
    }
}
// 마지막 작성 일자: 2025.05.27
