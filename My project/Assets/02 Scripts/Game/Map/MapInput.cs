using UnityEngine;

namespace Game.Map
{
    // 작성자: 조혜찬
    // 맵의 인풋 처리하는 클래스
    public class MapInput : MonoBehaviour
    {
        // 실제 사용할 기울기 값을 가지는 프로퍼티
        public Vector3 TiltValue { get; private set; }

        // 사용할 기울기 값을 조정할 변수
        private Quaternion _initRotation = Quaternion.identity;

        // 초기화: 인풋 액션 맵과 액션 찾기
        private void Awake()
        {
            // 자이로센서 활성화
            if(SystemInfo.supportsGyroscope)
            {
                Input.gyro.enabled = true;
            }
        }

        // 게임을 시작하면서 현재 기울기를 기본 기울기로 초기화
        private void Start()
        {
            ResetTilt();
        }

        private void Update()
        {
            // 자이로센서가 활성화 되어 있다면
            if(Input.gyro.enabled)
            {
                // 자이로 회전값 (디바이스 기준)
                Quaternion rawGyro = Input.gyro.attitude;

                // Unity 좌표계로 변환 (보정)
                // Unity 좌표계로 변환하는 이유는 디바이스에서의 z축과 유니티의 z축이 서로 반대이기 때문
                // -w는 회전 방향을 일관되게 맞추기 위해서
                Quaternion corrected = new Quaternion(rawGyro.x, rawGyro.y, -rawGyro.z, -rawGyro.w);

                // 초기 기준 회전값을 기준으로 회전 차이 계산
                Quaternion deltaRotation = Quaternion.Inverse(_initRotation) * corrected;

                // Euler 각도로 변환
                TiltValue = deltaRotation.eulerAngles;
            }
        }

        // 현재 기울어진 상태를 기본 값으로 초기화 하기 위한 함수
        public void ResetTilt()
        {
            if (Input.gyro.enabled)
            {
                Quaternion rawGyro = Input.gyro.attitude;
                // Unity 좌표계로 변환 (보정)
                _initRotation = new Quaternion(rawGyro.x, rawGyro.y, -rawGyro.z, -rawGyro.w);
            }
        }
    }
}
// 마지막 작성 일자: 2025.05.13