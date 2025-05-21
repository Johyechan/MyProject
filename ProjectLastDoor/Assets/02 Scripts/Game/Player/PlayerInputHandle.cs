using Game.Manager;
using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

// 플레이어와 관련된 기능들을 모아둔 네임스페이스
namespace Game.Player
{
    // 작성자: 조혜찬
    // 플레이어의 인풋을 처리하는 클래스
    public class PlayerInputHandle
    {
        private MonoBehaviour _mono; // 코루틴을 실행시킬 변수

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

        // 생성자에서 MonoBehaviour 초기화
        public PlayerInputHandle(MonoBehaviour mono)
        {
            _mono = mono;
        }

        public void OnEnable()
        {
            _mono.StartCoroutine(WaitAndSubscribeCo()); // 인풋 매니저에 인풋 맵, 액션들이 전부 저장될 때까지 대기 후 액션 구독하는 코루틴 실행
        }

        public void OnDisable()
        {
            if(InputManager.Instance.GetInputAction("Move") != null)
                InputManager.Instance.GetInputAction("Move").performed -= OnMove; // "Move" 액션 이벤트 구독 해제
            if (InputManager.Instance.GetInputAction("Look") != null)
                InputManager.Instance.GetInputAction("Look").performed -= OnLook; // "Look" 액션 이벤트 구독 해제
        }

        public bool IsInputActionCalling(string key) // 인풋이 계속 들어오고 있는지 확인하는 함수
        {
            if (InputManager.Instance.GetInputAction(key).phase == InputActionPhase.Waiting) // 만약 인풋을 기다리는 상태라면
                return false; // false 반환

            return true; // 아닐경우 true 반환
        }

        // 초기화 대기 후 구독하는 코루틴
        private IEnumerator WaitAndSubscribeCo()
        {
            yield return new WaitUntil(() => InputManager.Instance.IsInitialized); // 인풋 매니저 초기화가 완료될 때까지 대기

            InputManager.Instance.GetInputAction("Move").performed += OnMove; // "Move" 액션 이벤트 구독
            InputManager.Instance.GetInputAction("Look").performed += OnLook; // "Look" 액션 이벤트 구독
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
// 마지막 작성 일자: 2025.05.21