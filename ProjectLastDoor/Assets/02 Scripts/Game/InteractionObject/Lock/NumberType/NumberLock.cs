using UnityEngine;

namespace Game.InteractionObject
{
    // �ۼ���: ������
    // ���� �ڹ��� Ŭ����
    public class NumberLock : InteractionObjectBase
    {
        public bool IsLockInteractionOn { get; set; } // �ڹ��� ��ȣ�ۿ� ����

        public override void Interaction()
        {
            IsLockInteractionOn = true; // �ڹ��� ��ȣ�ۿ� �Ϸ�
        }
    }
}
// ������ �ۼ� ����: 2025.06.05
