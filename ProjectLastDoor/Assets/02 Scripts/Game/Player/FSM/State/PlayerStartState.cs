using UnityEngine;

namespace Game.Player.FSM
{
    // �ۼ���: ������
    // ����(�÷��̾ ó�� ��� ����) ����
    public class PlayerStartState : PlayerStateBase
    {
        private Animator _animator;

        public PlayerStartState(Animator animator)
        {
            _animator = animator;
        }

        public override void OnEnter()
        {
            base.OnEnter();

            // �ִϸ��̼� ����
            _animator.enabled = true;
        }

        public override void OnExit()
        {
            base.OnExit();

            // �ִϸ��̼�  ����
            _animator.enabled = false;
        }
    }
}
// ������ �ۼ� ����: 2025.05.27
