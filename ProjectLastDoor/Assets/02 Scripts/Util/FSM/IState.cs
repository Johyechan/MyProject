namespace MyUtil.FSM
{
    // 작성자: 조혜찬
    // 상태 인터페이스
    public interface IState
    {
        public void OnEnter(); // 현재 상태로 처음 들어왔을 때

        public void OnExecute(); // 현재 상태가 지속 중일 때

        public void OnExit(); // 현재 상태를 나갈 때
    }
}
// 마지막 작성 일자: 2025.05.23
