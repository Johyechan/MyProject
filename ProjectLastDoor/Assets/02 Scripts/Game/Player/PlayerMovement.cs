using UnityEngine;

// �÷��̾�� ���õ� ��ɵ��� ��Ƶ� ���ӽ����̽�
namespace Game.Player
{
    // �ۼ���: ������
    // �÷��̾��� �������� ó���ϴ� Ŭ����
    public class PlayerMovement
    {
        private Transform _playerTrans; // �÷��̾��� Transform
        private float _moveSpeed; // �̵� �ӵ�

        // �����ڿ��� ���� �ʱ�ȭ
        public PlayerMovement(Transform playerTrans, float moveSpeed)
        {
            _playerTrans = playerTrans;
            _moveSpeed = moveSpeed;
        }

        public void Move(Vector2 moveInput)
        {
            _playerTrans.Translate(new Vector3(moveInput.x, 0, moveInput.y) * _moveSpeed * Time.deltaTime, Space.World); // Vector2�� �̵� ���͸� �޾ұ� ������ x���� ������ �Ű������� y���� z���� �̵����� ���� + �θ��� �����ӿ� �������� �ʱ� ���� Space�� ����� ����
        }
    }
}
// ������ �ۼ� ����: 2025.05.19