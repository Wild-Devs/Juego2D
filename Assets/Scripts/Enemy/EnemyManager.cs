using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    
    public float health;
    public float attack;

    private GameObject player;
    private PlayerStats ps;
    private Rigidbody2D rb;
    private BoxCollider2D box;

    private float cooldown = 0f;
    private float nextCooldown = 0.5f;
    private float time = 0f;

    void Start(){

        player = GameObject.Find("Player");
        ps = player.GetComponent<PlayerStats>();

        if(GetComponent<Rigidbody2D>()){
            rb = gameObject.GetComponent<Rigidbody2D>();
        }

        box = gameObject.GetComponent<BoxCollider2D>();

    }

    void Update(){

        if(getHealth() <= 0){

            Destroy(this.gameObject);

        }

        if(gameObject.name == "Projectile(Clone)"){

            time += Time.deltaTime;

            nextCooldown = 5;

            if(time > nextCooldown){

                Destroy(this.gameObject);

            }

        }

    }
    
    
    //HEALTH//
    public void setHealth(float health){

        this.health = health;

    }

    public float getHealth(){
        
        return health;

    }

    //ATTACK//
    public void setAttack(float attack){

        this.attack = attack;

    }

    public float getAttack(){

        return attack;

    }


    void OnTriggerStay2D(Collider2D collider){

        if(collider.tag.Equals("Attack") && Input.GetKeyDown(KeyCode.Mouse0)){

            if(Time.time > cooldown){

                setHealth(getHealth() - ps.getAttack());

                StartCoroutine("ChangeSprite");

                cooldown = Time.time + nextCooldown;

            }

        }

    }

    void OnCollisionEnter2D(Collision2D collision){

        if(gameObject.name == "Projectile(Clone)"){

            if(collision.collider.gameObject.layer == 8){

                Destroy(this.gameObject);

            }

            if(collision.collider.name == "Boss"){

                StartCoroutine("GoThrough");

            }

        }

    }

    IEnumerator GoThrough(){

        box.enabled = false;

        yield return new WaitForSeconds(0.3f);

        box.enabled = true;

    }

    IEnumerator ChangeSprite(){

        SpriteRenderer sprite = gameObject.GetComponent<SpriteRenderer>();

        sprite.color = Color.black;

        yield return new WaitForSeconds(0.1f);

        sprite.color = Color.white;       

    }

}
