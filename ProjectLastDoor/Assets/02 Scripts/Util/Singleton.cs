using UnityEngine;

// ��ƿ��Ƽ ��ɵ��� ��Ƶ� ���ӽ����̽�
namespace MyUtil
{
    // �ۼ���: ������
    // �̱��� ������ ����� �Ǵ� ���׸� Ŭ����
    public class Singleton<T> : MonoBehaviour where T : MonoBehaviour
    {
        private static T _instance; // �ν��Ͻ�

        public static T Instance // �ν��Ͻ� ������Ƽ
        {
            get // �ܺο��� ���� �� ��
            {
                if(_instance == null) // ���� �ν��Ͻ��� null �̶��
                {
                    Debug.Log("Instance is null");
                }

                return _instance; // �ν��Ͻ� ��ȯ
            }
        }

        // �ν��Ͻ� �ʱ�ȭ
        protected virtual void Awake()
        {
            if (_instance != null && _instance != this) // �ڱ��ڽŰ� �ٸ� �� �ٸ� ���� üũ �ϱ� ���ؼ� this�͵� �ٸ��� Ȯ���ؾ���
            {
                Destroy(gameObject);
                return;
            }

            _instance = this as T;
            DontDestroyOnLoad(gameObject);
        }
    }
}
// ������ �ۼ� ����: 2025.05.21