using Game.Manager;
using Game.Player.FSM;
using MyUtil.FSM;
using MyUtil.Transition;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Game.Player
{
    // �ۼ���: ������
    // �÷��̾�� �ʿ��� �������� ��Ƶ� Ŭ����
    public class PlayerVariables : MonoBehaviour
    {
        [SerializeField] protected float _moveSpeed; // �̵� �ӵ�
        [SerializeField] protected float _disableDelay; // ��Ȱ��ȭ ��� �ð�
        [SerializeField] protected float _enableDelay; // Ȱ��ȭ ��� �ð�
        [SerializeField] protected float _rayDistance; // ���� ���� �Ÿ�

        [SerializeField] protected Transform _playerCamTrans; // �÷��̾� ī�޶�

        [SerializeField] protected Image _guideImage; // ��ȣ�ۿ� Ű ���̵� UI

        protected PlayerInputHandle _inputHandle; // ��ǲ�� ó���ϴ� Ŭ����
        protected PlayerMovement _movement; // �������� ó���ϴ� Ŭ����
        protected PlayerInteractionRaycaster _interactionRaycaster; // ��ȣ�ۿ��� ó���ϴ� Ŭ����

        protected StateMachine _machine; // ���� ���� �ӽ�
        protected TransitionHandle _transitionHandle; // ���� ���� �ڵ�

        protected IState _idleState; // ��� ����
        protected IState _moveAndLookState; // ������ ��, ���� ���� ���� ����
        protected IState _interactionState; // ��ȣ�ۿ� ���� ����

        protected ITransition _idleTransition; // ��� ���� ����
        protected ITransition _moveAndLookTransition; // ������ �� �ü� ���� ���� ���� ����
        protected ITransition _interactionTransition; // ��ȣ�ۿ� ���� ���� ����

        // ���� �ʱ�ȭ
        protected virtual void Awake()
        {
            GameManager.Instance.Player = gameObject; // ���� �Ŵ����� Player�� �ڱ��ڽ����� ����

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

            _idleState = new PlayerIdleState(); // ��� ����(���� �� �ִϸ��̼��� ����Ǵ� ����)
            _moveAndLookState = new PlayerMoveAndLookState(_inputHandle, _movement); // ������ ���� ����
            _interactionState = new PlayerInteractionState(); // ��ȣ�ۿ� ���� ����
        }
    }
}
// ������ �ۼ� ����: 2025.05.27
