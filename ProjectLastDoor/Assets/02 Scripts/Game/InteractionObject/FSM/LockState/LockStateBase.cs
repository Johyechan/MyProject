using MyUtil.FSM;
using System.Collections.Generic;
using UnityEngine;

namespace Game.InteractionObject.FSM
{
    // �ۼ���: ������
    // �ڹ��� ������ �θ� Ŭ����
    public class LockStateBase : IState
    {
        protected LockBase _lock;
        protected List<GameObject> _buttons;

        public LockStateBase(LockBase lockBase, List<GameObject> buttons)
        {
            _lock = lockBase;
            _buttons = buttons;
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
            //Debug.Log($"{GetType().Name} ����");
        }
    }
}
// ������ �ۼ� ����: 2025.06.04
