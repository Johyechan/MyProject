using DG.Tweening;
using Game.Manager;
using MyUtil.FSM;
using System.Collections.Generic;
using UnityEngine;

namespace Game.InteractionObject.FSM
{
    // 작성자: 조혜찬
    // 자물쇠 푹리를 실패한 상태
    public class LockFailedState : LockStateBase
    {
        private float _delay;

        public LockFailedState(PushButtonLock pushButtonLock, List<GameObject> buttons, float delay) : base(pushButtonLock, buttons)
        {
            _delay = delay;
        }

        public override void OnEnter()
        {
            base.OnEnter();

            Sequence sequence = DOTween.Sequence()
                .AppendCallback(() => {
                    foreach (GameObject button in _buttons) // 자물쇠 버튼들 순회
                    {
                        LockButton buttonBtn = button.GetComponent<LockButton>(); // 그리고 LockButton을 가져와서
                        buttonBtn.IsFailed = true; // 모든 버튼을 실패 상태
                    }
                })
                .AppendInterval(_delay)
                .AppendCallback(() => _pushButtonLock.ChangeChannel(false)) // 시네머신 채널 플레이어 채널로 전환
                .InsertCallback(_delay, () => _pushButtonLock.IsLockInteractionOn = false) // 자물쇠 상호작용 종료
                .AppendCallback(() => GameManager.Instance.IsNeedMousePos = false) // 마우스 커서 위치로 레이 쏘지 않아도 된다고 변경
                .AppendCallback(() => GameManager.Instance.IsInteractionOn = false); // 상호작용 자체가 종료
        }
    }
}
// 마지막 작성 일자: 2025.06.04
