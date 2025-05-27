using UnityEngine;

// Transition 네임스페이스
namespace MyUtil.Transition
{
    // 작성자: 조혜찬
    // Transition 기능 인터페이스
    public interface ITransition
    {
        // 전이 여부를 결정하는 함수
        public bool IsTransition();
    }
}
// 마지막 작성 일자: 2025.05.27
