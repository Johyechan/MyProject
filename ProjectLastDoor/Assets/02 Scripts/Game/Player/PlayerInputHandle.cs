using UnityEngine;
using UnityEngine.InputSystem;

// 플레이어와 관련된 기능들을 모아둔 네임스페이스
namespace Game.Player
{
    // 작성자: 조혜찬
    // 플레이어의 인풋을 처리하는 클래스
    public class PlayerInputHandle
    {
        private InputActionAsset _inputActionAsset; // 플레이어 인풋 에셋
        private InputActionMap _inputActionMap; // 플레이어 인풋에 있는 Player 맵
        private InputAction _inputMoveAction; // 플레이어 인풋에 있는 Move 액션
        private InputAction _inputLookAction; // 플레이어 인풋에 있는 Look 액션

        private Vector2 _moveVector; // 플레이어 이동 벡터를 받는 변수
        private Vector2 _lookVector; // 플레이어 방향 벡터를 받는 변수

        public Vector2 MoveVector // 플레이어 이동 벡터 프로퍼티
        {
            get
            {
                return _moveVector;
            }
        }

        public Vector2 LookVector // 플레이어 방향 벡터 프로퍼티
        {
            get
            {
                return _lookVector;
            }
        }

        // 생성자에서 에셋 초기화
        public PlayerInputHandle(InputActionAsset inputActionAsset)
        {
            _inputActionAsset = inputActionAsset;
        }

        // 활성화 되었을 때
        public void OnEnable()
        {
            _inputActionAsset.Enable(); // 플레이어 에셋 활성화

            _inputActionMap = _inputActionAsset.FindActionMap("Player"); // "Player" 이름을 가진 맵 탐색 및 할당
            _inputActionMap.Enable(); // "Player" 맵 활성화

            _inputMoveAction = _inputActionMap.FindAction("Move"); // "Player" 맵에서 "Move" 이름을 가진 액션 탐색 및 할당
            _inputMoveAction.Enable(); // "Move" 액션 활성화

            _inputLookAction = _inputActionMap.FindAction("Look"); // "Player" 맵에서 "Look" 이름을 가진 액션 탐색 및 할당
            _inputLookAction.Enable(); // "Look" 액션 활성화

            _inputMoveAction.performed += OnMove; // "Move" 액션에 OnMove 함수 구독
            _inputLookAction.performed += OnLook; // "Look" 액션에 OnLook 함수 구독
        }

        // 비활성화 되었을 때
        public void OnDisable()
        {
            _inputMoveAction.performed -= OnMove; // "Move" 액션에 OnMove 함수 구독 해제
            _inputLookAction.performed -= OnLook; // "Look" 액션에 OnLook 함수 구독 해제

            _inputLookAction.Disable(); // "Look" 액션 비활성화
            _inputMoveAction.Disable(); // "Move" 액션 비활성화
            _inputActionMap.Disable(); // "Player" 맵 비활성화
            _inputActionAsset.Disable(); // 플레이어 에셋 비활성화
        }

        public bool IsMoveInputCall() // 인풋이 계속 들어오고 있는지 확인하는 함수
        {
            if (_inputMoveAction.phase == InputActionPhase.Waiting) // 만약 인풋을 기다리는 상태라면
                return false; // false 반환

            return true; // 아닐경우 true 반환
        }

        private void OnMove(InputAction.CallbackContext context) // PlayerInput에게 이동 벡터를 받는 함수
        {
            _moveVector = context.ReadValue<Vector2>(); // Vector2로 읽어서 할당
        }

        private void OnLook(InputAction.CallbackContext context) // PlayerInput에게 방향 벡터를 받는 함수
        {
            _lookVector = context.ReadValue<Vector2>(); // Vector2로 읽어서 할당
        }
    }
}
// 마지막 작성 일자: 2025.05.19