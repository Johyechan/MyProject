namespace MyUtil.FSM
{
    // �ۼ���: ������
    // ���� �������̽�
    public interface IState
    {
        public void OnEnter(); // ���� ���·� ó�� ������ ��

        public void OnExecute(); // ���� ���°� ���� ���� ��

        public void OnExit(); // ���� ���¸� ���� ��
    }
}
// ������ �ۼ� ����: 2025.05.23
