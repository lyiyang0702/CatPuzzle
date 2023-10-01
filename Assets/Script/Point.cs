using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Point : MonoBehaviour
{
    public GameObject owner;


    public Vector2 GetPos()
    {
        return Camera.main.WorldToViewportPoint(transform.position);
    }
}
