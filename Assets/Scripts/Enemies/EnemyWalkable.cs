using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Enemy
{
    public class EnemyWalkable : EnemyBase
    {
        public GameObject[] wayPoints;
        private int index = 0;
        public float minDistance = 1;
        public float speed ;

        
        public override void Update()
        {
            base.Update();
            if (Vector3.Distance(transform.position, wayPoints[index].transform.position) < minDistance)
            {
                index++;

                if(index>= wayPoints.Length)
                {
                    index = 0;
                }
                
            }
            transform.position = Vector3.MoveTowards(transform.position, wayPoints[index].transform.position, Time.deltaTime * speed);
            transform.LookAt(wayPoints[index].transform.position);
        }
    }
}
