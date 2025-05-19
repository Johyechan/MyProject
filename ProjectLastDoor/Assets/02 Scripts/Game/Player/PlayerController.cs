using UnityEngine;
using UnityEngine.InputSystem;

// 플레이어와 관련된 기능들을 모아둔 네임스페이스
namespace Game.Player
{
    // 작성자: 조혜찬
    // 플레이어에게 필요한 기능들을 모아서 처리하는 클래스
    public class PlayerController : MonoBehaviour
    {
        [SerializeField] private InputActionAsset _inputActionAsset; // 실제 사용할 인풋 에셋

        [SerializeField] private float _moveSpeed; // 이동 속도

        private PlayerInputHandle _inputHandle; // 인풋을 처리하는 클래스
        private PlayerMovement _movement; // 움직임을 처리하는 클래스

        // 변수 초기화
        private void Awake()
        {
            _inputHandle = new PlayerInputHandle(_inputActionAsset);
            _movement = new PlayerMovement(transform, _moveSpeed);
        }

        private void OnEnable()
        {
            _inputHandle.OnEnable(); // 인풋 핸들의 활성화 함수 호출
        }

        private void OnDisable()
        {
            _inputHandle.OnDisable(); // 인풋 핸들의 비활성화 함수 호출
        }

        private void Update()
        {
            if(_inputHandle.IsInputCall())
            {
                _movement.Move(_inputHandle.MoveVector); // 매 프레임마다 움직임 함수 호출
            }
        }
    }
}
// 마지막 작성 일자: 2025.05.19