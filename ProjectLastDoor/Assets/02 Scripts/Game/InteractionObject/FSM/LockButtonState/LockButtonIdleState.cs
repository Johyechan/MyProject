using UnityEngine;

namespace Game.InteractionObject.FSM
{
    // �ۼ���: ������
    // ��ȣ�ۿ� ���� ���� ����
    public class LockButtonIdleState : LockButtonStateBase
    {
        public LockButtonIdleState(Material material, float animationTime, PushButtonLock pushButtonLock) : base(material, animationTime, pushButtonLock)
        {
        }
    }
}
// ������ �ۼ� ����: 2025.05.28
