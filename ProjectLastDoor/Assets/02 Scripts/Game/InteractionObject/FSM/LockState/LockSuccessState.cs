using DG.Tweening;
using Game.Manager;
using System.Collections.Generic;
using UnityEngine;

namespace Game.InteractionObject.FSM
{
    // �ۼ���: ������
    // �ڹ��� Ǯ�� ���� ����
    public class LockSuccessState : LockStateBase
    {
        private Animator _successAnimator;

        public LockSuccessState(LockBase lockBase, List<GameObject> buttons, Animator animator) : base(lockBase, buttons)
        {
            _successAnimator = animator;
        }

        public override void OnEnter()
        {
            base.OnEnter();

            foreach (GameObject button in _buttons) // �ڹ��� ��ư�� ��ȸ
            {
                button.layer = 0; // ���̾ Default�� ������� ��ȣ�ۿ� �Ұ��ϰ� ����
                LockTypeBase buttonBtn = button.GetComponent<LockTypeBase>(); // �׸��� LockButton�� �����ͼ�
                buttonBtn.IsFailed = false; // ��ư �ʱ�ȭ (���� �ʱ�ȭ)
                buttonBtn.IsSuccess = false; // ��ư �ʱ�ȭ (���� �ʱ�ȭ)
            }

            Sequence sequence = DOTween.Sequence()
                .AppendCallback(() => _lock.ChangeChannel(false)) // �ó׸ӽ� ä�� �÷��̾� ä�η� ��ȯ
                .InsertCallback(1.5f, () => _successAnimator.enabled = true) // �ִϸ������� Ȱ��ȭ��Ű�鼭 �ִϸ��̼� ����
                .AppendCallback(() => _lock.IsLockInteractionOn = false) // �ڹ��� ��ȣ�ۿ� ����
                .AppendCallback(() => _lock.IsSuccess = true) // ���������� ����
                .AppendCallback(() => GameManager.Instance.IsNeedMousePos = false) // ���콺 Ŀ�� ��ġ�� ���� ���� �ʾƵ� �ȴٰ� ����
                .AppendCallback(() => GameManager.Instance.IsInteractionOn = false) // ��ȣ�ۿ� ��ü�� ����
                .AppendCallback(() => _lock.gameObject.layer = 0); // ���� ��ȣ�ۿ��� �Ұ����� ���·� ���� (0 = Default)
        }
    }
}
// ������ �ۼ� ����: 2025.06.04
