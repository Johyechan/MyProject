using UnityEngine;

namespace Game.Ball
{
    // �ۼ���: ������
    // ������ ���õ� ��ɵ��� ��Ƽ� �����ϴ� Ŭ����
    public class BallController : MonoBehaviour
    {
        // ���� ��ǲ ó�� Ŭ���� ����
        private BallInput _ballInput;
        // ���� ������ ó�� Ŭ���� ����
        private BallMovement _ballMovement;

        // �ʱ�ȭ: Ŭ���� ���� �ʱ�ȭ
        private void Awake()
        {
            _ballInput = GetComponent<BallInput>();
            _ballMovement = GetComponent<BallMovement>();
        }

        void Start()
        {

        }

        void Update()
        {
            _ballMovement.Move(_ballInput.TiltValue, 1f);
        }
    }
}
// ������ �ۼ� ����: 2025.04.29

