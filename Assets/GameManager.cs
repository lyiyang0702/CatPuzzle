using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    // Reset Level
    private List<Vector2> originalPos;
    private List<Quaternion> originalRotation;
    private Transform moveables;
    
    public void ResetLevel()
    {
        for (int i = 0; i < moveables.childCount; i++)
        {
            moveables.GetChild(i).position = originalPos[i];
            moveables.GetChild(i).rotation = originalRotation[i];
        }
    }
    
    
    // Start is called before the first frame update
    void Start()
    {
        SaveMoveableInitialTransform();
    }

    private void SaveMoveableInitialTransform()
    {
        originalPos = new List<Vector2>();
        originalRotation = new List<Quaternion>();
        moveables = GameObject.Find("Moveables").transform;
        for (int i = 0; i < moveables.childCount; i++)
        {
            originalPos.Add(moveables.GetChild(i).position);
            originalRotation.Add(moveables.GetChild(i).rotation);
        }
    }

    // Update is called once per frame
    void Update()
    {
        CheckLevelAccomplish();
    }
    
    public void CheckLevelAccomplish()
    {
        for (int i = 0; i < moveables.childCount; i++)
        {
            if (!moveables.GetChild(i).GetComponent<IMoveable>().IsInContainer())
            {
                return;
            }
        }
        LifeTimeBroadCaster.ProceedLevel();
    }
}
