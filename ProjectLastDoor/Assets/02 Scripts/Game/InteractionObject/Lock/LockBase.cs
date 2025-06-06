using Game.InteractionObject.FSM;
using Game.InteractionObject.Transition;
using MyUtil.FSM;
using MyUtil.Transition;
using System.Collections.Generic;
using UnityEngine;

namespace Game.InteractionObject
{
    // �ۼ���: ������
    // �ڹ����� �θ� Ŭ����
    public class LockBase : InteractionObjectBase
    {
        public bool IsLockInteractionOn { get; set; } // �ڹ��� ��ȣ�ۿ��� �Ǿ����� ����

        public bool IsFailed { get; set; } // ���� ���� �Ǵ�

        public int SuccessCount { get; set; } // ���� ���� ī��Ʈ ����

        public bool IsSuccess { get; set; } // ���� ���� �Ǵ�

        [SerializeField] private float _delay; // �ִϸ��̼� ��� ����

        [SerializeField] private int _successGoal; // �� �� ���� �ߴ��� ī��Ʈ ����

        [SerializeField] private Animator _successAnimator; // ���� �� ���� ������ �ִϸ����� ����

        private List<GameObject> _buttons = new List<GameObject>(); // �ڹ��� ������Ʈ�� �ڽĵ�(�ڹ��� ��ư)

        private IState _idleState; // ��ȣ�ۿ� �� ����
        private IState _waitState; // ��ȣ�ۿ� �� ��� ��� ����
        private IState _successState; // ���� ����
        private IState _failedState; // ���� ����

        private ITransition _idleTransition; // ��ȣ�ۿ� �� ���·� ����
        private ITransition _waitTransition; // ��ȣ�ۿ� �� ��� ��� ���·� ����
        private ITransition _successTransition; // ���� ���·� ����
        private ITransition _failedTransition; // ���� ���·� ����

        protected override void Awake()
        {
            base.Awake();

            for (int i = 0; i < transform.childCount; i++) // �ڽ� ��ȸ
            {
                _buttons.Add(transform.GetChild(i).gameObject); // �ڽ� �߰�
            }

            _idleState = new LockIdleState(this, _buttons);
            _waitState = new LockWaitState(this, _buttons);
            _successState = new LockSuccessState(this, _buttons, _successAnimator);
            _failedState = new LockFailedState(this, _buttons, _delay);

            _idleTransition = new LockIdleTransition(_machine, _idleState, this);
            _waitTransition = new LockWaitTransition(_machine, _waitState, this);
            _successTransition = new LockSuccessTransition(_machine, _successState, this, _successGoal);
            _failedTransition = new LockFailedTransition(_machine, _failedState, this);

            _transitionHandle = new TransitionHandle(new List<ITransition>()
            {
                _idleTransition,
                _successTransition,
                _failedTransition,
                _waitTransition
            });
        }

        protected override void Update()
        {
            if (IsSuccess) return;

            base.Update();
        }

        public override void Interaction()
        {
            IsLockInteractionOn = true; // �ڹ��� ��ȣ�ۿ� O
        }
    }
}
// ������ �ۼ� ����: 2025.06.06
