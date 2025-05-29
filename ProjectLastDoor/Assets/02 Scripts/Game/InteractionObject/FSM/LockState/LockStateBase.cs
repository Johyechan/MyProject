using MyUtil.FSM;
using UnityEngine;

namespace Game.InteractionObject.FSM
{
    // �ۼ���: ������
    // �ڹ��� ������ �θ� Ŭ����
    public class LockStateBase : IState
    {
        protected LockInteraction _lockInteraction;

        public LockStateBase(LockInteraction lockInteraction)
        {
            _lockInteraction = lockInteraction;
        }

        public virtual void OnEnter()
        {
            Debug.Log($"{GetType().Name} ���� ����");
        }

        public virtual void OnExecute()
        {
            
        }

        public virtual void OnExit()
        {
            Debug.Log($"{GetType().Name} ����");
        }
    }
}
// ������ �ۼ� ����: 2025.05.28
