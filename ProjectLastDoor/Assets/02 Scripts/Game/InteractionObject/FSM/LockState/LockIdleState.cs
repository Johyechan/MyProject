using Game.Manager;
using MyUtil.FSM;
using System.Collections.Generic;
using UnityEngine;

namespace Game.InteractionObject.FSM
{
    // �ۼ���: ������
    // �ڹ��迡 ��ȣ�ۿ��ϱ� �� ��� ����
    public class LockIdleState : LockStateBase
    {
        public LockIdleState(LockBase lockBase, List<GameObject> buttons) : base(lockBase, buttons)
        {
        }

        public override void OnEnter()
        {
            base.OnEnter();

            foreach(GameObject button in _buttons) // �ڹ��� ��ư�� ��ȸ
            {
                button.layer = 0; // ���̾ Default�� ������� ��ȣ�ۿ� �Ұ��ϰ� ����
                LockTypeBase buttonBtn = button.GetComponent<LockTypeBase>(); // �׸��� LockButton�� �����ͼ�
                buttonBtn.IsFailed = false; // ��ư �ʱ�ȭ (���� �ʱ�ȭ)
                buttonBtn.IsSuccess = false; // ��ư �ʱ�ȭ (���� �ʱ�ȭ)
            }

            _lock.gameObject.layer = LayerMask.NameToLayer(GameManager.Instance.InteractionLayerName); // �ڹ���(�ڱ��ڽ�)�� ��ȣ�ۿ� ������ ���·� ����
            _lock.ChangeChannel(false); // �÷��̾� �ó׸ӽ����� ä�� ��ȯ
            _lock.IsFailed = false; // ���� �ʱ�ȭ (���� �ʱ�ȭ)
            _lock.IsSuccess = false; // ���� �ʱ�ȭ (�������� ���� ���� �ʱ�ȭ)
            _lock.SuccessCount = 0; // ���� �ʱ�ȭ (���� �ʱ�ȭ)
        }
    }
}
// ������ �ۼ� ����: 2025.06.04
