using UnityEngine;

namespace Game.Map
{
    // �ۼ���: ������
    // ���� ��ɵ��� �����ϰ� ����ϴ� Ŭ���� 
    public class MapController : MonoBehaviour
    {
        // ���� ��ǲ ���� �޾ƿ��� ���� ����
        private MapInput _mapInput;

        // ���� ȸ����Ű�� ����� ����ϱ� ���� ����
        private MapRotateHandler _mapRotateHandler;

        // ���� �ʱ�ȭ
        private void Awake()
        {
            _mapInput = GetComponent<MapInput>();
            _mapRotateHandler = GetComponent<MapRotateHandler>();
        }

        private void Update()
        {
            // �� �����Ӹ��� ���� ȸ���� �������� ���� ����
            _mapRotateHandler.Rotate(_mapInput.TiltValue);
        }
    }
}
// ������ �ۼ� ����: 2025.05.05
