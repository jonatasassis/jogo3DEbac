using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPointBase : MonoBehaviour
{
    public MeshRenderer meshRenderer;
    public int key = 01;
    private string checkPointKey= "CheckPointKey";
    private bool checkPointActivated = false;
    private void OnTriggerEnter(Collider col)
    {
        if (!checkPointActivated && col.transform.tag == "Player")
        {
            TurnOnCheckPoint();
            CheckCheckPoint();
        }
    }

    private void CheckCheckPoint()
    {
        SaveCheckPoint();
    }

    [NaughtyAttributes.Button]
    private void TurnOffCheckPoint()
    {
        meshRenderer.material.SetColor("_EmissionColor", Color.grey);
    }
    [NaughtyAttributes.Button]
    private void TurnOnCheckPoint()
    {
        meshRenderer.material.SetColor("_EmissionColor", Color.white);
        SaveCheckPoint();
        print("liguei o checkpoint "+key);
    }

    private void SaveCheckPoint()
    {
        /* if (PlayerPrefs.GetInt(checkPointKey, 0) > key)
         {
             PlayerPrefs.SetInt(checkPointKey, key);
         }*/

        CheckPointManager.Instance.SaveLastCheckPoint(key);
        checkPointActivated = true;
    }
}
