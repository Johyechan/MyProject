using Game.Manager;
using MyUtil.FSM;

namespace Game.Player.Transition
{
    // 작성자: 조혜찬
    // 플레이어 상호장용 중인 상태로 전이하는 클래스
    public class PlayerInteractionTransition : PlayerTransitionBase
    {
        public PlayerInteractionTransition(StateMachine machine, IState state) : base(machine, state)
        {
        }

        public override bool IsTransition()
        {
            if(GameManager.Instance.IsInteractionOn) // 만약 상호작용이 되었다면
            {
                ChangeState(); // 상태 전이
                return true; // 상호작용 중인 상태로 전이 했다 또는 상호작용중인 상태여야 한다고 반환
            }

            return false; // 상호작용 중인 상태로 전이하지 않았다고 반환
        }
    }
}
// 마지막 작성 일자: 2025.05.27
