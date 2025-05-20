using UnityEngine;
using UnityEngine.InputSystem;

// �÷��̾�� ���õ� ��ɵ��� ��Ƶ� ���ӽ����̽�
namespace Game.Player
{
    // �ۼ���: ������
    // �÷��̾��� ��ǲ�� ó���ϴ� Ŭ����
    public class PlayerInputHandle
    {
        private InputActionAsset _inputActionAsset; // �÷��̾� ��ǲ ����
        private InputActionMap _inputActionMap; // �÷��̾� ��ǲ�� �ִ� Player ��
        private InputAction _inputMoveAction; // �÷��̾� ��ǲ�� �ִ� Move �׼�
        private InputAction _inputLookAction; // �÷��̾� ��ǲ�� �ִ� Look �׼�

        private Vector2 _moveVector; // �÷��̾� �̵� ���͸� �޴� ����
        private Vector2 _lookVector; // �÷��̾� ���� ���͸� �޴� ����

        public Vector2 MoveVector // �÷��̾� �̵� ���� ������Ƽ
        {
            get
            {
                return _moveVector;
            }
        }

        public Vector2 LookVector // �÷��̾� ���� ���� ������Ƽ
        {
            get
            {
                return _lookVector;
            }
        }

        // �����ڿ��� ���� �ʱ�ȭ
        public PlayerInputHandle(InputActionAsset inputActionAsset)
        {
            _inputActionAsset = inputActionAsset;
        }

        // Ȱ��ȭ �Ǿ��� ��
        public void OnEnable()
        {
            _inputActionAsset.Enable(); // �÷��̾� ���� Ȱ��ȭ

            _inputActionMap = _inputActionAsset.FindActionMap("Player"); // "Player" �̸��� ���� �� Ž�� �� �Ҵ�
            _inputActionMap.Enable(); // "Player" �� Ȱ��ȭ

            _inputMoveAction = _inputActionMap.FindAction("Move"); // "Player" �ʿ��� "Move" �̸��� ���� �׼� Ž�� �� �Ҵ�
            _inputMoveAction.Enable(); // "Move" �׼� Ȱ��ȭ

            _inputLookAction = _inputActionMap.FindAction("Look"); // "Player" �ʿ��� "Look" �̸��� ���� �׼� Ž�� �� �Ҵ�
            _inputLookAction.Enable(); // "Look" �׼� Ȱ��ȭ

            _inputMoveAction.performed += OnMove; // "Move" �׼ǿ� OnMove �Լ� ����
            _inputLookAction.performed += OnLook; // "Look" �׼ǿ� OnLook �Լ� ����
        }

        // ��Ȱ��ȭ �Ǿ��� ��
        public void OnDisable()
        {
            _inputMoveAction.performed -= OnMove; // "Move" �׼ǿ� OnMove �Լ� ���� ����
            _inputLookAction.performed -= OnLook; // "Look" �׼ǿ� OnLook �Լ� ���� ����

            _inputLookAction.Disable(); // "Look" �׼� ��Ȱ��ȭ
            _inputMoveAction.Disable(); // "Move" �׼� ��Ȱ��ȭ
            _inputActionMap.Disable(); // "Player" �� ��Ȱ��ȭ
            _inputActionAsset.Disable(); // �÷��̾� ���� ��Ȱ��ȭ
        }

        public bool IsMoveInputCall() // ��ǲ�� ��� ������ �ִ��� Ȯ���ϴ� �Լ�
        {
            if (_inputMoveAction.phase == InputActionPhase.Waiting) // ���� ��ǲ�� ��ٸ��� ���¶��
                return false; // false ��ȯ

            return true; // �ƴҰ�� true ��ȯ
        }

        private void OnMove(InputAction.CallbackContext context) // PlayerInput���� �̵� ���͸� �޴� �Լ�
        {
            _moveVector = context.ReadValue<Vector2>(); // Vector2�� �о �Ҵ�
        }

        private void OnLook(InputAction.CallbackContext context) // PlayerInput���� ���� ���͸� �޴� �Լ�
        {
            _lookVector = context.ReadValue<Vector2>(); // Vector2�� �о �Ҵ�
        }
    }
}
// ������ �ۼ� ����: 2025.05.19