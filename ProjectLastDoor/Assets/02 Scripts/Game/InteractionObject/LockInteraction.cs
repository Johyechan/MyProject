using UnityEngine;

// 상호작용 객체 기능들을 모아둔 네임스페이스
namespace Game.InteractionObject
{
    public class LockInteraction : InteractionObjectBase
    {
        [SerializeField] private Transform _interactionCam;

        public override void Interaction()
        {
            throw new System.NotImplementedException();
        }
    }
}

