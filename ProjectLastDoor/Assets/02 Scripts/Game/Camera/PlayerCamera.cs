using Game.Manager;
using UnityEngine;

// 카메라와 관련된 기능들을 모아둔 네임스페이스
namespace Game.Camera
{
    // 작성자: 조혜찬
    // 플레이어 시점을 처리하는 카메라 클래스
    public class PlayerCamera : MonoBehaviour
    {
        private float _lastXAngle = 0; // 마지막 회전 값을 저장하는 변수

        private void Update()
        {
            // eulerAngles를 하는 이유는 rotation은 Quaternion 값이기 때문에 Euler에 rotation 값을 넣을 경우 오류가 발생함
            float xAngle = transform.eulerAngles.x; // 현재 x축 회전 값

            if (xAngle > -30f && xAngle < 30f) // x축 회전 값이 -30 이상, 30 이하일 경우 (카메라가 뒤로 완전히 회전하는 경우를 막기 위해)
            {
                transform.rotation = Quaternion.Euler(xAngle, GameManager.Instance.Player.transform.eulerAngles.y, 0); // 그냥 값을 그대로 할당
                _lastXAngle = xAngle; // 그리고 마지막 회전 값을 저장
            }
            else // 아니라면
            {
                transform.rotation = Quaternion.Euler(_lastXAngle, GameManager.Instance.Player.transform.eulerAngles.y, 0); // x축은 마지막 회전 값으로 할당
            }
        }
    }
}
// 마지막 작성 일자: 2025.05.20
