using System.Collections.Generic;
using UnityEngine;

// Transition 네임스페이스
namespace MyUtil.Transition
{
    // 작성자: 조혜찬
    // Transition을 실행하는 클래스
    public class TransitionHandle
    {
        private List<ITransition> _transitions; // Transition 리스트
        
        // 생성자에서 변수 초기화
        public TransitionHandle(List<ITransition> transitions)
        {
            _transitions = transitions;
        }

        // Transition들을 순회하며 조건을 확인하는 함수
        public bool CheckTransition()
        {
            foreach(ITransition transtion in _transitions) // 리스트에 있는 Transition 순회
            {
                if (transtion.IsTransition()) // 만약 조건이 충족된 상태라면
                    return true; // true 반환
            }

            return false; // 모두 순회 했을 때 단 한 개도 조건이 충족된 상태가 아니라면 false 반환 
        }
    }
}
// 마지막 작성 일자: 2025.05.27
