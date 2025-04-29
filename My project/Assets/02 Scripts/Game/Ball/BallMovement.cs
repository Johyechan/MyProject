using UnityEngine;

namespace Game.Ball
{
    // �ۼ���: ������
    // ���� �������� ó���ϴ� Ŭ����
    public class BallMovement : MonoBehaviour
    {
        // �������� �������� ������ ���� �������� ����
        private Rigidbody _rigid;

        // �ʱ�ȭ: �������� �ʱ�ȭ
        private void Awake()
        {
            // ���� ��ü�� �������� ��������
            _rigid = GetComponent<Rigidbody>();
            // ������ ��� ����
            _rigid.linearDamping = 0.5f;
        }

        // ������ �������� �ӵ���ŭ ������ �����̵��� �ϴ� ������ �Լ�
        public void Move(Vector3 tilt, float speed)
        {
            _rigid.AddForce(tilt.normalized * speed);
        }
    }
}
// ������ �ۼ� ����: 2025.04.29