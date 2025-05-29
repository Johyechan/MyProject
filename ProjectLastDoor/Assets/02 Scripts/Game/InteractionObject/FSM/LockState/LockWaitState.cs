using Game.Manager;
using MyUtil.FSM;
using System.Collections.Generic;
using UnityEngine;

namespace Game.InteractionObject.FSM
{
    // �ۼ���: ������
    // �ڹ��� ��ȣ�ۿ� �� ����
    public class LockWaitState : LockStateBase
    {
        private List<GameObject> _buttons = new List<GameObject>();

        public LockWaitState(LockInteraction lockInteraction, List<GameObject> buttons) : base(lockInteraction)
        {
            _buttons = buttons;
        }

        public override void OnEnter()
        {
            base.OnEnter();

            foreach(GameObject button in _buttons) // �ڹ��� ��ư�� ��ȸ
            {
                button.layer = LayerMask.NameToLayer("Interaction"); // ���̾ ������� ��ȣ�ۿ� �����ϰ� ����
            }

            _lockInteraction.gameObject.layer = 0; // �ڹ���(�ڱ� �ڽ�)�� ��ȣ�ۿ����� ���ϵ��� ����
            _lockInteraction.ChangeChannel(); // �ó׸ӽ� ä�� ����
            _lockInteraction.IsFailed = false; // ���� �ʱ�ȭ
            _lockInteraction.SuccessCount = 0; // ���� �ʱ�ȭ
            GameManager.Instance.IsNeedMousePos = true; // ���콺 Ŀ�� ��ġ�� ���̸� ���� �Ѵٰ� ����
        }
    }
}
// ������ �ۼ� ����: 2025.05.28
