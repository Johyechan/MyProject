using Game.Manager;
using MyUtil.FSM;

namespace Game.Player.Transition
{
    // 작성자: 조혜찬
    // 플레이어 상호장용 중인 상태로 전이하는 클래스
    public class PlayerInteractionTransition : PlayerTransitionBase
    {
        private PlayerInteractionRaycaster _interactionRaycaster;
        private PlayerInputHandle _inputHandle;

        public PlayerInteractionTransition(StateMachine machine, IState state, PlayerInteractionRaycaster interactionRaycaster, PlayerInputHandle inputHandle) : base(machine, state)
        {
            _interactionRaycaster = interactionRaycaster;
            _inputHandle = inputHandle;
        }

        public override bool IsTransition()
        {
            if (_interactionRaycaster.IsOnInteractionObject(GameManager.Instance.IsNeedMousePos)) // 상호작용 객체를 감지했으며
            {
                if (_inputHandle.IsInteraction) // 상호작용 키를 눌렀다면
                {
                    GameManager.Instance.IsInteractionOn = true; // 상호작용 중이라고 선언
                    _inputHandle.IsInteraction = false; // 클릭 상태 초기화
                    _interactionRaycaster.PlayInteraction(); // 상호작용
                    ChangeState();
                    return true;
                }
            }

            return false;
        }
    }
}
// 마지막 작성 일자: 2025.05.27
