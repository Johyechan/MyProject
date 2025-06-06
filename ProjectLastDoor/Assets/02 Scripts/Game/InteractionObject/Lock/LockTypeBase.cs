using UnityEngine;

namespace Game.InteractionObject
{
    // 작성자: 조혜찬
    // 자물쇠 버튼, 고리 등과 같이 실제로 자물쇠를 여는데 사용되는 객체의 부모 클래스
    public abstract class LockTypeBase : InteractionObjectBase
    {
        public bool IsSuccess { get; set; } // 성공 여부 체크 변수
        public bool IsFailed { get; set; } // 실패 여부 체크 변수
    }
}
// 마지막 작성 일자: 2025.06.06

