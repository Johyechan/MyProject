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
        private MonoBehaviour _mono; // �ڷ�ƾ�� �����ų ����

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