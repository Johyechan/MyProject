using Game.Interface;
using Unity.Cinemachine;
using UnityEngine;

// ��ȣ�ۿ� ��ü ����� ��Ƶ� ���ӽ����̽�
namespace Game.InteractionObject
{
    // �ۼ���: ������
    // ��ȣ�ۿ� ��ü�� �⺻ Ʋ�� ������ �߻� Ŭ����
    public abstract class InteractionObjectBase : MonoBehaviour, IInteraction
    {
        [SerializeField] private CinemachineBrain _brain;
        [SerializeField] private CinemachineCamera _currentCam;

        public abstract void Interaction(); // ��ȣ�ۿ� �Լ�

        // ���� ����ϴ� �ó׸ӽ� ä�� ���� �Լ�
        protected void ChangeChannel()
        {
            _brain.ChannelMask = _currentCam.OutputChannel; // ���� ī�޶��� ä���� ���� �ó׸ӽ��� ä�η� ����
        }
    }
}
// ������ �ۼ� ����: 2025.05.23
