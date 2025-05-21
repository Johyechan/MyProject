using UnityEngine;

// 유틸리티 기능들을 모아둔 네임스페이스
namespace MyUtil
{
    // 작성자: 조혜찬
    // 싱글톤 객체들의 부모를 두어 한 번에 관리하기 위해서 싱글톤에서 DontDestroyOnLoad를 지우고 
    // 부모에만 DontDestroyOnLoad를 붙여 모든 싱글톤이 이 스크립트를 가진 객체의 자식으로 들어가
    // 씬이 변경되어도 삭제되지 않게 설계
    public class DontDestroy : MonoBehaviour
    {
        private void Awake()
        {
            DontDestroyOnLoad(this);
        }
    }
}
// 마지막 작성 일자: 2025.05.21
