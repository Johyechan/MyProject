using System;
using UnityEngine;

namespace MyUtil.ObjectPool
{
    // 작성자: 조혜찬
    // Serializable 특성을 통해 인스펙터에서 직렬화되어 변수처럼 사용할 수 있도록 설정
    [Serializable]
    public class ObjectPoolData
    {
        public ObjectPoolType poolType;
        public GameObject prefab;
        public int poolCount;
    }
}
// 마지막 작성 일자: 2025.04.24

