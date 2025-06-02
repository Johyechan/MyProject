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

        public LockWaitState(PushButtonLock pushButtonLock, List<GameObject> buttons) : base(pushButtonLock)
        {
            _buttons = buttons;
        }

        public override void OnEnter()
        {
            base.OnEnter();

            foreach(GameObject button in _buttons) // �ڹ��� ��ư�� ��ȸ
            {
                button.layer = LayerMask.NameToLayer(GameManager.Instance.InteractionLayerName); // ���̾ ������� ��ȣ�ۿ� �����ϰ� ����
            }

            _pushButtonLock.gameObject.layer = 0; // �ڹ���(�ڱ� �ڽ�)�� ��ȣ�ۿ����� ���ϵ��� ����
            _pushButtonLock.ChangeChannel(); // �ó׸ӽ� ä�� ����
            _pushButtonLock.IsFailed = false; // ���� �ʱ�ȭ
            _pushButtonLock.SuccessCount = 0; // ���� �ʱ�ȭ
            GameManager.Instance.IsNeedMousePos = true; // ���콺 Ŀ�� ��ġ�� ���̸� ���� �Ѵٰ� ����
        }
    }
}
// ������ �ۼ� ����: 2025.06.02
