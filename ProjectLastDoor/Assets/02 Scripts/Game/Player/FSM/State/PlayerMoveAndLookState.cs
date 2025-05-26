using MyUtil.FSM;
using UnityEngine;

// �÷��̾� FSM ���ӽ����̽�
namespace Game.Player.FSM
{
    // �ۼ���: ������
    // ������ �� �ü� ó�� ����
    public class PlayerMoveAndLookState : PlayerStateBase
    {
        private PlayerInputHandle _inputHandle;
        private PlayerMovement _movement;

        public PlayerMoveAndLookState(PlayerInputHandle inputHandle, PlayerMovement movement)
        {
            _inputHandle = inputHandle;
            _movement = movement;
        }

        // �������� ��
        public override void OnExecute()
        {
            base.OnExecute();

            if (_inputHandle.IsInputActionCalling("Look")) // "Look" ��ǲ�� �� ���� Ȯ��
                _movement.Look(_inputHandle.LookVector); // �� �����Ӹ��� ������ ���� �ٶ󺸰� �ϴ� �Լ� ȣ��

            if (_inputHandle.IsInputActionCalling("Move")) // "Move" ��ǲ�� �� ���� Ȯ��
                _movement.Move(_inputHandle.MoveVector); // �� �����Ӹ��� ������ �Լ� ȣ��
        }
    }
}
// ������ �ۼ� ����: 2025.05.26
