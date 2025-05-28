using Game.Interface;
using MyUtil.FSM;
using MyUtil.Transition;
using Unity.Cinemachine;
using UnityEditor.Build.Content;
using UnityEngine;

namespace Game.InteractionObject
{
    // �ۼ���: ������
    // ��ȣ�ۿ� ��ü�� �⺻ Ʋ�� ������ �߻� Ŭ����
    public abstract class InteractionObjectBase : MonoBehaviour, IInteraction
    {
        [SerializeField] private CinemachineBrain _brain;
        [SerializeField] private CinemachineCamera _interactionCam;
        [SerializeField] private CinemachineCamera _playerCam;

        protected StateMachine _machine;

        protected TransitionHandle _transitionHandle;

        protected virtual void Awake()
        {
            _machine = new StateMachine();
        }

        protected virtual void Update()
        {
            if (_transitionHandle.CheckTransition()) return;

            _machine.UpdateExecute();
        }

        public abstract void Interaction(); // ��ȣ�ۿ� �Լ�

        // ���� ����ϴ� �ó׸ӽ� ä�� ���� �Լ�
        public void ChangeChannel(bool IsInteraction = true)
        {
            if(IsInteraction)
                _brain.ChannelMask = _interactionCam.OutputChannel; // ���� ī�޶��� ä���� ���� �ó׸ӽ��� ä�η� ����
            else
                _brain.ChannelMask = _playerCam.OutputChannel; // ���� ī�޶��� ä���� �÷��̾� �ó׸ӽ� ä�η� ����
        }
    }
}
// ������ �ۼ� ����: 2025.05.23
