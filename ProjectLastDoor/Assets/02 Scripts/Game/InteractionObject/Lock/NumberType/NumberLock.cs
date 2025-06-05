using UnityEngine;

namespace Game.InteractionObject
{
    // 작성자: 조혜찬
    // 숫자 자물쇠 클래스
    public class NumberLock : InteractionObjectBase
    {
        public bool IsLockInteractionOn { get; set; } // 자물쇠 상호작용 여부

        public override void Interaction()
        {
            IsLockInteractionOn = true; // 자물쇠 상호작용 완료
        }
    }
}
// 마지막 작성 일자: 2025.06.05
