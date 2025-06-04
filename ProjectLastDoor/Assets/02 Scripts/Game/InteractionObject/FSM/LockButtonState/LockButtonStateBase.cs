using DG.Tweening;
using Game.Manager;
using MyUtil.FSM;
using UnityEngine;

namespace Game.InteractionObject.FSM
{
    // �ۼ���: ������
    // �ڹ��� ��ư ������ �θ� Ŭ����
    public class LockButtonStateBase : IState
    {
        protected PushButtonLock _pushButtonLock;

        protected LockButton _lockButton;

        protected Material _material;

        protected float _animationTime;

        public LockButtonStateBase(PushButtonLock pushButtonLock, LockButton lockButton, Material material, float animationTime)
        {
            _pushButtonLock = pushButtonLock;
            _lockButton = lockButton;
            _material = material;
            _animationTime = animationTime;
        }

        public virtual void OnEnter()
        {
            //Debug.Log($"{GetType().Name} ���� ����");
        }

        public virtual void OnExecute()
        {

        }

        public virtual void OnExit()
        {
            //Debug.Log($"{GetType().Name} ���� ����");
        }
    }
}
// ������ �ۼ� ����: 2025.06.04
