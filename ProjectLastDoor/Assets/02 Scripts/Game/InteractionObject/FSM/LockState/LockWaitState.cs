using Game.Manager;
using MyUtil.FSM;
using UnityEngine;

namespace Game.InteractionObject.FSM
{
    // 작성자: 조혜찬
    // 자물쇠 상호작용 후 상태
    public class LockWaitState : LockStateBase
    {
        public LockWaitState(LockInteraction lockInteraction) : base(lockInteraction)
        {
        }

        public override void OnEnter()
        {
            base.OnEnter();

            _lockInteraction.ChangeChannel(); // 시네머신 채널 변경
            _lockInteraction.IsFailed = false; // 실패 초기화
            _lockInteraction.SuccessCount = 0; // 성공 초기화
            GameManager.Instance.IsNeedMousePos = true; // 마우스 커서 위치로 레이를 쏴야 한다고 선언
        }
    }
}
// 마지막 작성 일자: 2025.05.28
