using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    
    public float health;
    public float attack;

    private GameObject player;
    private PlayerStats ps;

    void Start(){

        player = GameObject.Find("Player");
        ps = player.GetComponent<PlayerStats>();

    }

    void Update(){

        if(getHealth() <= 0){

            gameObject.SetActive(false);

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

            GameObject attack = GameObject.FindGameObjectWithTag("Attack");

            SpriteRenderer sprite = attack.GetComponent<SpriteRenderer>();

            Color color = Random.ColorHSV();

            sprite.color = color;

            setHealth(getHealth() - ps.getAttack());

        }

    }

}
