using MyUtil.FSM;
using UnityEngine;

namespace Game.Player.FSM
{
    // �ۼ���: ������
    // �÷��̾� ������ ��Ʋ
    public class PlayerStateBase : IState
    {
        private string _name;

        public virtual void OnEnter()
        {
            _name = GetType().Name;
            Debug.Log($"{_name} ���·� ����");
        }

        public virtual void OnExecute()
        {
            Debug.Log($"{_name} ���� ��");
        }

        public virtual void OnExit()
        {
            Debug.Log($"{_name} ���� ����");
        }
    }
}
// ������ �ۼ� ����: 2025.05.26
