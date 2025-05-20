using MyUtil;
using UnityEngine;
using UnityEngine.InputSystem;

// �÷��̾�� ���õ� ��ɵ��� ��Ƶ� ���ӽ����̽�
namespace Game.Player
{
    // �ۼ���: ������
    // �÷��̾�� �ʿ��� ��ɵ��� ��Ƽ� ó���ϴ� Ŭ����
    public class PlayerController : MonoBehaviour
    {
        [SerializeField] private float _moveSpeed; // �̵� �ӵ�
        [SerializeField] private Transform _playerCamTrans;

        private PlayerInputHandle _inputHandle; // ��ǲ�� ó���ϴ� Ŭ����
        private PlayerMovement _movement; // �������� ó���ϴ� Ŭ����

        // ���� �ʱ�ȭ
        private void Awake()
        {
            _inputHandle = new PlayerInputHandle();
            _movement = new PlayerMovement(transform, _playerCamTrans, _moveSpeed);
        }

        private void OnEnable()
        {
            _inputHandle.OnEnable(); // ��ǲ �ڵ��� Ȱ��ȭ �Լ� ȣ��
        }

        private void OnDisable()
        {
            _inputHandle.OnDisable(); // ��ǲ �ڵ��� ��Ȱ��ȭ �Լ� ȣ��
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
// ������ �ۼ� ����: 2025.05.20