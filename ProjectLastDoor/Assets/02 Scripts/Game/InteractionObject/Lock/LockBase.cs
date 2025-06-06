using Game.InteractionObject.FSM;
using Game.InteractionObject.Transition;
using MyUtil.FSM;
using MyUtil.Transition;
using System.Collections.Generic;
using UnityEngine;

namespace Game.InteractionObject
{
    // 작성자: 조혜찬
    // 자물쇠의 부모 클래스
    public class LockBase : InteractionObjectBase
    {
        public bool IsLockInteractionOn { get; set; } // 자물쇠 상호작용이 되었는지 여부

        public bool IsFailed { get; set; } // 실패 여부 판단

        public int SuccessCount { get; set; } // 성공 개수 카운트 변수

        public bool IsSuccess { get; set; } // 성공 여부 판단

        [SerializeField] private float _delay; // 애니메이션 대기 변수

        [SerializeField] private int _successGoal; // 몇 개 성공 했는지 카운트 변수

        [SerializeField] private Animator _successAnimator; // 성공 후 상자 열리는 애니메이터 변수

        private List<GameObject> _buttons = new List<GameObject>(); // 자물쇠 오브젝트의 자식들(자물쇠 버튼)

        private IState _idleState; // 상호작용 전 상태
        private IState _waitState; // 상호작용 후 결과 대기 상태
        private IState _successState; // 성공 상태
        private IState _failedState; // 실패 상태

        private ITransition _idleTransition; // 상호작용 전 상태로 전이
        private ITransition _waitTransition; // 상호작용 후 결과 대기 상태로 전이
        private ITransition _successTransition; // 성공 상태로 전이
        private ITransition _failedTransition; // 실패 상태로 전이

        protected override void Awake()
        {
            base.Awake();

            for (int i = 0; i < transform.childCount; i++) // 자식 순회
            {
                _buttons.Add(transform.GetChild(i).gameObject); // 자식 추가
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
            IsLockInteractionOn = true; // 자물쇠 상호작용 O
        }
    }
}
// 마지막 작성 일자: 2025.06.06
