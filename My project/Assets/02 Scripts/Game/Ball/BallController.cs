using Game.Manager;
using UnityEngine;

namespace Game.Ball
{
    // �ۼ���: ������
    // ���� ��ɵ��� �̰��� ��� ó��
    public class BallController : MonoBehaviour
    {
        private void OnCollisionEnter(Collision collision)
        {
            // Goal�� ������ ���� Ŭ����
            if(collision.gameObject.CompareTag("Goal"))
            {
                GameManager.Instance.GameClear();
            }
        }
    }
}
// ������ �ۼ� ����: 2025.05.13