using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MiniBossIA : MonoBehaviour
{

    public Transform[] positions;
    public Transform[] projectilePositions;

    private float cooldown;
    public float nextCooldown;

    private int currentPos = 0;

    private SpriteRenderer sprite;
    public GameObject projectile;

    private float scale;




    
    void Start()
    {
        cooldown = 0f;

        sprite = gameObject.GetComponent<SpriteRenderer>();

        scale = transform.localScale.x;
        
    }

    
    void Update()
    {
        Attack();
    }

    void Attack(){

        if(Time.time > cooldown){

            int attack = Random.Range(1, 3);

            switch(attack){

                case 1:

                    StartCoroutine("Teleport");
                    
                    break;
                
                case 2:

                    StartCoroutine("SpawnProjectiles");

                    break;

            }

            cooldown = Time.time + nextCooldown;

        }

    }

    IEnumerator Teleport(){

        int tpPos = Random.Range(0, positions.Length);

        if(currentPos != tpPos){

            sprite.enabled = false;

            transform.position = positions[tpPos].transform.position;

            yield return new WaitForSeconds(0.5f);

            if(tpPos == 1){
                transform.localScale = new Vector3(-scale, transform.localScale.y, transform.localScale.z);
            }else{
                transform.localScale = new Vector3(scale, transform.localScale.y, transform.localScale.z);
            }

            sprite.enabled = true;

            currentPos = tpPos;

        }else{

            Attack();

        }

    }

    IEnumerator SpawnProjectiles(){

        int cont = 0;

        int spawns = Random.Range(1, 3);

        do{

            int pos = Random.Range(0, projectilePositions.Length);

            Object.Instantiate(projectile, projectilePositions[pos].position, Quaternion.identity);
            yield return new WaitForSeconds(0.5f);
            cont++;
            
        }while(cont < spawns);

        StartCoroutine("Teleport");

    }


}
