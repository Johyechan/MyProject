using MyUtil.FSM;
using UnityEngine;

namespace Game.InteractionObject.FSM
{
    // �ۼ���: ������
    // �ڹ��� ������ �θ� Ŭ����
    public class LockStateBase : IState
    {
        protected PushButtonLock _pushButtonLock;

        public LockStateBase(PushButtonLock pushButtonLock)
        {
            _pushButtonLock = pushButtonLock;
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
