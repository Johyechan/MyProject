using MyUtil.Transition;
using UnityEngine;

// �÷��̾� ���� ���ӽ����̽�
namespace Game.Player.Transition
{
    // �ۼ���: ������
    // ��� ���·� �����ϴ� Ŭ����
    public class PlayerIdleTransition : ITransition
    {
        public bool IsTransition()
        {
            return true;
        }
    }
}
// ������ �ۼ� ����: 2025.05.27
