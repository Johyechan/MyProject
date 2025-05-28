using Game.Manager;
using UnityEngine;

namespace Game.Player.FSM
{
    // 작성자: 조혜찬
    // 플레이어의 모든 행동(플레이 하는 것) 처리 상태
    public class PlayerActState : PlayerStateBase
    {
        private PlayerInputHandle _inputHandle;
        private PlayerAct _act;
        private PlayerInteractionRaycaster _interactionRaycaster;

        public PlayerActState(PlayerInputHandle inputHandle, PlayerAct act, PlayerInteractionRaycaster interactionRaycaster)
        {
            _inputHandle = inputHandle;
            _act = act;
            _interactionRaycaster = interactionRaycaster;
        }

        public override void OnEnter()
        {
            base.OnEnter();

            if (InputManager.Instance != null)
            {
                InputManager.Instance.InputSetEnable("Move", false, true); // 움직임 활성화
                InputManager.Instance.InputSetEnable("Look", false, true); // 시선 조정 활성화
                InputManager.Instance.InputSetEnable("Interaction", false, true); // 상호작용 활성화
            }
        }

        // 실행중일 때
        public override void OnExecute()
        {
            base.OnExecute();

            if (_interactionRaycaster.IsOnInteractionObject(GameManager.Instance.IsNeedMousePos)) // 상호작용 객체를 감지했으며
            {
                if (_inputHandle.IsInteraction) // 상호작용 키를 눌렀다면
                {
                    GameManager.Instance.IsInteractionOn = true; // 상호작용 중이라고 선언
                    _inputHandle.IsInteraction = false; // 클릭 상태 초기화

                    _interactionRaycaster.PlayInteraction(); // 상호작용
                }
            }

            if (_inputHandle.IsInputActionCalling("Look")) // "Look" 인풋의 콜 여부 확인
                _act.Look(_inputHandle.LookVector); // 매 프레임마다 움직임 방향 바라보게 하는 함수 호출

            if (_inputHandle.IsInputActionCalling("Move")) // "Move" 인풋의 콜 여부 확인
                _act.Move(_inputHandle.MoveVector); // 매 프레임마다 움직임 함수 호출
        }

        public override void OnExit()
        {
            base.OnExit();

            if (InputManager.Instance != null)
            {
                InputManager.Instance.InputSetEnable("Move", false, false); // 움직임 비활성화
                InputManager.Instance.InputSetEnable("Look", false, false); // 시선 조정 비활성화
            }
        }
    }
}
// 마지막 작성 일자: 2025.05.28
