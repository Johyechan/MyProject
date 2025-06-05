using UnityEngine;

namespace Game.InteractionObject
{
    // 작성자: 조혜찬
    // 숫자 자물쇠의 돌아가는 숫자 고리 클래스
    public class NumberRing : InteractionObjectBase
    {
        private NumberLock _numberLock;

        protected override void Awake()
        {
            base.Awake();

            _numberLock = transform.parent.GetComponent<NumberLock>();
        }

        public override void Interaction()
        {
            if(_numberLock.IsLockInteractionOn)
            {

            }
        }
    }
}
// 마지막 작성 일자: 2025.06.05
