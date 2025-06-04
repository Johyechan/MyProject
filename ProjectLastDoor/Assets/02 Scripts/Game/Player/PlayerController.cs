using Game.Manager;
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

        private void OnDisable()
        {
            _inputHandle.OnDisable(); // ��ǲ �ڵ��� ��Ȱ��ȭ �Լ� ȣ��
        }

        // ��ü �ʱ�ȭ
        private void Start()
        {
            _machine.ChangeState(_startState); // ù ���¸� ��� ���·� ����
        }

        private void Update()
        {
            _transitionHandle.CheckTransition(); // ���� ���� ���� Ȯ��

            _machine.UpdateExecute(); // ���� ������ ����Ǿ�� �� �ڵ� ����
        }

        // ���� ���� �ִϸ��̼��� ����Ǹ� ȣ��� �ִϸ��̼� �Լ�
        private void OnAnimationEnd()
        {
            IsStart = false;

            _rigid.useGravity = true;
            // ��ǲ�� �ʿ��� ������ ó�� ���� �� �ִϸ��̼��� ���� ������ �� ���̱� ������ ���⼭ ��ǲ �Լ� Ȱ��ȭ
            _inputHandle.OnEnable(); // ��ǲ �ڵ��� ��Ȱ��ȭ �Լ� ȣ��
        }
    }
}
// ������ �ۼ� ����: 2025.06.04