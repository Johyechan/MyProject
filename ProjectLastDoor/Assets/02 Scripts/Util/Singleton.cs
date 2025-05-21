using UnityEngine;

// 유틸리티 기능들을 모아둔 네임스페이스
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
                    Debug.Log("Instance is null");
                }

                return _instance; // 인스턴스 반환
            }
        }

        // 인스턴스 초기화
        protected virtual void Awake()
        {
            if (_instance != null && _instance != this) // 자기자신과 다른 또 다른 나를 체크 하기 위해서 this와도 다른지 확인해야함
            {
                Destroy(gameObject);
                return;
            }

            _instance = this as T;
            DontDestroyOnLoad(gameObject);
        }
    }
}
// 마지막 작성 일자: 2025.05.21