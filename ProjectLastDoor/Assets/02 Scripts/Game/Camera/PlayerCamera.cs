using Game.Manager;
using Game.Player;
using UnityEngine;

namespace Game.MyCamera
{
    // �ۼ���: ������
    // �÷��̾� ������ ó���ϴ� ī�޶� Ŭ����
    public class PlayerCamera : MonoBehaviour
    {
        private float _lastXAngle = 0; // ������ ȸ�� ���� �����ϴ� ����
        private PlayerVariables _variables;
        [SerializeField] private float _xMaxAngle; // �ִ� ȸ�� ����
        [SerializeField] private float _xMinAngle; // �ּ� ȸ�� ����

        private void Start()
        {
            _variables = GameManager.Instance.Player.GetComponent<PlayerVariables>();
        }

        private void Update()
        {
            if(_variables.IsStart) // ���� ���� ���¶�� 
            {
                transform.rotation = GameManager.Instance.Player.transform.rotation; // �׳� �÷��̾��� ȸ�� ���¸� ����
            }
            else
            {
                // eulerAngles�� �ϴ� ������ rotation�� Quaternion ���̱� ������ Euler�� rotation ���� ���� ��� ������ �߻���
                float xAngle = transform.eulerAngles.x; // ���� x�� ȸ�� ��

                if (xAngle > 180) xAngle -= 360f; // ���� xAngle�� 180�� �̻��̶�� 360���� �� �ֳ��ϸ� ����Ƽ�� ���� ������ ������� �ʱ� ����

                if (xAngle > _xMinAngle && xAngle < _xMaxAngle) // x�� ȸ�� ���� -30 �̻�, 30 ������ ��� (ī�޶� �ڷ� ������ ȸ���ϴ� ��츦 ���� ����)
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
}
// ������ �ۼ� ����: 2025.05.30
