using UnityEngine;

namespace Game.Map
{
    // �ۼ���: ������
    // ���� ��ǲ ó���ϴ� Ŭ����
    public class MapInput : MonoBehaviour
    {
        // ���� ����� ���� ���� ������ ������Ƽ
        public Vector3 TiltValue { get; private set; }

        // ����� ���� ���� ������ ����
        private Quaternion _initRotation = Quaternion.identity;

        // �ʱ�ȭ: ��ǲ �׼� �ʰ� �׼� ã��
        private void Awake()
        {
            // ���̷μ��� Ȱ��ȭ
            if(SystemInfo.supportsGyroscope)
            {
                Input.gyro.enabled = true;
            }
        }

        // ������ �����ϸ鼭 ���� ���⸦ �⺻ ����� �ʱ�ȭ
        private void Start()
        {
            ResetTilt();
        }

        private void Update()
        {
            // ���̷μ����� Ȱ��ȭ �Ǿ� �ִٸ�
            if(Input.gyro.enabled)
            {
                // ���̷� ȸ���� (����̽� ����)
                Quaternion rawGyro = Input.gyro.attitude;

                // Unity ��ǥ��� ��ȯ (����)
                // Unity ��ǥ��� ��ȯ�ϴ� ������ ����̽������� z��� ����Ƽ�� z���� ���� �ݴ��̱� ����
                // -w�� ȸ�� ������ �ϰ��ǰ� ���߱� ���ؼ�
                Quaternion corrected = new Quaternion(rawGyro.x, rawGyro.y, -rawGyro.z, -rawGyro.w);

                // �ʱ� ���� ȸ������ �������� ȸ�� ���� ���
                Quaternion deltaRotation = Quaternion.Inverse(_initRotation) * corrected;

                // Euler ������ ��ȯ
                TiltValue = deltaRotation.eulerAngles;
            }
        }

        // ���� ������ ���¸� �⺻ ������ �ʱ�ȭ �ϱ� ���� �Լ�
        public void ResetTilt()
        {
            if (Input.gyro.enabled)
            {
                Quaternion rawGyro = Input.gyro.attitude;
                // Unity ��ǥ��� ��ȯ (����)
                _initRotation = new Quaternion(rawGyro.x, rawGyro.y, -rawGyro.z, -rawGyro.w);
            }
        }
    }
}
// ������ �ۼ� ����: 2025.05.13