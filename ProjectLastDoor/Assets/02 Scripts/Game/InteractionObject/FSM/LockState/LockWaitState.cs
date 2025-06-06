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
        public LockWaitState(LockBase lockBase, List<GameObject> buttons) : base(lockBase, buttons)
        {
        }

        public override void OnEnter()
        {
            base.OnEnter();

            foreach(GameObject button in _buttons) // �ڹ��� ��ư�� ��ȸ
            {
                button.layer = LayerMask.NameToLayer(GameManager.Instance.InteractionLayerName); // ���̾ ������� ��ȣ�ۿ� �����ϰ� ����
            }

            _lock.gameObject.layer = 0; // �ڹ���(�ڱ� �ڽ�)�� ��ȣ�ۿ����� ���ϵ��� ����
            _lock.ChangeChannel(); // �ó׸ӽ� ä�� ����
            _lock.IsFailed = false; // ���� �ʱ�ȭ
            _lock.SuccessCount = 0; // ���� �ʱ�ȭ
            GameManager.Instance.IsNeedMousePos = true; // ���콺 Ŀ�� ��ġ�� ���̸� ���� �Ѵٰ� ����
        }
    }
}
// ������ �ۼ� ����: 2025.06.04
