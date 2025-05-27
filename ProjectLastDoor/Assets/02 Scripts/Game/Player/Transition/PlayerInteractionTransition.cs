using Game.Manager;
using MyUtil.FSM;

namespace Game.Player.Transition
{
    // �ۼ���: ������
    // �÷��̾� ��ȣ��� ���� ���·� �����ϴ� Ŭ����
    public class PlayerInteractionTransition : PlayerTransitionBase
    {
        private PlayerInteractionRaycaster _interactionRaycaster;
        private PlayerInputHandle _inputHandle;

        public PlayerInteractionTransition(StateMachine machine, IState state, PlayerInteractionRaycaster interactionRaycaster, PlayerInputHandle inputHandle) : base(machine, state)
        {
            _interactionRaycaster = interactionRaycaster;
            _inputHandle = inputHandle;
        }

        public override bool IsTransition()
        {
            if (_interactionRaycaster.IsOnInteractionObject(GameManager.Instance.IsNeedMousePos)) // ��ȣ�ۿ� ��ü�� ����������
            {
                if (_inputHandle.IsInteraction) // ��ȣ�ۿ� Ű�� �����ٸ�
                {
                    GameManager.Instance.IsInteractionOn = true; // ��ȣ�ۿ� ���̶�� ����
                    _inputHandle.IsInteraction = false; // Ŭ�� ���� �ʱ�ȭ
                    _interactionRaycaster.PlayInteraction(); // ��ȣ�ۿ�
                    ChangeState();
                    return true;
                }
            }

            return false;
        }
    }
}
// ������ �ۼ� ����: 2025.05.27
