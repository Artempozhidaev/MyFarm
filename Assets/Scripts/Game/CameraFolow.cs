using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFolow : MonoBehaviour
{
    public Transform PlayerPosition;

    private Vector3 offset;
    // Start is called before the first frame update
    void Start()
    {
        offset = transform.position - PlayerPosition.position;
    }
    void LateUpdate()
    {
        transform.position = new Vector3(PlayerPosition.position.x + offset.x, PlayerPosition.position.y + offset.y, PlayerPosition.position.z + offset.z);
    }
}
