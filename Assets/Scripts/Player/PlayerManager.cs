using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerManager : MonoBehaviour
{

    private Vector3 initPlayerCoords;
    private Vector3 currentPlayerCoords;
    public AudioSource deathSound;
    public PlayerStats ps;
    private EnemyManager es;
    public Move2D mv;
    
    public Text healthText;
    public Text maxHealthText;
    public Slider sliderHealth;
    public Text def;

    public AudioSource hit;
    public AudioSource attack;

    private Rigidbody2D rb;
    public float xForce;
    public float yForce;
    private float input;
    private float lastInput;

    void Start(){

        initPlayerCoords = transform.position;

        healthText.text =  ps.getHealth().ToString();
        maxHealthText.text = ps.getMaxHealth().ToString();
        def.text = ps.getDeffense().ToString();

        rb = GetComponent<Rigidbody2D>();

    }

    void Update(){
        
        if(Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D)){
            input = Input.GetAxisRaw("Horizontal");
            lastInput = input;
        }else{
            input = lastInput;
        }
        

        if(mv.Grounded()){

            currentPlayerCoords = transform.position;

        }

        if(ps.getHealth() <= 0){

            Death();

        }

        if(Input.GetKeyDown(KeyCode.Mouse0)){

            attack.Play();

        }

    }


    void OnCollisionEnter2D(Collision2D collision){

        string name = collision.gameObject.name;

        //Debug.Log(name);

        switch(name){

            case "MovablePlatform":
                this.transform.parent = collision.transform;
                break;

        }

        switch(collision.gameObject.tag){

            case "Enemy":

                GameObject enemy = GameObject.Find(name);

                es = enemy.GetComponent<EnemyManager>();

                if(ps.getDeffense() > 0){

                    ps.setDeffense(ps.getDeffense() - 1);

                    def.text = ps.getDeffense().ToString();


                }else{

                    ps.setHealth(ps.getHealth() - es.getAttack());

                    if(ps.getHealth() < 0){
                        healthText.text = "0";
                    }else{
                        healthText.text = ps.getHealth().ToString();
                    }

                    sliderHealth.value = ps.getHealth();
            
                }

                rb.velocity = new Vector2(-input * xForce, 0);
                rb.AddForce(Vector2.up * yForce, ForceMode2D.Impulse);

                hit.Play();
            
            break;

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
            
                ps.setHealth(ps.getHealth() - 20);

                if(ps.getHealth() < 0){

                        healthText.text = "0";

                    }else{

                        healthText.text = ps.getHealth().ToString();

                    }

                sliderHealth.value = ps.getHealth();

                hit.Play();
                transform.position = currentPlayerCoords;

                break;
                
        }
            

    }

    void Death(){

        deathSound.Play();
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);

    }

}
