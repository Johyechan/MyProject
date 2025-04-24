using System.Collections.Generic;
using UnityEngine;

namespace MyUtil.ObjectPool
{
    // 작성자: 조혜찬
    // 오브젝트 풀링을 전적으로 담당할 풀링 매니저
    public class ObjectPoolManager : Singleton<ObjectPoolManager>
    {
        // 오브젝트 풀링할 객체들을 인스펙터 창에서 할당하도록 만든 풀링 데이터 리스트
        [SerializeField] private List<ObjectPoolData> _poolDataList = new();

        // 오브젝트 풀링의 풀을 만들기 위한 풀링 맵
        private Dictionary<ObjectPoolType, ObjectPoolData> _poolDataMap = new();
        // 실제 풀
        private Dictionary<ObjectPoolType, Queue<GameObject>> _pool= new();

        protected override void Awake()
        {
            base.Awake();

            // 처음 시작할 때 오브젝트들을 미리 풀에 생성
            Init();
        }

        // 풀을 생성하는 메서드
        private void Init()
        {
            // 인스펙터에 할당되어 있는 풀링할 객체의 데이터를 풀링 맵에 할당
            foreach(var data in _poolDataList)
            {
                _poolDataMap.Add(data.poolType, data);
            }

            // 맵에 있는 정보를 가지고 풀을 생성
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

        // 오브젝트를 만들고 초기화 시키는 메서드
        private GameObject CreateNewObject(ObjectPoolType type)
        {
            GameObject newObject = Instantiate(_poolDataMap[type].prefab, transform);
            newObject.transform.position = Vector3.zero;
            newObject.transform.rotation = Quaternion.identity;
            newObject.SetActive(false);
            return newObject;
        }

        // 외부에서 풀에 접근하여 원하는 타입의 객체를 가져갈 때 사용하는 메서드
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

        // 외부에서 가져가 사용한 객체를 다시 풀에 돌려줄때 사용 메서드
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
// 마지막 작성 일자: 2025.04.24

