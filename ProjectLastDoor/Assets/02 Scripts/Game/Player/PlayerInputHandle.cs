using Game.Manager;
using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

// �÷��̾�� ���õ� ��ɵ��� ��Ƶ� ���ӽ����̽�
namespace Game.Player
{
    // �ۼ���: ������
    // �÷��̾��� ��ǲ�� ó���ϴ� Ŭ����
    public class PlayerInputHandle
    {
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

        public void OnEnable()
        {
            InputManager.Instance.GetInputAction("Move").performed += OnMove; // "Move" �׼� �̺�Ʈ ����
            InputManager.Instance.GetInputAction("Look").performed += OnLook; // "Look" �׼� �̺�Ʈ ����
        }

        public void OnDisable()
        {
            InputManager.Instance.GetInputAction("Move").performed -= OnMove; // "Move" �׼� �̺�Ʈ ���� ����
            InputManager.Instance.GetInputAction("Look").performed -= OnLook; // "Look" �׼� �̺�Ʈ ���� ����
        }

        public bool IsInputActionCalling(string key) // ��ǲ�� ��� ������ �ִ��� Ȯ���ϴ� �Լ�
        {
            if (InputManager.Instance.GetInputAction(key).phase == InputActionPhase.Waiting) // ���� ��ǲ�� ��ٸ��� ���¶��
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
// ������ �ۼ� ����: 2025.05.21