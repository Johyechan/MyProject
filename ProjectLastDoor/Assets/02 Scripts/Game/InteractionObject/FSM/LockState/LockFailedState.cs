using DG.Tweening;
using Game.Manager;
using MyUtil.FSM;
using System.Collections.Generic;
using UnityEngine;

namespace Game.InteractionObject.FSM
{
    // �ۼ���: ������
    // �ڹ��� ǫ���� ������ ����
    public class LockFailedState : LockStateBase
    {
        private float _delay;

        public LockFailedState(PushButtonLock pushButtonLock, List<GameObject> buttons, float delay) : base(pushButtonLock, buttons)
        {
            _delay = delay;
        }

        public override void OnEnter()
        {
            base.OnEnter();

            Sequence sequence = DOTween.Sequence()
                .AppendCallback(() => {
                    foreach (GameObject button in _buttons) // �ڹ��� ��ư�� ��ȸ
                    {
                        LockButton buttonBtn = button.GetComponent<LockButton>(); // �׸��� LockButton�� �����ͼ�
                        buttonBtn.IsFailed = true; // ��� ��ư�� ���� ����
                    }
                })
                .AppendInterval(_delay)
                .AppendCallback(() => _pushButtonLock.ChangeChannel(false)) // �ó׸ӽ� ä�� �÷��̾� ä�η� ��ȯ
                .InsertCallback(_delay, () => _pushButtonLock.IsLockInteractionOn = false) // �ڹ��� ��ȣ�ۿ� ����
                .AppendCallback(() => GameManager.Instance.IsNeedMousePos = false) // ���콺 Ŀ�� ��ġ�� ���� ���� �ʾƵ� �ȴٰ� ����
                .AppendCallback(() => GameManager.Instance.IsInteractionOn = false); // ��ȣ�ۿ� ��ü�� ����
        }
    }
}
// ������ �ۼ� ����: 2025.06.04
