using Game.Manager;

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

        public override void OnEnter()
        {
            base.OnEnter();

            if (InputManager.Instance != null)
            {
                InputManager.Instance.WaitAndEnable(_enableDelay, true); // ��ǲ Ȱ��ȭ
                _inputHandle.OnEnable(); // ��ǲ �ڵ��� Ȱ��ȭ �Լ� ȣ��
            }
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

        public override void OnExit()
        {
            base.OnExit();

            if (InputManager.Instance != null)
            {
                _inputHandle.OnDisable(); // ��ǲ �ڵ��� ��Ȱ��ȭ �Լ� ȣ��
                InputManager.Instance.WaitAndEnable(_disableDelay, false); // ��ǲ ��Ȱ��ȭ
            }
        }
    }
}
// ������ �ۼ� ����: 2025.05.26
