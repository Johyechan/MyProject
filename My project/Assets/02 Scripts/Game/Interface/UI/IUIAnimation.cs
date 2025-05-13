using System.Collections;
using UnityEngine;

namespace Game.Interface
{
    // 작성자: 조혜찬
    // UI 애니메이션들이 기본적으로 상속 받는 인터페이스
    public interface IUIAnimation
    {
        // 애니메이션을 실행 시키는 함수
        public void Play();

        // 애니메이션을 정지 시키는 함수
        public void Stop();

        // 실제 애니메이션을 구현할 코루틴
        public IEnumerator UIAnimationCo();
    }
}
// 마지막 작성 일자: 2025.05.13
