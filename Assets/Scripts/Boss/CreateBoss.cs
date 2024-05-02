using Boss;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateBoss : MonoBehaviour
{
    public GameObject boss;
    public Vector3 bossPosition; 
    private static bool HasBoss=false;
    public int enemiesAmount;

    // Update is called once per frame
    void Update()
    {
        if (BossBase.amountKillEnemies == enemiesAmount)
        {
            HasBoss = true;

        }
        if(HasBoss)
        {
            Instantiate(boss,bossPosition,Quaternion.identity);
            HasBoss = false;
        }


    }
}
