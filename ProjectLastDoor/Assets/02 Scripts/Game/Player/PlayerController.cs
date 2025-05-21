using Game.Manager;
using UnityEngine;

// �÷��̾�� ���õ� ��ɵ��� ��Ƶ� ���ӽ����̽�
namespace Game.Player
{
    // �ۼ���: ������
    // �÷��̾�� �ʿ��� ��ɵ��� ��Ƽ� ó���ϴ� Ŭ����
    public class PlayerController : MonoBehaviour
    {
        [SerializeField] private float _moveSpeed; // �̵� �ӵ�
        [SerializeField] private float _disableDelay; // ��Ȱ��ȭ ��� �ð�
        [SerializeField] private float _enableDelay; // Ȱ��ȭ ��� �ð�
        [SerializeField] private Transform _playerCamTrans;

        private PlayerInputHandle _inputHandle; // ��ǲ�� ó���ϴ� Ŭ����
        private PlayerMovement _movement; // �������� ó���ϴ� Ŭ����

        // ���� �ʱ�ȭ
        private void Awake()
        {
            GameManager.Instance.Player = gameObject;

            _inputHandle = new PlayerInputHandle(this);
            _movement = new PlayerMovement(transform, _playerCamTrans, _moveSpeed);
        }

        // ��ü �ʱ�ȭ
        private void Start()
        {
            transform.rotation = Quaternion.identity;
        }

        private void OnEnable()
        {
            if(InputManager.Instance != null)
            {
                InputManager.Instance.WaitAndEnable(_enableDelay, true); // ��ǲ Ȱ��ȭ
                _inputHandle.OnEnable(); // ��ǲ �ڵ��� Ȱ��ȭ �Լ� ȣ��
            }
        }

        private void OnDisable()
        {
            if(InputManager.Instance != null)
            {
                _inputHandle.OnDisable(); // ��ǲ �ڵ��� ��Ȱ��ȭ �Լ� ȣ��
                InputManager.Instance.WaitAndEnable(_disableDelay, false); // ��ǲ ��Ȱ��ȭ
            }
        }

        private void Update()
        {
            if (_inputHandle.IsInputActionCalling("Look")) // "Look" ��ǲ�� �� ���� Ȯ��
                _movement.Look(_inputHandle.LookVector); // �� �����Ӹ��� ������ ���� �ٶ󺸰� �ϴ� �Լ� ȣ��

            if (_inputHandle.IsInputActionCalling("Move")) // "Move" ��ǲ�� �� ���� Ȯ��
                _movement.Move(_inputHandle.MoveVector); // �� �����Ӹ��� ������ �Լ� ȣ��
        }
    }
}
// ������ �ۼ� ����: 2025.05.21