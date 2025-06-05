using UnityEngine;

namespace Game.InteractionObject
{
    // �ۼ���: ������
    // ���� �ڹ����� ���ư��� ���� �� Ŭ����
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
// ������ �ۼ� ����: 2025.06.05
