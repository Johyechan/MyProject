using Game.InteractionObject.FSM;
using Game.InteractionObject.Transition;
using Game.Manager;
using MyUtil.FSM;
using MyUtil.Transition;
using System.Collections.Generic;
using UnityEngine;

namespace Game.InteractionObject
{
    // 자물쇠의 상호작용을 처리하는 클래스
    public class LockInteraction : InteractionObjectBase
    {
        public bool IsLockInteractionOn { get; set; } // 자물쇠 상호작용이 되었는지 여부

        public bool IsFailed { get; set; } // 실패 여부 판단

        public int SuccessCount { get; set; } // 성공 개수 카운트 변수

        public bool IsSuccess { get; set; } // 성공 여부 판단

        [SerializeField] private int _successGoal;

        [SerializeField] private Animator _successAnimator;

        private List<GameObject> _buttons = new List<GameObject>(); // 자물쇠 오브젝트의 자식들(자물쇠 버튼)

        private IState _idleState;
        private IState _waitState;
        private IState _successState;
        private IState _failedState;

        private ITransition _idleTransition;
        private ITransition _waitTransition;
        private ITransition _successTransition;
        private ITransition _failedTransition;

        protected override void Awake()
        {
            base.Awake();

            for (int i = 0; i < transform.childCount; i++) // 자식 순회
            {
                _buttons.Add(transform.GetChild(i).gameObject); // 자식 추가
            }

            _idleState = new LockIdleState(this, _buttons);
            _waitState = new LockWaitState(this, _buttons);
            _successState = new LockSuccessState(this, _successAnimator);
            _failedState = new LockFailedState(this);

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

        // 상호작용 함수
        public override void Interaction() 
        {
            IsLockInteractionOn = true; // 자물쇠 상호작용 O
        }
    }
}
// 마지막 작성 일자: 2025.05.30