using MyUtil.FSM;
using System.Collections.Generic;
using UnityEngine;

namespace Game.InteractionObject.FSM
{
    // �ۼ���: ������
    // �ڹ��迡 ��ȣ�ۿ��ϱ� �� ��� ����
    public class LockIdleState : LockStateBase
    {
        private List<GameObject> _buttons;

        public LockIdleState(LockInteraction lockInteraction, List<GameObject> buttons) : base(lockInteraction)
        {
            _buttons = buttons;
        }

        public override void OnEnter()
        {
            base.OnEnter();

            foreach(GameObject button in _buttons) // �ڹ��� ��ư�� ��ȸ
            {
                button.layer = 0; // ���̾ Default�� ������� ��ȣ�ۿ� �Ұ��ϰ� ����
                LockButton buttonBtn = button.GetComponent<LockButton>(); // �׸��� LockButton�� �����ͼ�
                buttonBtn.IsFailed = false; // ��ư �ʱ�ȭ (���� �ʱ�ȭ)
                buttonBtn.IsSuccess = false; // ��ư �ʱ�ȭ (���� �ʱ�ȭ)
            }

            _lockInteraction.gameObject.layer = LayerMask.NameToLayer("Interaction"); // �ڹ���(�ڱ��ڽ�)�� ��ȣ�ۿ� ������ ���·� ����
            _lockInteraction.ChangeChannel(false); // �÷��̾� �ó׸ӽ����� ä�� ��ȯ
            _lockInteraction.IsFailed = false; // ���� �ʱ�ȭ (���� �ʱ�ȭ)
            _lockInteraction.SuccessCount = 0; // ���� �ʱ�ȭ (���� �ʱ�ȭ)
        }
    }
}
// ������ �ۼ� ����: 2025.05.29
