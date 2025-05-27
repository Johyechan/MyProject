using Game.Manager;
using Game.Player.FSM;
using MyUtil.FSM;
using MyUtil.Transition;
using UnityEngine;
using UnityEngine.UI;

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
        [SerializeField] private float _rayDistance; // 레이 감지 거리

        [SerializeField] private Transform _playerCamTrans; // 플레이어 카메라

        [SerializeField] private Image _guideImage; // 상호작용 키 가이드 UI

        private PlayerInputHandle _inputHandle; // 인풋을 처리하는 클래스
        private PlayerMovement _movement; // 움직임을 처리하는 클래스
        private PlayerInteractionRaycaster _interactionRaycast; // 상호작용을 처리하는 클래스

        private StateMachine _machine; // 상태 전이 머신

        private IState _idleState; // 대기 상태
        private IState _moveAndLookState; // 움직임 및, 시점 변경 가능 상태
        private IState _interactionState; // 상호작용 중인 상태

        private ITransition _idleTransition; // 대기 상태 전이
        private ITransition _moveAndLookTransition; // 움직임 및 시선 변경 가능 상태 전이
        private ITransition _interactionTransition; // 상호작용 중인 상태 전이

        private void OnDrawGizmos()
        {
            Gizmos.DrawRay(_playerCamTrans.position, _playerCamTrans.forward * _rayDistance);
        }

        // 변수 초기화
        private void Awake()
        {
            GameManager.Instance.Player = gameObject;

            _inputHandle = new PlayerInputHandle(this);
            _movement = new PlayerMovement(transform, _playerCamTrans, _moveSpeed);
            _interactionRaycast = new PlayerInteractionRaycaster(_guideImage, _rayDistance);

            _machine = new StateMachine();

            _idleState = new PlayerIdleState();
            _moveAndLookState = new PlayerMoveAndLookState(_inputHandle, _movement);
            _interactionState = new PlayerInteractionState();

            _machine.ChangeState(_idleState); // 첫 상태를 대기 상태로 지정
            _machine.ChangeStateWhenDelayEnd(_moveAndLookState, 5f); // 일정 시간 후 움직임 및 시선 조정 가능 상태로 변경
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
            if (_interactionRaycast.IsOnInteractionObject(GameManager.Instance.IsNeedMousePos)) // 상호작용 객체를 감지했으며
            {
                if (_inputHandle.IsInteraction) // 상호작용 키를 눌렀다면
                {
                    GameManager.Instance.IsInteractionOn = true; // 상호작용 중이라고 선언
                    _inputHandle.IsInteraction = false; // 클릭 상태 초기화
                    _interactionRaycast.PlayInteraction(); // 상호작용
                }
            }

            _machine.UpdateExecute();
        }
    }
}
// 마지막 작성 일자: 2025.05.22