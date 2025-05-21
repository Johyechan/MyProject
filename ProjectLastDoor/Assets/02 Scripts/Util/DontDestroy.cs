using UnityEngine;

// ��ƿ��Ƽ ��ɵ��� ��Ƶ� ���ӽ����̽�
namespace MyUtil
{
    // �ۼ���: ������
    // �̱��� ��ü���� �θ� �ξ� �� ���� �����ϱ� ���ؼ� �̱��濡�� DontDestroyOnLoad�� ����� 
    // �θ𿡸� DontDestroyOnLoad�� �ٿ� ��� �̱����� �� ��ũ��Ʈ�� ���� ��ü�� �ڽ����� ��
    // ���� ����Ǿ �������� �ʰ� ����
    public class DontDestroy : MonoBehaviour
    {
        private void Awake()
        {
            DontDestroyOnLoad(this);
        }
    }
}
// ������ �ۼ� ����: 2025.05.21
