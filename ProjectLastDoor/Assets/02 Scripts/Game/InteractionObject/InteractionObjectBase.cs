using Game.Interface;
using UnityEngine;

// ��ȣ�ۿ� ��ü ����� ��Ƶ� ���ӽ����̽�
namespace Game.InteractionObject
{
    // �ۼ���: ������
    // ��ȣ�ۿ� ��ü�� �⺻ Ʋ�� ������ �߻� Ŭ����
    public abstract class InteractionObjectBase : MonoBehaviour, IInteraction
    {
        public abstract void Interaction(); // ��ȣ�ۿ� �Լ�
    }
}
// ������ �ۼ� ����: 2025.05.22
