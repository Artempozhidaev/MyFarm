using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

public class PoolSystem : MonoBehaviour
{
    public static PoolSystem instance;

    [Serializable]
    public struct ObjectInfo
    {
        public enum ObjectType
        {
            Grass,
            Stack
        }

        public ObjectType Type;
        public GameObject gO_prefab;
        public int StartCount;
    }

    [SerializeField]
    private List<ObjectInfo> objectsInfo;

    private Dictionary<ObjectInfo.ObjectType, Pool> pools;

    private void Awake()
    {
        if (instance == null)
            instance = this;

        InitPool();
    }
    private void InitPool()
    {
        pools = new Dictionary<ObjectInfo.ObjectType, Pool>();

        var emptyGO = new GameObject();

        foreach (var obj in objectsInfo)
        {
            var container = Instantiate(emptyGO, transform, false);
            container.name = obj.Type.ToString();


            pools[obj.Type] = new Pool(container.transform);

            for (int i = 0; i < obj.StartCount; i++)
            {
                var go = InstantiateObject(obj.Type, container.transform);
                pools[obj.Type].Objects.Enqueue(go);
            }
        }
        Destroy(emptyGO);
    }

    private GameObject InstantiateObject(ObjectInfo.ObjectType type, Transform parent)
    {
        var go = Instantiate(objectsInfo.Find(x => x.Type == type).gO_prefab, parent);
        go.SetActive(false);
        return go;
    }

    public GameObject GetObject(ObjectInfo.ObjectType type)
    {
        var obj = pools[type].Objects.Count > 0 ?
            pools[type].Objects.Dequeue() : InstantiateObject(type, pools[type].Container);

        obj.SetActive(true);

        return obj;
    }

    public void DestroyObject(GameObject obj)
    {
        pools[obj.GetComponent<IPooledObject>().Type].Objects.Enqueue(obj);
        obj.SetActive(false);
    }
}
