using Game.Manager;
using MyUtil.FSM;
using System.Collections.Generic;
using UnityEngine;

namespace Game.InteractionObject.FSM
{
    // 작성자: 조혜찬
    // 자물쇠에 상호작용하기 전 대기 상태
    public class LockIdleState : LockStateBase
    {
        public LockIdleState(PushButtonLock pushButtonLock, List<GameObject> buttons) : base(pushButtonLock, buttons)
        {
        }

        public override void OnEnter()
        {
            base.OnEnter();

            foreach(GameObject button in _buttons) // 자물쇠 버튼들 순회
            {
                button.layer = 0; // 레이어를 Default로 변경시켜 상호작용 불가하게 변경
                LockButton buttonBtn = button.GetComponent<LockButton>(); // 그리고 LockButton을 가져와서
                buttonBtn.IsFailed = false; // 버튼 초기화 (실패 초기화)
                buttonBtn.IsSuccess = false; // 버튼 초기화 (성공 초기화)
            }

            _pushButtonLock.gameObject.layer = LayerMask.NameToLayer(GameManager.Instance.InteractionLayerName); // 자물쇠(자기자신)를 상호작용 가능한 상태로 변경
            _pushButtonLock.ChangeChannel(false); // 플레이어 시네머신으로 채널 전환
            _pushButtonLock.IsFailed = false; // 상태 초기화 (실패 초기화)
            _pushButtonLock.IsSuccess = false; // 상태 초기화 (최종적인 성공 여부 초기화)
            _pushButtonLock.SuccessCount = 0; // 상태 초기화 (성공 초기화)
        }
    }
}
// 마지막 작성 일자: 2025.06.04
