using Game.Manager;
using UnityEngine;
using DG.Tweening;

namespace Game.InteractionObject.FSM
{
    // 작성자: 조혜찬
    // 자물쇠 풀기 성공 상태
    public class LockSuccessState : LockStateBase
    {
        private Animator _successAnimator;

        public LockSuccessState(LockInteraction lockInteraction, Animator successAnimator) : base(lockInteraction)
        {
            _successAnimator = successAnimator;
        }

        public override void OnEnter()
        {
            base.OnEnter();

            Sequence sequence = DOTween.Sequence()
                .AppendCallback(() => _lockInteraction.ChangeChannel(false)) // 시네머신 채널 플레이어 채널로 전환
                .InsertCallback(1.5f, () => _successAnimator.enabled = true) // 애니메이터을 활성화시키면서 애니메이션 실행
                .AppendCallback(() => _lockInteraction.IsLockInteractionOn = false) // 자물쇠 상호작용 종료
                .AppendCallback(() => _lockInteraction.IsSuccess = true) // 최종적으로 성공
                .AppendCallback(() => GameManager.Instance.IsNeedMousePos = false) // 마우스 커서 위치로 레이 쏘지 않아도 된다고 변경
                .AppendCallback(() => GameManager.Instance.IsInteractionOn = false) // 상호작용 자체가 종료
                .AppendCallback(() => _lockInteraction.gameObject.layer = 0); // 이제 상호작용이 불가능한 상태로 변경 (0 = Default)
        }
    }
}
// 마지막 작성 일자: 2025.05.30
