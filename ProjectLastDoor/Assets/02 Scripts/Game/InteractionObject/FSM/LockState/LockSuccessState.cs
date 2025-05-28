using Game.Manager;
using MyUtil.FSM;
using UnityEngine;

namespace Game.InteractionObject.FSM
{
    // 작성자: 조혜찬
    // 자물쇠 풀기 성공 상태
    public class LockSuccessState : LockStateBase
    {
        public LockSuccessState(LockInteraction lockInteraction) : base(lockInteraction)
        {
        }

        public override void OnEnter()
        {
            base.OnEnter();

            _lockInteraction.ChangeChannel(false); // 시네머신 채널 플레이어 채널로 전환
            _lockInteraction.IsLockInteractionOn = false; // 자물쇠 상호작용 종료
            GameManager.Instance.IsNeedMousePos = false; // 마우스 커서 위치로 레이 쏘지 않아도 된다고 변경
            GameManager.Instance.IsInteractionOn = false; // 상호작용 자체가 종료
        }
    }
}
// 마지막 작성 일자: 2025.05.28
