using Game.Manager;
using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Game.Player
{
    // �ۼ���: ������
    // �÷��̾��� ��ǲ�� ó���ϴ� Ŭ����
    public class PlayerInputHandle
    {
        private MonoBehaviour _mono; // �ڷ�ƾ�� �����ų ����

        private Vector2 _moveVector; // �÷��̾� �̵� ���͸� �޴� ����
        private Vector2 _lookVector; // �÷��̾� ���� ���͸� �޴� ����

        public Vector2 MoveVector { get { return _moveVector; } } // �÷��̾� �̵� ���� ������Ƽ

        public Vector2 LookVector { get { return _lookVector; } }// �÷��̾� ���� ���� ������Ƽ

        public bool IsInteraction { get; set; }

        // �����ڿ��� MonoBehaviour �ʱ�ȭ
        public PlayerInputHandle(MonoBehaviour mono)
        {
            _mono = mono;
        }

        public void OnEnable()
        {
            _mono.StartCoroutine(WaitAndSubscribeCo()); // ��ǲ �Ŵ����� ��ǲ ��, �׼ǵ��� ���� ����� ������ ��� �� �׼� �����ϴ� �ڷ�ƾ ����
        }

        public void OnDisable()
        {
            if(InputManager.Instance.GetInputAction("Move") != null)
                InputManager.Instance.GetInputAction("Move").performed -= OnMove; // "Move" �׼� �̺�Ʈ ���� ����

            if (InputManager.Instance.GetInputAction("Look") != null)
                InputManager.Instance.GetInputAction("Look").performed -= OnLook; // "Look" �׼� �̺�Ʈ ���� ����

            if (InputManager.Instance.GetInputAction("Interaction") != null)
                InputManager.Instance.GetInputAction("Interaction").performed -= OnInteraction; // "Interaction" �׼� �̺�Ʈ ���� ����
        }

        public bool IsInputActionCalling(string key) // ��ǲ�� ��� ������ �ִ��� Ȯ���ϴ� �Լ�
        {
            if (InputManager.Instance.GetInputAction(key).phase == InputActionPhase.Waiting) // ���� ��ǲ�� ��ٸ��� ���¶��
                return false; // false ��ȯ

            return true; // �ƴҰ�� true ��ȯ
        }

        // �ʱ�ȭ ��� �� �����ϴ� �ڷ�ƾ
        private IEnumerator WaitAndSubscribeCo()
        {
            yield return new WaitUntil(() => InputManager.Instance.IsInitialized); // ��ǲ �Ŵ��� �ʱ�ȭ�� �Ϸ�� ������ ���

            InputManager.Instance.GetInputAction("Move").performed += OnMove; // "Move" �׼� �̺�Ʈ ����
            InputManager.Instance.GetInputAction("Look").performed += OnLook; // "Look" �׼� �̺�Ʈ ����
            InputManager.Instance.GetInputAction("Interaction").performed += OnInteraction; // "Interaction" �׼� �̺�Ʈ ����
        }

        private void OnMove(InputAction.CallbackContext context) // PlayerInput���� �̵� ���͸� �޴� �Լ�
        {
            _moveVector = context.ReadValue<Vector2>(); // Vector2�� �о �Ҵ�
        }

        private void OnLook(InputAction.CallbackContext context) // PlayerInput���� ���� ���͸� �޴� �Լ�
        {
            _lookVector = context.ReadValue<Vector2>(); // Vector2�� �о �Ҵ�
        }

        private void OnInteraction(InputAction.CallbackContext context) // PlayerInput���� ��ȣ�ۿ� ���θ� �޴� �Լ�
        {
            if(GameManager.Instance.IsInteractionObjectFind) // ��ȣ�ۿ� ������ ������Ʈ�� ã���� ���� ��ǲ �ޱ�
            {
                IsInteraction = context.ReadValue<float>() == 1 ? true : false; // float���� �а� bool�� ��ȯ�ؼ� �Ҵ�
            }
        }
    }
}
// ������ �ۼ� ����: 2025.05.28