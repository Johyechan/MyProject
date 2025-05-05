using UnityEngine;

namespace Game.Map
{
    // �ۼ���: ������
    // ���� ȸ���� ó���ϴ� Ŭ����
    public class MapRotateHandler : MonoBehaviour
    {
        // ���� �������� �ӵ� ����
        [SerializeField] private float _rotationSpeed;

        // ���� ȸ���� ����ϴ� �Լ�
        public void Rotate(Vector3 tiltValue)
        {
            // x���� ������ ����, z���� �¿� ����
            float tiltX = tiltValue.x;
            float tiltZ = tiltValue.z;

            // ���� ���⿡ ���� ȸ�� ����
            Vector3 rotationDelta = new Vector3(-tiltX, 0f, tiltZ); // ��: ������ ����̸� ������ ȸ��
            transform.Rotate(rotationDelta * Time.deltaTime * _rotationSpeed);
        }
    }
}
// ������ �ۼ� ����: 2025.05.05
