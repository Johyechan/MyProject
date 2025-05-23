using Game.Manager;
using UnityEngine;

// ��ȣ�ۿ� ��ü ��ɵ��� ��Ƶ� ���ӽ����̽�
namespace Game.InteractionObject
{
    // �ڹ����� ��ȣ�ۿ��� ó���ϴ� Ŭ����
    public class LockInteraction : InteractionObjectBase
    {
        public bool IsLockInteractionOn { get; private set; } // �ڹ��� ��ȣ�ۿ��� �Ǿ����� ����

        public bool IsFailed { get; set; } // ���� ���� �Ǵ�

        public int SuccessCount { get; set; } // ���� ���� ī��Ʈ ����

        [SerializeField] private int _successGoal;

        private void Update()
        {
            if (!IsLockInteractionOn) // ��ȣ�ۿ� ���� �ƴ϶��
                return; // ��ȯ

            if(IsFailed) // �����ߴٸ�
            {
                Failed(); // ���� �Լ� ����
            }

            if(SuccessCount >= _successGoal) // �����ߴٸ�
            {
                Success(); // ���� �Լ� ����
            }
        }

        // ��ȣ�ۿ� �Լ�
        public override void Interaction() 
        {
            IsFailed = false;
            SuccessCount = 0;
            IsLockInteractionOn = true; // �ڹ��� ��ȣ�ۿ� O
            GameManager.Instance.IsNeedMousePos = true; // ���콺 Ŀ�� ��ġ�� ���̸� ������ ����
            ChangeChannel(); // ���� ī�޶��� �ó׸ӽ� �극�� ä�� ����
        }

        // �ڹ��� ���⸦ ���� ���� �� �Լ�
        private void Failed()
        {
            // �Ҹ� ��� - ö�ȰŸ��� �Ҹ�
            ChangeChannel(false); // ���� ä�η� ����
            IsLockInteractionOn = false; // �ڹ��� ��ȣ�ۿ� ��
            GameManager.Instance.IsNeedMousePos = false; // ���콺 Ŀ�� ��ġ�� ���̸� ���� �ʾƵ� �� ����
            GameManager.Instance.IsInteractionOn = false; // ��ȣ�ۿ� ��
        }

        // �ڹ��� ���⸦ ���� ���� �� �Լ�
        private void Success()
        {
            ChangeChannel(false); // ���� ä�η� ����
            IsLockInteractionOn = false; // �ڹ��� ��ȣ�ۿ� ��
            GameManager.Instance.IsNeedMousePos = false; // ���콺 Ŀ�� ��ġ�� ���̸� ���� �ʾƵ� �� ����
            GameManager.Instance.IsInteractionOn = false; // ��ȣ�ۿ� ��
        }
    }
}
// ������ �ۼ� ����: 2025.05.23