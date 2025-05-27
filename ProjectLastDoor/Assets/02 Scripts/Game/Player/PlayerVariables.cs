using Game.Manager;
using Game.Player.FSM;
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
        protected PlayerMovement _movement; // 움직임을 처리하는 클래스
        protected PlayerInteractionRaycaster _interactionRaycaster; // 상호작용을 처리하는 클래스

        protected StateMachine _machine; // 상태 전이 머신
        protected TransitionHandle _transitionHandle; // 상태 전이 핸들

        protected IState _idleState; // 대기 상태
        protected IState _moveAndLookState; // 움직임 및, 시점 변경 가능 상태
        protected IState _interactionState; // 상호작용 중인 상태

        protected ITransition _idleTransition; // 대기 상태 전이
        protected ITransition _moveAndLookTransition; // 움직임 및 시선 변경 가능 상태 전이
        protected ITransition _interactionTransition; // 상호작용 중인 상태 전이

        // 변수 초기화
        protected virtual void Awake()
        {
            GameManager.Instance.Player = gameObject; // 게임 매니저의 Player를 자기자신으로 지정

            _inputHandle = new PlayerInputHandle(this);
            _movement = new PlayerMovement(transform, _playerCamTrans, _moveSpeed);
            _interactionRaycaster = new PlayerInteractionRaycaster(_guideImage, _rayDistance);

            _machine = new StateMachine();
            _transitionHandle = new TransitionHandle(new List<ITransition>
            {
                _idleTransition,
                _interactionTransition,
                _moveAndLookTransition,
            });

            _idleState = new PlayerIdleState(); // 대기 상태(시작 후 애니메이션이 실행되는 상태)
            _moveAndLookState = new PlayerMoveAndLookState(_inputHandle, _movement); // 움직임 가능 상태
            _interactionState = new PlayerInteractionState(); // 상호작용 중인 상태
        }
    }
}
// 마지막 작성 일자: 2025.05.27
