using DG.Tweening;
using UnityEngine;

namespace Game.InteractionObject.FSM
{
    // �ۼ���: ������
    // ��ȣ�ۿ� ���� ���� ����
    public class LockButtonIdleState : LockButtonStateBase
    {
        public LockButtonIdleState(PushButtonLock pushButtonLock, LockButton lockButton, Material material, float animationTime) : base(pushButtonLock, lockButton, material, animationTime)
        {
        }

        public override void OnEnter()
        {
            base.OnEnter();

            _material.DOColor(Color.white, _animationTime); // ��ư �� �ʱ�ȭ
        }
    }
}
// ������ �ۼ� ����: 2025.06.04
