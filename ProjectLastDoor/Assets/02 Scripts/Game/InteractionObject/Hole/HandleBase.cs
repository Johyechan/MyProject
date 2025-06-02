using Game.Manager;
using Game.NormalObject;
using Game.Player;
using UnityEngine;

namespace Game.InteractionObject
{
    // �ۼ���: ������
    // ������ �θ� Ŭ����
    public abstract class HandleBase : InteractionObjectBase
    {
        [SerializeField] protected OpenableObjectBase _openableObject; // ����, �� ��
        [SerializeField] protected int _holeNumber; // ���� ���� ��ȣ�� ���� ���� ���� ���� ��ȣ

        protected bool HasRightKey()
        {
            PlayerController player = GameManager.Instance.Player.GetComponent<PlayerController>(); // �÷��̾ ������ �ִ� ����(���� ��ȣ)�� �˱� ���� ������

            foreach(int number in player.KeyNumbers) // �÷��̾ ���� ���� ��ȣ ��ȸ
            {
                if(number == _holeNumber) // ��ġ�ϴ� ��ȣ�� �ִٸ�
                {
                    return true; // ����
                }
            }

            return false; // ����
        }
    }
}
// ������ �ۼ� ����: 2025.06.02
