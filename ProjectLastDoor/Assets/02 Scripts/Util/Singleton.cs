using UnityEngine;

// ���������� ���Ǵ� ��ɵ��� ��Ƶ� ���ӽ����̽�
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
                    _instance = FindFirstObjectByType<T>(); // ���� ������ ó�� ã�� T Ÿ���� �ν��Ͻ��� �Ҵ�
                    if(_instance == null) // ���� ���� T Ÿ���� ���ٸ�
                    {
                        GameObject newObj = new GameObject(typeof(T).Name); // T Ÿ���� �̸����� ���� ���ο� ��ü ����
                        _instance = newObj.AddComponent<T>(); // ���ο� ��ü�� T Ÿ���� Ŭ������ �Ҵ��Ű�� ���ÿ� �ν��Ͻ��� �Ҵ�
                        DontDestroyOnLoad(newObj); // ���ο� ��ü�� ���� ����Ǿ ���� ���� �ʵ��� ����
                    }
                }

                return _instance; // �ν��Ͻ� ��ȯ
            }
        }

        // �ν��Ͻ� �ʱ�ȭ
        protected virtual void Awake()
        {
            if(_instance == null) // ���� �ʱ⿡ �ν��Ͻ��� null�̶��
            {
                _instance = this as T; // �� Ŭ������ T Ÿ������ ��ȯ �� �ν��Ͻ��� �Ҵ�
                DontDestroyOnLoad(gameObject); // �� ��ü�� ���� ����Ǿ �������� �ʰ� ����
            }
            else // ���� �̹� �ν��Ͻ��� �ִٸ�
            {
                Destroy(gameObject); // �� ��ü�� �����ϸ� �ν��Ͻ��� ���ϼ� ����
            }
        }
    }
}
// ������ �ۼ� ����: 2025.05.19