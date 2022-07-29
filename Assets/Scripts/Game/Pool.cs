using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pool
{
    public Transform Container { get; private set; }

    public Queue<GameObject> Objects;

    public Pool(Transform container)
    {
        Container = container;
        Objects = new Queue<GameObject>();
    }
}
