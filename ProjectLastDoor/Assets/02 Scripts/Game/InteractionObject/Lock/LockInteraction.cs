using UnityEngine;

// ��ȣ�ۿ� ��ü ��ɵ��� ��Ƶ� ���ӽ����̽�
namespace Game.InteractionObject
{
    // �ڹ����� ��ȣ�ۿ��� ó���ϴ� Ŭ����
    public class LockInteraction : InteractionObjectBase
    {
        public bool IsLockInteractionOn { get; private set; } // �ڹ��� ��ȣ�ۿ��� �Ǿ����� ����

        public bool IsFailed { get; set; } // ���� ���� �Ǵ�

        public int SuccessCount { get; set; } // 

        // ���� �ʱ�ȭ
        private void Awake()
        {
            IsLockInteractionOn = false;
            IsFailed = false;
            SuccessCount = 0;
        }

        // ��ȣ�ۿ� �Լ�
        public override void Interaction() 
        {
            IsLockInteractionOn = true; // �ڹ��� ��ȣ�ۿ� O
            ChangeChannel(); // ���� ī�޶��� �ó׸ӽ� �극�� ä�� ����

        }
    }
}
// ������ �ۼ� ����: 2025.05.23