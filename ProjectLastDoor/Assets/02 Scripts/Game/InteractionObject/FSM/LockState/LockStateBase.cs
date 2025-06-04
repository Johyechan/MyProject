using MyUtil.FSM;
using System.Collections.Generic;
using UnityEngine;

namespace Game.InteractionObject.FSM
{
    // 작성자: 조혜찬
    // 자물쇠 상태의 부모 클래스
    public class LockStateBase : IState
    {
        protected PushButtonLock _pushButtonLock;
        protected List<GameObject> _buttons;

        public LockStateBase(PushButtonLock pushButtonLock, List<GameObject> buttons)
        {
            _pushButtonLock = pushButtonLock;
            _buttons = buttons;
        }

        public virtual void OnEnter()
        {
            //Debug.Log($"{GetType().Name} 실행 시작");
        }

        public virtual void OnExecute()
        {
            
        }

        public virtual void OnExit()
        {
            //Debug.Log($"{GetType().Name} 종료");
        }
    }
}
// 마지막 작성 일자: 2025.06.04
