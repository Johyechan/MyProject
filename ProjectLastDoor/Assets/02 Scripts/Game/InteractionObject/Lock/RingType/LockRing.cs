using DG.Tweening;
using System.Runtime.CompilerServices;
using UnityEngine;

namespace Game.InteractionObject
{
    // �ۼ���: ������
    // ���� �ڹ����� ���ư��� ���� �� Ŭ����
    public class LockRing : LockTypeBase
    {
        [SerializeField] private float _rotateDuration; // ȸ�� �ð�
        [SerializeField] private float _successNumber; // ���� ����

        private RingLock _numberLock; // �θ� Ŭ����

        private bool _isCorrect; // ���� ���¿��ٰ� �ƴ� �� ���ְ� ���� ���°� �ƴϾ��� ���¿��� �� ���� ���� ���� ���� ����

        // �ʱ�ȭ
        protected override void Awake()
        {
            base.Awake();

            _isCorrect = false;
            _numberLock = transform.parent.GetComponent<RingLock>();
        }

        // ȸ���� ���� ��ȣ�� ��ȯ�ϴ� �Լ�
        private int RotationCalculator()
        {
            int number = 0;

            if(transform.rotation.eulerAngles.y > 0) // ���� ����� ��� + �� ���⸸ ������ ��....
            {
                Debug.Log($"��� {transform.rotation.eulerAngles.y}");
                number = (int)(transform.rotation.eulerAngles.y / 36); // 0~9 �� 10������ ���� ���ϱ� ���ؼ� -> (���������� ���� ����ȯ) ���� ȸ�� �� / (360�� 10���� ���� ����)36�� �մϴ�
                Debug.Log($"��� ��ȣ {number}");
                return number * 2; // ���� ���� �� �踦 ���༭ ū ��ȣ���� ��ȯ
            }
            else
            {
                Debug.Log($"���� {transform.rotation.eulerAngles.y}");
                number = (int)(transform.rotation.eulerAngles.y / 36); // 0~9 �� 10������ ���� ���ϱ� ���ؼ� -> (���������� ���� ����ȯ) ���� ȸ�� �� / (360�� 10���� ���� ����)36�� �մϴ�
                Debug.Log($"���� ��ȣ {number}");
                return number; // ���� �� �״�� ��ȣ���� ��ȯ
            }
        }

        public override void Interaction()
        {
            if(_numberLock.IsLockInteractionOn) // ���� �ڹ��谡 ��ȣ�ۿ�� ���¶��
            {
                float currentRotation = transform.rotation.eulerAngles.y; // ���� ȸ�� ���� euler���� ��������(rotation�� Quaternion���̶� ������ ����)
                transform.DORotate(new Vector3(0, currentRotation - 36f, 0), _rotateDuration); // ���� ȸ�� �� - 36��ŭ _rotateDuration���� ȸ���� ������ ȸ��

                if(RotationCalculator() == _successNumber) // ���� �����̶��
                {
                    Debug.Log("�� �Դϴ�");
                    _numberLock.SuccessCount++; // ���� ī��Ʈ �÷��ֱ�
                    _isCorrect = true; // �׸��� �����̶�� ����
                }
                else // ���� ���� ���ڰ� �ƴ϶��
                {
                    if(_isCorrect) // �׸��� ������ �����̾��ٸ�
                    {
                        _numberLock.SuccessCount--; // �ٽ� ���� ī��Ʈ �ٿ��ֱ�
                        _isCorrect = false; // �׸��� ������ �ƴ϶�� ����
                    }
                }
            }
        }
    }
}
// ������ �ۼ� ����: 2025.06.06
