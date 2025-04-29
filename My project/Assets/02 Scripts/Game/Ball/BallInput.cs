using UnityEngine;
using UnityEngine.InputSystem;

namespace Game.Ball
{
    // 작성자: 조혜찬
    // 구슬의 인풋 처리하는 클래스
    public class BallInput : MonoBehaviour
    {
        // 구슬의 인풋 시스템 에셋
        [SerializeField] private InputActionAsset _ballInputAsset;
        // "Gameplay" 액션 맵을 참조
        private InputActionMap _gameplayMap;
        // 구슬의 기울어짐을 체크하는 "Tilt" 액션
        private InputAction _tiltAction;

        // 기울어진 방향을 가지는 프로퍼티
        public Vector3 TiltValue { get; private set; }

        // 초기화: 인풋 액션 맵과 액션 찾기
        private void Awake()
        {
            // "Gameplay" 액션 맵을 찾고, 그 안에서 "Tilt" 액션을 찾음
            _gameplayMap = _ballInputAsset.FindActionMap("Gameplay", true);
            _tiltAction = _gameplayMap.FindAction("Tilt", true);
        }

        // 객체 활성화 시: 액션을 활성화하고, 기울기 액션에 대한 이벤트 구독
        private void OnEnable()
        {
            _tiltAction.Enable();
            _tiltAction.performed += OnTiltPerformed;
        }

        // 객체 비활성화 시: 이벤트 구독 해제 및 액션 비활성화
        private void OnDisable()
        {
            _tiltAction.performed -= OnTiltPerformed;
            _tiltAction.Disable();
        }

        // 기울어진 방향을 받아오는 메서드
        private void OnTiltPerformed(InputAction.CallbackContext context)
        {
            // 기울어진 방향의 값을 저장
            TiltValue = context.ReadValue<Vector3>();
        }
    }
}
// 마지막 작성 일자: 2025.04.29
