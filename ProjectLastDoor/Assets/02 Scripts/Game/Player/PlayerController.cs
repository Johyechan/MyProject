using Game.Manager;
using UnityEngine;

// 플레이어와 관련된 기능들을 모아둔 네임스페이스
namespace Game.Player
{
    // 작성자: 조혜찬
    // 플레이어에게 필요한 기능들을 모아서 처리하는 클래스
    public class PlayerController : MonoBehaviour
    {
        [SerializeField] private float _moveSpeed; // 이동 속도
        [SerializeField] private float _disableDelay; // 비활성화 대기 시간
        [SerializeField] private float _enableDelay; // 활성화 대기 시간
        [SerializeField] private Transform _playerCamTrans;

        private PlayerInputHandle _inputHandle; // 인풋을 처리하는 클래스
        private PlayerMovement _movement; // 움직임을 처리하는 클래스

        // 변수 초기화
        private void Awake()
        {
            GameManager.Instance.Player = gameObject;

            _inputHandle = new PlayerInputHandle(this);
            _movement = new PlayerMovement(transform, _playerCamTrans, _moveSpeed);
        }

        // 객체 초기화
        private void Start()
        {
            transform.rotation = Quaternion.identity;
        }

        private void OnEnable()
        {
            if(InputManager.Instance != null)
            {
                InputManager.Instance.WaitAndEnable(_enableDelay, true); // 인풋 활성화
                _inputHandle.OnEnable(); // 인풋 핸들의 활성화 함수 호출
            }
        }

        private void OnDisable()
        {
            if(InputManager.Instance != null)
            {
                _inputHandle.OnDisable(); // 인풋 핸들의 비활성화 함수 호출
                InputManager.Instance.WaitAndEnable(_disableDelay, false); // 인풋 비활성화
            }
        }

        private void Update()
        {
            if (_inputHandle.IsInputActionCalling("Look")) // "Look" 인풋의 콜 여부 확인
                _movement.Look(_inputHandle.LookVector); // 매 프레임마다 움직임 방향 바라보게 하는 함수 호출

            if (_inputHandle.IsInputActionCalling("Move")) // "Move" 인풋의 콜 여부 확인
                _movement.Move(_inputHandle.MoveVector); // 매 프레임마다 움직임 함수 호출
        }
    }
}
// 마지막 작성 일자: 2025.05.21