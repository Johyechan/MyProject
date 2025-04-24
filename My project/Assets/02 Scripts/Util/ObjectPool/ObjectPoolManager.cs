using System.Collections.Generic;
using UnityEngine;

namespace MyUtil.ObjectPool
{
    // �ۼ���: ������
    // ������Ʈ Ǯ���� �������� ����� Ǯ�� �Ŵ���
    public class ObjectPoolManager : Singleton<ObjectPoolManager>
    {
        // ������Ʈ Ǯ���� ��ü���� �ν����� â���� �Ҵ��ϵ��� ���� Ǯ�� ������ ����Ʈ
        [SerializeField] private List<ObjectPoolData> _poolDataList = new();

        // ������Ʈ Ǯ���� Ǯ�� ����� ���� Ǯ�� ��
        private Dictionary<ObjectPoolType, ObjectPoolData> _poolDataMap = new();
        // ���� Ǯ
        private Dictionary<ObjectPoolType, Queue<GameObject>> _pool= new();

        protected override void Awake()
        {
            base.Awake();

            // ó�� ������ �� ������Ʈ���� �̸� Ǯ�� ����
            Init();
        }

        // Ǯ�� �����ϴ� �޼���
        private void Init()
        {
            // �ν����Ϳ� �Ҵ�Ǿ� �ִ� Ǯ���� ��ü�� �����͸� Ǯ�� �ʿ� �Ҵ�
            foreach(var data in _poolDataList)
            {
                _poolDataMap.Add(data.poolType, data);
            }

            // �ʿ� �ִ� ������ ������ Ǯ�� ����
            foreach(var data in _poolDataMap)
            {
                var poolType = data.Key;
                var poolCount = data.Value.poolCount; 

                _pool.Add(poolType, new Queue<GameObject>());

                for(int i = 0; i < poolCount; i++)
                {
                    GameObject newObj = CreateNewObject(poolType);
                    _pool[poolType].Enqueue(newObj);
                }
            }
        }

        // ������Ʈ�� ����� �ʱ�ȭ ��Ű�� �޼���
        private GameObject CreateNewObject(ObjectPoolType type)
        {
            GameObject newObject = Instantiate(_poolDataMap[type].prefab, transform);
            newObject.transform.position = Vector3.zero;
            newObject.transform.rotation = Quaternion.identity;
            newObject.SetActive(false);
            return newObject;
        }

        // �ܺο��� Ǯ�� �����Ͽ� ���ϴ� Ÿ���� ��ü�� ������ �� ����ϴ� �޼���
        public GameObject GetObject(ObjectPoolType type, Transform parent)
        {
            if (_pool[type].Count > 0)
            {
                GameObject obj = _pool[type].Dequeue();
                obj.SetActive(true);
                obj.transform.SetParent(parent);
                return obj;
            }
            else
            {
                GameObject newObj = CreateNewObject(type);
                newObj.SetActive(true);
                newObj.transform.SetParent(parent);
                return newObj;
            }
        }

        // �ܺο��� ������ ����� ��ü�� �ٽ� Ǯ�� �����ٶ� ��� �޼���
        public void ReturnObject(ObjectPoolType type, GameObject obj)
        {
            obj.transform.position = Vector3.zero;
            obj.transform.rotation = Quaternion.identity;
            obj.transform.SetParent(transform);
            obj.SetActive(false);
            _pool[type].Enqueue(obj);
        }
    }

}
// ������ �ۼ� ����: 2025.04.24

