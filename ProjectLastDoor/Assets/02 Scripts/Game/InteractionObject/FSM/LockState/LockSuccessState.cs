using DG.Tweening;
using Game.Manager;
using System.Collections.Generic;
using UnityEngine;

namespace Game.InteractionObject.FSM
{
    // 작성자: 조혜찬
    // 자물쇠 풀기 성공 상태
    public class LockSuccessState : LockStateBase
    {
        private List<GameObject> _buttons;
        private Animator _successAnimator;

        public LockSuccessState(PushButtonLock pushButtonLock, Animator successAnimator, List<GameObject> buttons) : base(pushButtonLock)
        {
            _buttons = buttons;
            _successAnimator = successAnimator;
        }

        public override void OnEnter()
        {
            base.OnEnter();

            foreach (GameObject button in _buttons) // 자물쇠 버튼들 순회
            {
                button.layer = 0; // 레이어를 Default로 변경시켜 상호작용 불가하게 변경
                LockButton buttonBtn = button.GetComponent<LockButton>(); // 그리고 LockButton을 가져와서
                buttonBtn.IsFailed = false; // 버튼 초기화 (실패 초기화)
                buttonBtn.IsSuccess = false; // 버튼 초기화 (성공 초기화)
            }

            Sequence sequence = DOTween.Sequence()
                .AppendCallback(() => _pushButtonLock.ChangeChannel(false)) // 시네머신 채널 플레이어 채널로 전환
                .InsertCallback(1.5f, () => _successAnimator.enabled = true) // 애니메이터을 활성화시키면서 애니메이션 실행
                .AppendCallback(() => _pushButtonLock.IsLockInteractionOn = false) // 자물쇠 상호작용 종료
                .AppendCallback(() => _pushButtonLock.IsSuccess = true) // 최종적으로 성공
                .AppendCallback(() => GameManager.Instance.IsNeedMousePos = false) // 마우스 커서 위치로 레이 쏘지 않아도 된다고 변경
                .AppendCallback(() => GameManager.Instance.IsInteractionOn = false) // 상호작용 자체가 종료
                .AppendCallback(() => _pushButtonLock.gameObject.layer = 0); // 이제 상호작용이 불가능한 상태로 변경 (0 = Default)
        }
    }
}
// 마지막 작성 일자: 2025.06.02
