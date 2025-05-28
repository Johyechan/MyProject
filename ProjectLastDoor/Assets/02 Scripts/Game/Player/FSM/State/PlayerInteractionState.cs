using Game.Manager;
using UnityEngine;

namespace Game.Player.FSM
{
    // �ۼ���: ������
    // �÷��̾� ��ȣ�ۿ� ����
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

            if (_interactionRaycaster.IsOnInteractionObject(GameManager.Instance.IsNeedMousePos)) // ��ȣ�ۿ� ��ü�� ����������
            {
                if (_inputHandle.IsInteraction) // ��ȣ�ۿ� Ű�� �����ٸ�
                {
                    _inputHandle.IsInteraction = false; // Ŭ�� ���� �ʱ�ȭ

                    _interactionRaycaster.PlayInteraction(); // ��ȣ�ۿ�
                }
            }
        }
    }
}
// ������ �ۼ� ����: 2025.05.27
