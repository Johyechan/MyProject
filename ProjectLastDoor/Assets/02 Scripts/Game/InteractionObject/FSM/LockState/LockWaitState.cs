using Game.Manager;
using MyUtil.FSM;
using System.Collections.Generic;
using UnityEngine;

namespace Game.InteractionObject.FSM
{
    // 작성자: 조혜찬
    // 자물쇠 상호작용 후 상태
    public class LockWaitState : LockStateBase
    {
        private List<GameObject> _buttons = new List<GameObject>();

        public LockWaitState(PushButtonLock pushButtonLock, List<GameObject> buttons) : base(pushButtonLock)
        {
            _buttons = buttons;
        }

        public override void OnEnter()
        {
            base.OnEnter();

            foreach(GameObject button in _buttons) // 자물쇠 버튼들 순회
            {
                button.layer = LayerMask.NameToLayer(GameManager.Instance.InteractionLayerName); // 레이어를 변경시켜 상호작용 가능하게 변경
            }

            _pushButtonLock.gameObject.layer = 0; // 자물쇠(자기 자신)를 상호작용하지 못하도록 변경
            _pushButtonLock.ChangeChannel(); // 시네머신 채널 변경
            _pushButtonLock.IsFailed = false; // 실패 초기화
            _pushButtonLock.SuccessCount = 0; // 성공 초기화
            GameManager.Instance.IsNeedMousePos = true; // 마우스 커서 위치로 레이를 쏴야 한다고 선언
        }
    }
}
// 마지막 작성 일자: 2025.06.02
