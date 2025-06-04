using Game.Manager;
using UnityEngine;

namespace Game.Player
{
    // �ۼ���: ������
    // �÷��̾��� �ൿ�� ó���ϴ� Ŭ����
    public class PlayerAct
    {
        private Transform _playerTrans; // �÷��̾��� Transform
        private Rigidbody _rigid; // �÷��̾��� ���� ����
        private Transform _playerCamTrans; // �÷��̾��� �� ������ �ϴ� ī�޶� Transform
        private float _moveSpeed; // �̵� �ӵ�

        // �����ڿ��� ���� �ʱ�ȭ
        public PlayerAct(Transform playerTrans, Rigidbody rigid, Transform playerCamTrans, float moveSpeed)
        {
            _playerTrans = playerTrans;
            _rigid = rigid;
            _playerCamTrans = playerCamTrans;
            _moveSpeed = moveSpeed;
        }

        // �����̴� �Լ�
        public void Move(Vector2 moveInput)
        {
            Vector3 moveDir = _playerTrans.forward.normalized * moveInput.y + _playerTrans.right.normalized * moveInput.x; // �÷��̾ �ٶ󺸰� �ִ� ������ �������� ������ + Vector2�� �̵� ���͸� �޾ұ� ������ x��(right)�� ������ �Ű������� y���� z��(forward)�� �̵����� ����
            _rigid.MovePosition(_playerTrans.position + (moveDir * _moveSpeed * Time.deltaTime)); // ���� �������� ������(�÷��̾��� ���� ��ġ���� �� �����Ӹ��� ������ �������� ������ �ӵ���ŭ)
        }

        // �����̴� ������ �ٶ󺸰� �ϴ� �Լ�
        public void Look(Vector2 lookDirection)
        {
            // ī�޶��� x�ุ ȸ���Ͽ� ���ϸ� ���� �� �ֵ��� �� + y�� �տ� '-'�� ���̴� ������ ���콺 ��ǥ��� ����Ƽ ��ǥ�谡 �ݴ��̱� ����(��) ���콺�� ���� �ø��� ��� �� ��� ���̸� ����Ƽ������ �Ʒ��� ȸ���� �׷��� -�� ���̸� ���콺�� �����̴� ���⿡ �°�) 
            _playerCamTrans.Rotate(new Vector3(-lookDirection.y, 0, 0) * GameManager.Instance.Sensitivity * Time.deltaTime);

            // �÷��̾��� y�ุ ȸ���Ͽ� �¿츦 ���� �� �ֵ��� ��
            _playerTrans.Rotate(new Vector3(0, lookDirection.x, 0) * GameManager.Instance.Sensitivity * Time.deltaTime);
        }
    }
}
// ������ �ۼ� ����: 2025.06.04