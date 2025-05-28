using Game.Manager;
using UnityEngine;

namespace Game.Player.FSM
{
    // 작성자: 조혜찬
    // 플레이어 상호작용 상태
    public class PlayerInteractionState : PlayerStateBase
    {
        private PlayerInputHandle _inputHandle;
        private PlayerInteractionRaycaster _interactionRaycaster;

        public PlayerInteractionState(PlayerInputHandle inputHandle, PlayerInteractionRaycaster interactionRaycaster)
        {
            _inputHandle = inputHandle;
            _interactionRaycaster = interactionRaycaster;
        }

        public override void OnExecute()
        {
            base.OnExecute();

            if (_interactionRaycaster.IsOnInteractionObject(GameManager.Instance.IsNeedMousePos)) // 상호작용 객체를 감지했으며
            {
                Debug.Log(_inputHandle.IsInteraction);
                if (_inputHandle.IsInteraction) // 상호작용 키를 눌렀다면
                {
                    Debug.Log("상호작용 중에 또 상호작용");
                    _inputHandle.IsInteraction = false; // 클릭 상태 초기화

                    _interactionRaycaster.PlayInteraction(); // 상호작용
                }
            }
        }
    }
}
// 마지막 작성 일자: 2025.05.27
