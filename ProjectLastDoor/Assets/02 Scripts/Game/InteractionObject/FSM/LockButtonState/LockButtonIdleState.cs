using UnityEngine;

namespace Game.InteractionObject.FSM
{
    // �ۼ���: ������
    // ��ȣ�ۿ� ���� ���� ����
    public class LockButtonIdleState : LockButtonStateBase
    {
        public LockButtonIdleState(Material material, float animationTime, LockInteraction lockInteraction) : base(material, animationTime, lockInteraction)
        {
        }
    }
}
// ������ �ۼ� ����: 2025.05.28
