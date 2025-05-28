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
                InputManager.Instance.WaitAndEnable(true); // 인풋 활성화
                _inputHandle.OnEnable(); // 인풋 핸들의 활성화 함수 호출
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
                    Debug.Log("상호작용");
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

            // 여기서 완전히 꺼버려서 문제 이건 Disable로 옮기고 여기서는 wasd + 마우스 커서 인풋 액션만 비활성화 시키면 됨
            if (InputManager.Instance != null)
            {
                _inputHandle.OnDisable(); // 인풋 핸들의 비활성화 함수 호출
                InputManager.Instance.WaitAndEnable(false); // 인풋 비활성화
            }
        }
    }
}
// 마지막 작성 일자: 2025.05.27
