using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionManager : MonoBehaviour
{

    private Vector3 initPlayerCoords;
    public AudioSource deathSound;

    void Start()
    {
        initPlayerCoords = transform.position;
    }


    void OnCollisionEnter2D(Collision2D collision){

        if(collision.gameObject.name.Equals("MovablePlatform")){
            this.transform.parent = collision.transform;
        }

    }

    void OnCollisionExit2D(Collision2D collision){

        if(collision.gameObject.name.Equals("MovablePlatform")){
            this.transform.parent = null;
        }

    }

    void OnTriggerEnter2D(Collider2D collider){

        switch(collider.tag){

            case "Death":
                transform.position = initPlayerCoords;
                Camera.main.transform.position = new Vector3(initPlayerCoords.x, initPlayerCoords.y, Camera.main.transform.position.z);
                deathSound.Play();
                break;          
        }
            

    }

}
