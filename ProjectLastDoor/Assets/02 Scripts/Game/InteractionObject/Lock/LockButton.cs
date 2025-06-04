using UnityEngine;
using DG.Tweening;
using MyUtil.FSM;
using MyUtil.Transition;
using Game.InteractionObject.FSM;
using Game.InteractionObject.Transition;
using System.Collections.Generic;

namespace Game.InteractionObject
{
    // 작성자: 조혜찬
    // 자물쇠의 버튼들을 기능을 담당하는 클래스
    public class LockButton : InteractionObjectBase
    {
        [SerializeField] private bool _isCorrectAnswer; // 이 버튼이 눌러야하는 버튼인지 결정하는 변수
        [SerializeField] private float _animationTime; // 색 변경 애니메이션 플레이 타임

        public bool IsSuccess { get; set; } // 성공 여부 체크 변수
        public bool IsFailed { get; set; } // 실패 여부 체크 변수

        private PushButtonLock _pushButtonLock; // 부모(자물쇠) 클래스
        private Material _material; // 버튼의 색을 변경하기 위한 변수

        private IState _idleState; // 상호작용 되지 않은 상태
        private IState _successState; // 정답 버튼 상태
        private IState _failedState; // 실패 버튼 상태

        private ITransition _idleTransition; // 상호작용 되지 않은 상태로 전이
        private ITransition _successTransition; // 성공 버튼 상태로 전이
        private ITransition _failedTransition; // 실패 버튼 상태로 전이

        protected override void Awake()
        {
            base.Awake();

            _pushButtonLock = transform.parent.GetComponent<PushButtonLock>(); // 부모, 즉 자물쇠 클래스 가져오기
            _material = GetComponent<Renderer>().material; // 실패와 성공에 따라 버튼의 색 변경을 위한 변수

            _idleState = new LockButtonIdleState(_pushButtonLock, this, _material, _animationTime); // 상호작용 되지 않은 상태 
            _successState = new LockButtonSuccessState(_pushButtonLock, this, _material, _animationTime); // 성공 버튼 상태
            _failedState = new LockButtonFailedState(_pushButtonLock, this, _material, _animationTime); // 실패 버튼 상태

            _idleTransition = new LockButtonIdleTransition(_machine, _idleState, this); // 상호작용 되지 않은 상태로 전이
            _successTransition = new LockButtonSuccessTransition(_machine, _successState, this); // 성공 버튼 상태로 전이
            _failedTransition = new LockButtonFailedTranstion(_machine, _failedState, this); // 실패 버튼 상태로 전이

            _transitionHandle = new TransitionHandle(new List<ITransition>()
            {
                _idleTransition,
                _failedTransition,
                _successTransition
            });

            IsSuccess = false;
            IsFailed = false;
        }

        public override void Interaction()
        {
            if(_pushButtonLock.IsLockInteractionOn) // 만약 자물쇠가 상호작용 되어있다면 (그냥 버튼이 눌리는 상황을 방지)
            {
                if(!_isCorrectAnswer) // 만약 이 버튼이 올바른 버튼이 아니었을 경우
                {
                    IsFailed = true;
                    return; // 그리고 종료
                }

                // 만약 올바른 버튼이었다면
                IsSuccess = true;
            }
        }
    }
}
// 마지막 작성 일자: 2025.06.04