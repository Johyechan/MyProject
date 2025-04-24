using System;
using UnityEngine;

namespace MyUtil.ObjectPool
{
    // �ۼ���: ������
    // Serializable Ư���� ���� �ν����Ϳ��� ����ȭ�Ǿ� ����ó�� ����� �� �ֵ��� ����
    [Serializable]
    public class ObjectPoolData
    {
        public ObjectPoolType poolType;
        public GameObject prefab;
        public int poolCount;
    }
}
// ������ �ۼ� ����: 2025.04.24

