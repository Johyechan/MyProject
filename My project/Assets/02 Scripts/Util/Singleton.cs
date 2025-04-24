using UnityEngine;

namespace MyUtil
{
    // 작성자: 조혜찬
    // 제네릭 타입 싱글톤으로 MonoBehaviour를 상속 받고 있으며
    // 이 제네릭 싱글톤을 상속 받는 클래스는 무조건 MonoBehaviour를 상속하고 있어야 함
    public class Singleton<T> : MonoBehaviour where T : MonoBehaviour
    {
        // 정적 변수로 만드는 이유
        private static T _instance;

        // 정적 프로퍼티로 외부에서 수정은 불가능 하지만 인스턴스에 접근은 가능하도록 구현
        public static T Instance
        {
            get
            {
                if(_instance == null)
                {
                    // 인스턴스를 씬이 시작되고 처음 찾는 T 타입의 오브젝트로 할당한다
                    _instance = FindFirstObjectByType<T>();

                    // 만약 현재 씬에 T 타입이 없어 null일 경우
                    if(_instance == null)
                    {
                        // 새롭게 GameObject를 만들고 그 오브젝트에 T 타입의 컴포넌트를 추가하고 인스턴스에 할당
                        GameObject obj = new GameObject(typeof(T).Name);
                        _instance = obj.AddComponent<T>();
                        // 이후 씬이 변경되어도 삭제되지 않도록 지정
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
                // 인스턴스를 T 타입으로 할당 후 씬이 변해도 삭제되지 않도록 지정
                _instance = this as T;
                DontDestroyOnLoad(gameObject);
            }
            else // 같은 인스턴스가 존재할 경우
            {
                // 현재 오브젝트를 삭제하여 인스턴스의 유일성 보장
                Destroy(gameObject);
            }
        }
    }
}
// 마지막 작성 일자: 2025.04.24
