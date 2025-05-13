using Game.Manager;
using UnityEngine;

namespace Game.Ball
{
    // 작성자: 조혜찬
    // 공의 기능들을 이곳에 모아 처리
    public class BallController : MonoBehaviour
    {
        private void OnCollisionEnter(Collision collision)
        {
            // Goal과 닿으면 게임 클리어
            if(collision.gameObject.CompareTag("Goal"))
            {
                GameManager.Instance.GameClear();
            }
        }
    }
}
// 마지막 작성 일자: 2025.05.13