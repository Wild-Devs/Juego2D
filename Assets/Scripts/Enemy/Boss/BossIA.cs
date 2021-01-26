using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BossIA : MonoBehaviour
{

    public Transform[] positions;
    public Transform[] projectilePositions;

    private float cooldown;
    public float nextCooldown;

    private int currentPos = 0;

    private SpriteRenderer sprite;
    public GameObject projectile;
    public GameObject rays;
    public GameObject raysWarning;

    private CircleCollider2D knockbackCollider;

    private EnemyManager em;
    public Slider sliderHealth;

    private GameManager gm;

    public ParticleSystem rayCharge;
    public ParticleSystem burst;


    
    void Start()
    {
        cooldown = 0f;

        sprite = gameObject.GetComponent<SpriteRenderer>();

        knockbackCollider = gameObject.GetComponent<CircleCollider2D>();

        knockbackCollider.enabled = false;

        em = gameObject.GetComponent<EnemyManager>();
        
        gm = GameObject.Find("GameManager").GetComponent<GameManager>();
        
    }

    
    void Update()
    {

        sliderHealth.value = em.getHealth();
        if(em.getHealth() <= 0){

            gm.Ending();

        }
        Attack();
    }

    void Attack(){

        if(Time.time > cooldown){

            int attack = Random.Range(1, 4);

            switch(attack){

                case 1:

                    StartCoroutine("Teleport");
                    
                    break;
                
                case 2:

                    StartCoroutine("SpawnProjectiles");

                    break;

                case 3:

                    StartCoroutine("ShootRays");

                    break;

            }

            cooldown = Time.time + nextCooldown;

        }

    }

    IEnumerator Teleport(){

        int tpPos = Random.Range(0, positions.Length);

        if(currentPos != tpPos){

            burst.Play();

            knockbackCollider.enabled = true;

            yield return new WaitForSeconds(0.2f);

            sprite.enabled = false;

            transform.position = positions[tpPos].transform.position;

            yield return new WaitForSeconds(0.5f);

            burst.Play();

            sprite.enabled = true;

            knockbackCollider.enabled = false;

            currentPos = tpPos;

        }else{

            Attack();

        }

    }

    IEnumerator SpawnProjectiles(){

        int cont = 0;

        int spawns = Random.Range(2, 6);

        do{

            int pos = Random.Range(0, projectilePositions.Length);

            Object.Instantiate(projectile, projectilePositions[pos].position, Quaternion.identity);
            yield return new WaitForSeconds(0.5f);
            cont++;
            
        }while(cont < spawns);

        StartCoroutine("Teleport");

    }

    IEnumerator ShootRays(){

        rayCharge.Play();

        GameObject rayWarningsClone = Object.Instantiate(raysWarning, transform.position, Quaternion.identity);

        yield return new WaitForSeconds(1f);

        Destroy(rayWarningsClone);

        rayCharge.Stop();

        burst.Play();
        
        GameObject rayClone = Object.Instantiate(rays, transform.position, Quaternion.identity);

        yield return new WaitForSeconds(1f);

        Destroy(rayClone);
        
    }

    void OnTriggerStay2D(Collider2D collider){

        if(collider.name == "Player"){

            GameObject player = collider.gameObject;

            Rigidbody2D rb = player.GetComponent<Rigidbody2D>();

            PlayerManager pm = player.GetComponent<PlayerManager>();

            rb.velocity = new Vector3(-pm.getInput() * 10, 0f, transform.position.z);
            rb.AddForce(Vector2.up * 10, ForceMode2D.Impulse);            

        }

    }


}
