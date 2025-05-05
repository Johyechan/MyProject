using UnityEngine;

namespace Game.Map
{
    // 작성자: 조혜찬
    // 맵의 회전을 처리하는 클래스
    public class MapRotateHandler : MonoBehaviour
    {
        // 맵이 기울어지는 속도 변수
        [SerializeField] private float _rotationSpeed;

        // 맵의 회전을 담당하는 함수
        public void Rotate(Vector3 tiltValue)
        {
            // x축은 앞으로 기울기, z축은 좌우 기울기
            float tiltX = tiltValue.x;
            float tiltZ = tiltValue.z;

            // 기울기 방향에 따라 회전 적용
            Vector3 rotationDelta = new Vector3(-tiltX, 0f, tiltZ); // 예: 앞으로 기울이면 앞으로 회전
            transform.Rotate(rotationDelta * Time.deltaTime * _rotationSpeed);
        }
    }
}
// 마지막 작성 일자: 2025.05.05
