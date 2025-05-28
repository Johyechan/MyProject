using MyUtil.FSM;
using UnityEngine;

namespace Game.InteractionObject.FSM
{
    // �ۼ���: ������
    // �ڹ��� ��ư ������ �θ� Ŭ����
    public class LockButtonStateBase : IState
    {
        protected Material _material;

        protected float _animationTime;

        protected LockInteraction _lockInteraction;

        public LockButtonStateBase(Material material, float animationTime, LockInteraction lockInteraction)
        {
            _material = material;
            _animationTime = animationTime;
            _lockInteraction = lockInteraction;
        }

        public virtual void OnEnter()
        {
            
        }

        public virtual void OnExecute()
        {
            
        }

        public virtual void OnExit()
        {
            
        }
    }
}
// ������ �ۼ� ����: 2025.05.28
