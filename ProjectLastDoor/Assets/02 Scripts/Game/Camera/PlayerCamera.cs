using Game.Manager;
using UnityEngine;

// ī�޶�� ���õ� ��ɵ��� ��Ƶ� ���ӽ����̽�
namespace Game.Camera
{
    // �ۼ���: ������
    // �÷��̾� ������ ó���ϴ� ī�޶� Ŭ����
    public class PlayerCamera : MonoBehaviour
    {
        private float _lastXAngle = 0; // ������ ȸ�� ���� �����ϴ� ����

        private void Update()
        {
            // eulerAngles�� �ϴ� ������ rotation�� Quaternion ���̱� ������ Euler�� rotation ���� ���� ��� ������ �߻���
            float xAngle = transform.eulerAngles.x; // ���� x�� ȸ�� ��

            if (xAngle > -30f && xAngle < 30f) // x�� ȸ�� ���� -30 �̻�, 30 ������ ��� (ī�޶� �ڷ� ������ ȸ���ϴ� ��츦 ���� ����)
            {
                transform.rotation = Quaternion.Euler(xAngle, GameManager.Instance.Player.transform.eulerAngles.y, 0); // �׳� ���� �״�� �Ҵ�
                _lastXAngle = xAngle; // �׸��� ������ ȸ�� ���� ����
            }
            else // �ƴ϶��
            {
                transform.rotation = Quaternion.Euler(_lastXAngle, GameManager.Instance.Player.transform.eulerAngles.y, 0); // x���� ������ ȸ�� ������ �Ҵ�
            }
        }
    }
}
// ������ �ۼ� ����: 2025.05.20
