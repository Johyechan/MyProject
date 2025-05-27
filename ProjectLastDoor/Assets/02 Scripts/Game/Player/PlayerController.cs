using UnityEngine;

namespace Game.Player
{
    // �ۼ���: ������
    // �÷��̾�� �ʿ��� ��ɵ��� ��Ƽ� ó���ϴ� Ŭ����
    public class PlayerController : PlayerVariables
    {
        private void OnDrawGizmos()
        {
            Gizmos.DrawRay(_playerCamTrans.position, _playerCamTrans.forward * _rayDistance);
        }

        // ��ü �ʱ�ȭ
        private void Start()
        {
            _machine.ChangeState(_idleState); // ù ���¸� ��� ���·� ����
        }

        private void Update()
        {
            _transitionHandle.CheckTransition();

            _machine.UpdateExecute();
        }
    }
}
// ������ �ۼ� ����: 2025.05.22