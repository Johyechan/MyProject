using DG.Tweening;
using Game.Manager;
using MyUtil.FSM;
using UnityEngine;

namespace Game.InteractionObject.FSM
{
    // 작성자: 조혜찬
    // 자물쇠 버튼 상태의 부모 클래스
    public class LockButtonStateBase : IState
    {
        protected PushButtonLock _pushButtonLock;

        protected LockButton _lockButton;

        protected Material _material;

        protected float _animationTime;

        public LockButtonStateBase(PushButtonLock pushButtonLock, LockButton lockButton, Material material, float animationTime)
        {
            _pushButtonLock = pushButtonLock;
            _lockButton = lockButton;
            _material = material;
            _animationTime = animationTime;
        }

        public virtual void OnEnter()
        {
            //Debug.Log($"{GetType().Name} 실행 시작");
        }

        public virtual void OnExecute()
        {

        }

        public virtual void OnExit()
        {
            //Debug.Log($"{GetType().Name} 실행 종료");
        }
    }
}
// 마지막 작성 일자: 2025.06.04
