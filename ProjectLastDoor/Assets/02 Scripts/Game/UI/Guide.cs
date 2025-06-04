using Game.Manager;
using UnityEngine;

namespace Game.MyUI
{
    // 작성자: 조혜찬
    // 상호작용 키를 알려주는 UI 클래스
    public class Guide : MonoBehaviour
    {
        [SerializeField] private float _xPos;
        [SerializeField] private float _yPos;

        private RectTransform _rectTrans;

        private void Awake()
        {
            _rectTrans = GetComponent<RectTransform>();
        }

        private void Update()
        {
            if(GameManager.Instance.IsNeedMousePos) // 마우스 커서로 레이를 쏘는 상태라면
            {
                RectTransformUtility.ScreenPointToLocalPointInRectangle(_rectTrans.parent as RectTransform, Input.mousePosition, null, out Vector2 localPoint); // 마우스 위치를 RectTransform의 로컬 좌표로 변경
                _rectTrans.anchoredPosition = localPoint + new Vector2(_xPos, _yPos); // 마우스 위치에서 _xPos, _yPos만큼 떨어진 거리로 이동
            }
            else
            {
                _rectTrans.anchoredPosition = new Vector3(_xPos, _yPos); // _xPos, _yPos위치로 이동
            }
        }
    }
}
// 마지막 작성 일자: 2025.06.04
