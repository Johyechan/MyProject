using UnityEngine;

namespace MyUtil
{
    // �ۼ���: ������
    // ���׸� Ÿ�� �̱������� MonoBehaviour�� ��� �ް� ������
    // �� ���׸� �̱����� ��� �޴� Ŭ������ ������ MonoBehaviour�� ����ϰ� �־�� ��
    public class Singleton<T> : MonoBehaviour where T : MonoBehaviour
    {
        // ���� ������ ����� ����
        private static T _instance;

        // ���� ������Ƽ�� �ܺο��� ������ �Ұ��� ������ �ν��Ͻ��� ������ �����ϵ��� ����
        public static T Instance
        {
            get
            {
                if(_instance == null)
                {
                    // �ν��Ͻ��� ���� ���۵ǰ� ó�� ã�� T Ÿ���� ������Ʈ�� �Ҵ��Ѵ�
                    _instance = FindFirstObjectByType<T>();

                    // ���� ���� ���� T Ÿ���� ���� null�� ���
                    if(_instance == null)
                    {
                        // ���Ӱ� GameObject�� ����� �� ������Ʈ�� T Ÿ���� ������Ʈ�� �߰��ϰ� �ν��Ͻ��� �Ҵ�
                        GameObject obj = new GameObject(typeof(T).Name);
                        _instance = obj.AddComponent<T>();
                        // ���� ���� ����Ǿ �������� �ʵ��� ����
                        DontDestroyOnLoad(obj);
                    }
                }

                return _instance;
            }
        }

        protected virtual void Awake()
        {
            if(_instance == null)
            {
                // �ν��Ͻ��� T Ÿ������ �Ҵ� �� ���� ���ص� �������� �ʵ��� ����
                _instance = this as T;
                DontDestroyOnLoad(gameObject);
            }
            else // ���� �ν��Ͻ��� ������ ���
            {
                // ���� ������Ʈ�� �����Ͽ� �ν��Ͻ��� ���ϼ� ����
                Destroy(gameObject);
            }
        }
    }
}
// ������ �ۼ� ����: 2025.04.24
