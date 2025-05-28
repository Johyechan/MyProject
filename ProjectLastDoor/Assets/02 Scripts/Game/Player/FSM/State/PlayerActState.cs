using Game.Manager;
using UnityEngine;

namespace Game.Player.FSM
{
    // �ۼ���: ������
    // �÷��̾��� ��� �ൿ(�÷��� �ϴ� ��) ó�� ����
    public class PlayerActState : PlayerStateBase
    {
        private PlayerInputHandle _inputHandle;
        private PlayerAct _act;
        private PlayerInteractionRaycaster _interactionRaycaster;

        public PlayerActState(PlayerInputHandle inputHandle, PlayerAct act, PlayerInteractionRaycaster interactionRaycaster)
        {
            _inputHandle = inputHandle;
            _act = act;
            _interactionRaycaster = interactionRaycaster;
        }

        public override void OnEnter()
        {
            base.OnEnter();

            if (InputManager.Instance != null)
            {
                InputManager.Instance.WaitAndEnable(true); // ��ǲ Ȱ��ȭ
                _inputHandle.OnEnable(); // ��ǲ �ڵ��� Ȱ��ȭ �Լ� ȣ��
            }
        }

        // �������� ��
        public override void OnExecute()
        {
            base.OnExecute();

            if (_interactionRaycaster.IsOnInteractionObject(GameManager.Instance.IsNeedMousePos)) // ��ȣ�ۿ� ��ü�� ����������
            {
                if (_inputHandle.IsInteraction) // ��ȣ�ۿ� Ű�� �����ٸ�
                {
                    Debug.Log("��ȣ�ۿ�");
                    GameManager.Instance.IsInteractionOn = true; // ��ȣ�ۿ� ���̶�� ����
                    _inputHandle.IsInteraction = false; // Ŭ�� ���� �ʱ�ȭ

                    _interactionRaycaster.PlayInteraction(); // ��ȣ�ۿ�
                }
            }

            if (_inputHandle.IsInputActionCalling("Look")) // "Look" ��ǲ�� �� ���� Ȯ��
                _act.Look(_inputHandle.LookVector); // �� �����Ӹ��� ������ ���� �ٶ󺸰� �ϴ� �Լ� ȣ��

            if (_inputHandle.IsInputActionCalling("Move")) // "Move" ��ǲ�� �� ���� Ȯ��
                _act.Move(_inputHandle.MoveVector); // �� �����Ӹ��� ������ �Լ� ȣ��
        }

        public override void OnExit()
        {
            base.OnExit();

            // ���⼭ ������ �������� ���� �̰� Disable�� �ű�� ���⼭�� wasd + ���콺 Ŀ�� ��ǲ �׼Ǹ� ��Ȱ��ȭ ��Ű�� ��
            if (InputManager.Instance != null)
            {
                _inputHandle.OnDisable(); // ��ǲ �ڵ��� ��Ȱ��ȭ �Լ� ȣ��
                InputManager.Instance.WaitAndEnable(false); // ��ǲ ��Ȱ��ȭ
            }
        }
    }
}
// ������ �ۼ� ����: 2025.05.27
