using UnityEngine;
using UnityEngine.InputSystem;

namespace Game.Map
{
    // 작성자: 조혜찬
    // 맵의 인풋 처리하는 클래스
    public class MapInput : MonoBehaviour
    {
        // 맵 인풋 에셋
        [SerializeField] private InputActionAsset _mapInputAsset;
        // "Gameplay" 액션 맵을 참조
        private InputActionMap _gameplayMap;
        // 구슬의 기울어짐을 체크하는 "Tilt" 액션
        private InputAction _tiltAction;

        // 기울어진 방향을 가지는 프로퍼티
        public Vector3 TiltValue { get; private set; }

        // 처음 기울어져 있는 방향을 기본 값으로 지정하기 위한 벡터 값
        private Vector3 _initTiltValue = Vector3.zero;

        // 초기화: 인풋 액션 맵과 액션 찾기
        private void Awake()
        {
            // "Gameplay" 액션 맵을 찾고, 그 안에서 "Tilt" 액션을 찾음
            _gameplayMap = _mapInputAsset.FindActionMap("Gameplay", true);
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
            Vector3 currentTilt = context.ReadValue<Vector3>();

            // 자동으로 현재 상태를 기본 상태로 만드는 것은 게임 시작 후 처음에만 하기 위해 zero일 때 초기화
            if (_initTiltValue == Vector3.zero)
            {
                ResetTilt(currentTilt);
            }

            // 특정 기울어진 값을 저장하는 변수를 현재 기울어진 값에서 뺀 값을 실제 기울어진 정도로 판단
            TiltValue = currentTilt - _initTiltValue;
        }

        // 현재 기울어진 상태를 기본 값으로 초기화 하기 위한 함수
        public void ResetTilt(Vector3 currentTilt)
        {
            // 현재 값에서 뺄 값을 현재 값으로 초기화
            _initTiltValue = currentTilt;
        }
    }
}
// 마지막 작성 일자: 2025.05.05
