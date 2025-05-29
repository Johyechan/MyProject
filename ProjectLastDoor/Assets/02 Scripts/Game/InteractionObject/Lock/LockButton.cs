using UnityEngine;
using DG.Tweening;
using MyUtil.FSM;
using MyUtil.Transition;
using Game.InteractionObject.FSM;
using Game.InteractionObject.Transition;
using System.Collections.Generic;

namespace Game.InteractionObject
{
    // �ۼ���: ������
    // �ڹ����� ��ư���� ����� ����ϴ� Ŭ����
    public class LockButton : InteractionObjectBase
    {
        [SerializeField] private bool _isCorrectAnswer; // �� ��ư�� �������ϴ� ��ư���� �����ϴ� ����
        [SerializeField] private float _animationTime; // �� ���� �ִϸ��̼� �÷��� Ÿ��

        public bool IsSuccess { get; private set; } // ���� ���� üũ ����
        public bool IsFailed { get; private set; } // ���� ���� üũ ����

        private LockInteraction _lockInteraction; // �θ�(�ڹ���) Ŭ����
        private Material _material; // ��ư�� ���� �����ϱ� ���� ����

        private IState _idleState; // ��ȣ�ۿ� ���� ���� ����
        private IState _successState; // ���� ��ư ����
        private IState _failedState; // ���� ��ư ����

        private ITransition _idleTransition; // ��ȣ�ۿ� ���� ���� ���·� ����
        private ITransition _successTransition; // ���� ��ư ���·� ����
        private ITransition _failedTransition; // ���� ��ư ���·� ����

        protected override void Awake()
        {
            base.Awake();

            _lockInteraction = transform.parent.GetComponent<LockInteraction>(); // �θ�, �� �ڹ��� Ŭ���� ��������
            _material = GetComponent<Renderer>().material; // ���п� ������ ���� ��ư�� �� ������ ���� ����

            _idleState = new LockButtonIdleState(_material, _animationTime, _lockInteraction); // ��ȣ�ۿ� ���� ���� ���� 
            _successState = new LockButtonSuccessState(_material, _animationTime, _lockInteraction); // ���� ��ư ����
            _failedState = new LockButtonFailedState(_material, _animationTime, _lockInteraction); // ���� ��ư ����

            _idleTransition = new LockButtonIdleTransition(_machine, _idleState, this); // ��ȣ�ۿ� ���� ���� ���·� ����
            _successTransition = new LockButtonSuccessTransition(_machine, _successState, this); // ���� ��ư ���·� ����
            _failedTransition = new LockButtonFailedTranstion(_machine, _failedState, this); // ���� ��ư ���·� ����

            _transitionHandle = new TransitionHandle(new List<ITransition>()
            {
                _idleTransition,
                _successTransition,
                _failedTransition
            });

            IsSuccess = false;
            IsFailed = false;
        }

        public override void Interaction()
        {
            if(_lockInteraction.IsLockInteractionOn) // ���� �ڹ��谡 ��ȣ�ۿ� �Ǿ��ִٸ� (�׳� ��ư�� ������ ��Ȳ�� ����)
            {
                if(!_isCorrectAnswer) // ���� �� ��ư�� �ùٸ� ��ư�� �ƴϾ��� ���
                {
                    IsFailed = true;
                    return; // �׸��� ����
                }

                // ���� �ùٸ� ��ư�̾��ٸ�
                IsSuccess = true;
            }
        }
    }
}
// ������ �ۼ� ����: 2025.05.23