using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;
public class EnemyGFX : MonoBehaviour
{
    public AIPath aiPath;
        
    void Update()
    {
//        if(aiPath.desiredVelocity.x >= 1f){
  //          transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y, transform.localScale.z);
    //    }else if(aiPath.desiredVelocity.x <= -1f){
      //      transform.localScale = new Vector3(transform.localScale.x, transform.localScale.y, transform.localScale.z);
//        }
//    }

        Debug.Log(aiPath.desiredVelocity.x);

    }
}
