using Game.Manager;
using Game.Player.FSM;
using Game.Player.Transition;
using MyUtil.FSM;
using MyUtil.Transition;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Game.Player
{
    // 작성자: 조혜찬
    // 플레이어에게 필요한 변수들을 모아둔 클래스
    public class PlayerVariables : MonoBehaviour
    {
        [SerializeField] protected float _moveSpeed; // 이동 속도
        [SerializeField] protected float _disableDelay; // 비활성화 대기 시간
        [SerializeField] protected float _enableDelay; // 활성화 대기 시간
        [SerializeField] protected float _rayDistance; // 레이 감지 거리

        [SerializeField] protected Transform _playerCamTrans; // 플레이어 카메라

        [SerializeField] protected Image _guideImage; // 상호작용 키 가이드 UI

        protected PlayerInputHandle _inputHandle; // 인풋을 처리하는 클래스
        protected PlayerAct _act; // 행동을 처리하는 클래스
        protected PlayerInteractionRaycaster _interactionRaycaster; // 상호작용을 처리하는 클래스

        protected StateMachine _machine; // 상태 전이 머신
        protected TransitionHandle _transitionHandle; // 상태 전이 핸들

        protected IState _startState; // 시작(처음 플레이어가 깨어난 시점) 상태
        protected IState _actState; // 실제로 플레이 가능한(모든 행동이 가능한) 상태
        protected IState _interactionState; // 상호작용 중인 상태

        protected ITransition _startTransition; // 시작(처음 플레이어가 깨어난 시점) 상태 전이
        protected ITransition _actTransition; // 실제로 플레이 가능한(모든 행동이 가능한) 상태 전이
        protected ITransition _interactionTransition; // 상호작용 중인 상태 전이

        protected Animator _animator; // 애니메이션을 실행시킬 애니메이터

        public bool IsStart { get; protected set; } // 시작(처음 플레이어가 깨어난 시점) 상태인지 확인하는 변수

        // 변수 초기화
        protected virtual void Awake()
        {
            GameManager.Instance.Player = gameObject; // 게임 매니저의 Player를 자기자신으로 지정
            IsStart = true;

            _inputHandle = new PlayerInputHandle(this);
            _act = new PlayerAct(transform, _playerCamTrans, _moveSpeed);
            _interactionRaycaster = new PlayerInteractionRaycaster(_guideImage, _rayDistance);
            _animator = GetComponent<Animator>();

            _machine = new StateMachine();

            _startState = new PlayerStartState(_animator); // 대기 상태(시작 후 애니메이션이 실행되는 상태)
            _actState = new PlayerActState(_inputHandle, _act, _interactionRaycaster); // 움직임 가능 상태
            _interactionState = new PlayerInteractionState(_inputHandle, _interactionRaycaster); // 상호작용 중인 상태

            _startTransition = new PlayerStartTransition(_machine, _startState, this);
            _interactionTransition = new PlayerInteractionTransition(_machine, _interactionState);
            _actTransition = new PlayerActTransition(_machine, _actState, this);

            _transitionHandle = new TransitionHandle(new List<ITransition>
            {
                _startTransition,
                _interactionTransition,
                _actTransition,
            });
        }
    }
}
// 마지막 작성 일자: 2025.05.27
