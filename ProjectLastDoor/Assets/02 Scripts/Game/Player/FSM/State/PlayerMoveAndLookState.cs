using MyUtil.FSM;
using UnityEngine;

// 플레이어 FSM 네임스페이스
namespace Game.Player.FSM
{
    // 작성자: 조혜찬
    // 움직임 및 시선 처리 상태
    public class PlayerMoveAndLookState : PlayerStateBase
    {
        private PlayerInputHandle _inputHandle;
        private PlayerMovement _movement;

        public PlayerMoveAndLookState(PlayerInputHandle inputHandle, PlayerMovement movement)
        {
            _inputHandle = inputHandle;
            _movement = movement;
        }

        // 실행중일 때
        public override void OnExecute()
        {
            base.OnExecute();

            if (_inputHandle.IsInputActionCalling("Look")) // "Look" 인풋의 콜 여부 확인
                _movement.Look(_inputHandle.LookVector); // 매 프레임마다 움직임 방향 바라보게 하는 함수 호출

            if (_inputHandle.IsInputActionCalling("Move")) // "Move" 인풋의 콜 여부 확인
                _movement.Move(_inputHandle.MoveVector); // 매 프레임마다 움직임 함수 호출
        }
    }
}
// 마지막 작성 일자: 2025.05.26
