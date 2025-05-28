using MyUtil.FSM;
using UnityEngine;

namespace Game.InteractionObject.FSM
{
    // 작성자: 조혜찬
    // 자물쇠에 상호작용하기 전 대기 상태
    public class LockIdleState : LockStateBase
    {
        public LockIdleState(LockInteraction lockInteraction) : base(lockInteraction)
        {
        }

        public override void OnEnter()
        {
            base.OnEnter();
            _lockInteraction.ChangeChannel(false); // 플레이어 시네머신으로 채널 전환
        }
    }
}
// 마지막 작성 일자: 2025.05.28
