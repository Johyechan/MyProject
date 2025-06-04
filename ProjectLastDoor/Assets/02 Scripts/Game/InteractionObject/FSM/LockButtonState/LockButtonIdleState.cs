using DG.Tweening;
using UnityEngine;

namespace Game.InteractionObject.FSM
{
    // 작성자: 조혜찬
    // 상호작용 되지 않은 상태
    public class LockButtonIdleState : LockButtonStateBase
    {
        public LockButtonIdleState(PushButtonLock pushButtonLock, LockButton lockButton, Material material, float animationTime) : base(pushButtonLock, lockButton, material, animationTime)
        {
        }

        public override void OnEnter()
        {
            base.OnEnter();

            _material.DOColor(Color.white, _animationTime); // 버튼 색 초기화
        }
    }
}
// 마지막 작성 일자: 2025.06.04
