using UnityEngine;

namespace Game.Struct
{
    // 작성자: 조혜찬
    // UI 팝업 애니메이션에 필요한 변수를 할당하기 위한 구조체
    // 생성자의 매개변수를 줄이기 위해 만듦
    public struct UIPopupAnimationVariables
    {
        // 최종 목표 지점
        public Vector3 targetPos;
        // 중간 목표 지점을 만들기 위한 변수
        public Vector3 overPos;
        // 중간 목표 지점까지 가는데 걸리는 시간 변수
        public float overMoveDuration;
    }
}
// 마지막 작성 일자: 2025.05.13
