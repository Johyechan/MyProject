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
        protected PlayerAct _act; // �ൿ�� ó���ϴ� Ŭ����
        protected PlayerInteractionRaycaster _interactionRaycaster; // ��ȣ�ۿ��� ó���ϴ� Ŭ����

        protected StateMachine _machine; // ���� ���� �ӽ�
        protected TransitionHandle _transitionHandle; // ���� ���� �ڵ�

        protected IState _startState; // ����(ó�� �÷��̾ ��� ����) ����
        protected IState _actState; // ������ �÷��� ������(��� �ൿ�� ������) ����
        protected IState _interactionState; // ��ȣ�ۿ� ���� ����

        protected ITransition _startTransition; // ����(ó�� �÷��̾ ��� ����) ���� ����
        protected ITransition _actTransition; // ������ �÷��� ������(��� �ൿ�� ������) ���� ����
        protected ITransition _interactionTransition; // ��ȣ�ۿ� ���� ���� ����

        protected Animator _animator; // �ִϸ��̼��� �����ų �ִϸ�����

        public bool IsStart { get; protected set; } // ����(ó�� �÷��̾ ��� ����) �������� Ȯ���ϴ� ����

        // ���� �ʱ�ȭ
        protected virtual void Awake()
        {
            GameManager.Instance.Player = gameObject; // ���� �Ŵ����� Player�� �ڱ��ڽ����� ����
            IsStart = true;

            _inputHandle = new PlayerInputHandle(this);
            _act = new PlayerAct(transform, _playerCamTrans, _moveSpeed);
            _interactionRaycaster = new PlayerInteractionRaycaster(_guideImage, _rayDistance);
            _animator = GetComponent<Animator>();

            _machine = new StateMachine();

            _startState = new PlayerStartState(_animator); // ��� ����(���� �� �ִϸ��̼��� ����Ǵ� ����)
            _actState = new PlayerActState(_inputHandle, _act, _interactionRaycaster); // ������ ���� ����
            _interactionState = new PlayerInteractionState(_inputHandle, _interactionRaycaster); // ��ȣ�ۿ� ���� ����

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
// ������ �ۼ� ����: 2025.05.27
