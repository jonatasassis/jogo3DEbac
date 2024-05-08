using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Scripts.Singleton;

public class CheckPointManager : Singleton<CheckPointManager>
{
    public int lastCheckPointKey = 0;
    public List<CheckPointBase> checkPoints;

    public bool hasCheckPoint()
    {
        return lastCheckPointKey>  0;
    }
    public void SaveLastCheckPoint(int i)
    {
        if(i>lastCheckPointKey)
        {
            lastCheckPointKey = i;
        }
    }

    public Vector3 GetPositionFromLastCheckPoint()
    {
       var checkPoint= checkPoints.Find(i=> i.key==lastCheckPointKey);
        return checkPoint.transform.position;
    }
}
