using UnityEngine;

namespace Game.Map
{
    // 작성자: 조혜찬
    // 맵의 기능들을 관리하고 사용하는 클래스 
    public class MapController : MonoBehaviour
    {
        // 맵의 인풋 값을 받아오기 위한 변수
        private MapInput _mapInput;

        // 맵을 회전시키는 기능을 사용하기 위한 변수
        private MapRotateHandler _mapRotateHandler;

        // 변수 초기화
        private void Awake()
        {
            _mapInput = GetComponent<MapInput>();
            _mapRotateHandler = GetComponent<MapRotateHandler>();
        }

        private void Update()
        {
            // 매 프레임마다 맵의 회전을 기울어짐에 따라 변경
            _mapRotateHandler.Rotate(_mapInput.TiltValue);
        }
    }
}
// 마지막 작성 일자: 2025.05.05
