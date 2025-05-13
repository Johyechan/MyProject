using UnityEngine;

namespace Game.Struct
{
    // 작성자: 조혜찬
    // UI 애니메이션에 필요한 변수를 할당하기 위한 구조체
    // 생성자의 매개변수를 줄이기 위해 만듦
    public struct UIAnimationVariables
    {
        // 코루틴을 실행시키기 위한 변수
        public MonoBehaviour mono;
        // UI를 변형하기 위해서 필요한 변수
        public RectTransform rectTrans;
        // 애니메이션 실행 시간
        public float duration;
    }
}
// 마지막 작성 일자: 2025.05.13
