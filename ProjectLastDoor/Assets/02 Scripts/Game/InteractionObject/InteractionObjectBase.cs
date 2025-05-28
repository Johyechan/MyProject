using Game.Interface;
using MyUtil.FSM;
using MyUtil.Transition;
using Unity.Cinemachine;
using UnityEditor.Build.Content;
using UnityEngine;

namespace Game.InteractionObject
{
    // 작성자: 조혜찬
    // 상호작용 객체의 기본 틀을 가지는 추상 클래스
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

        public abstract void Interaction(); // 상호작용 함수

        // 현재 사용하는 시네머신 채널 변경 함수
        public void ChangeChannel(bool IsInteraction = true)
        {
            if(IsInteraction)
                _brain.ChannelMask = _interactionCam.OutputChannel; // 메인 카메라의 채널을 현재 시네머신의 채널로 변경
            else
                _brain.ChannelMask = _playerCam.OutputChannel; // 메인 카메라의 채널을 플레이어 시네머신 채널로 변경
        }
    }
}
// 마지막 작성 일자: 2025.05.23
