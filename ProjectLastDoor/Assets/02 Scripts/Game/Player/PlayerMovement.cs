using Game.Manager;
using UnityEngine;

// �÷��̾�� ���õ� ��ɵ��� ��Ƶ� ���ӽ����̽�
namespace Game.Player
{
    // �ۼ���: ������
    // �÷��̾��� �������� ó���ϴ� Ŭ����
    public class PlayerMovement
    {
        private Transform _playerTrans; // �÷��̾��� Transform
        private Transform _playerCamTrans; // �÷��̾��� �� ������ �ϴ� ī�޶� Transform
        private float _moveSpeed; // �̵� �ӵ�

        // �����ڿ��� ���� �ʱ�ȭ
        public PlayerMovement(Transform playerTrans, Transform playerCamTrans, float moveSpeed)
        {
            _playerTrans = playerTrans;
            _playerCamTrans = playerCamTrans;
            _moveSpeed = moveSpeed;
            GameManager.Instance.Sensitivity = 10f;
        }

        // �����̴� �Լ�
        public void Move(Vector2 moveInput)
        {
            Vector3 moveDir = _playerTrans.forward.normalized * moveInput.y + _playerTrans.right.normalized * moveInput.x; // �÷��̾ �ٶ󺸰� �ִ� ������ �������� ������ + Vector2�� �̵� ���͸� �޾ұ� ������ x��(right)�� ������ �Ű������� y���� z��(forward)�� �̵����� ����
            _playerTrans.Translate(moveDir * _moveSpeed * Time.deltaTime, Space.World); //  �θ��� �����ӿ� �������� �ʱ� ���� Space�� ����� ����
        }

        // �����̴� ������ �ٶ󺸰� �ϴ� �Լ�
        public void Look(Vector2 lookDirection)
        {
            // ī�޶��� x�ุ ȸ���Ͽ� ���ϸ� ���� �� �ֵ��� �� + Space�� World�� �Ͽ� �θ��� ������ ���� �ʰ� ȸ���ϵ��� ���� + y�� �տ� '-'�� ���̴� ������ ���콺 ��ǥ��� ����Ƽ ��ǥ�谡 �ݴ��̱� ����(��) ���콺�� ���� �ø��� ��� �� ��� ���̸� ����Ƽ������ �Ʒ��� ȸ���� �׷��� -�� ���̸� ���콺�� �����̴� ���⿡ �°�) 
            _playerCamTrans.Rotate(new Vector3(-lookDirection.y, 0, 0) * GameManager.Instance.Sensitivity * Time.deltaTime, Space.World);

            // �÷��̾��� y�ุ ȸ���Ͽ� �¿츦 ���� �� �ֵ��� �� + Space�� World�� �Ͽ� �θ��� ������ ���� �ʰ� ȸ���ϵ��� ����
            _playerTrans.Rotate(new Vector3(0, lookDirection.x, 0) * GameManager.Instance.Sensitivity * Time.deltaTime, Space.World);
        }
    }
}
// ������ �ۼ� ����: 2025.05.21