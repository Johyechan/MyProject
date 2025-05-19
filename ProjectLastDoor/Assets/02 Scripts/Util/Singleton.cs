using UnityEngine;

// 공통적으로 사용되는 기능들을 모아둔 네임스페이스
namespace MyUtil
{
    // 작성자: 조혜찬
    // 싱글톤 패턴의 기반이 되는 제네릭 클래스
    public class Singleton<T> : MonoBehaviour where T : MonoBehaviour
    {
        private static T _instance; // 인스턴스

        public static T Instance // 인스턴스 프로퍼티
        {
            get // 외부에서 접근 할 때
            {
                if(_instance == null) // 만약 인스턴스가 null 이라면
                {
                    _instance = FindFirstObjectByType<T>(); // 현재 씬에서 처음 찾는 T 타입을 인스턴스로 할당
                    if(_instance == null) // 현재 씬에 T 타입이 없다면
                    {
                        GameObject newObj = new GameObject(typeof(T).Name); // T 타입을 이름으로 가진 새로운 객체 생성
                        _instance = newObj.AddComponent<T>(); // 새로운 객체에 T 타입의 클래스를 할당시키며 동시에 인스턴스에 할당
                        DontDestroyOnLoad(newObj); // 새로운 객체를 씬이 변경되어도 삭제 되지 않도록 지정
                    }
                }

                return _instance; // 인스턴스 반환
            }
        }

        // 인스턴스 초기화
        protected virtual void Awake()
        {
            if(_instance == null) // 만약 초기에 인스턴스가 null이라면
            {
                _instance = this as T; // 이 클래스를 T 타입으로 변환 후 인스턴스로 할당
                DontDestroyOnLoad(gameObject); // 이 객체를 씬이 변경되어도 삭제되지 않게 지정
            }
            else // 만약 이미 인스턴스가 있다면
            {
                Destroy(gameObject); // 이 객체를 삭제하며 인스턴스의 유일성 보장
            }
        }
    }
}
// 마지막 작성 일자: 2025.05.19