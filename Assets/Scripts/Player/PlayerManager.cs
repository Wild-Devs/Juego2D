using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerManager : MonoBehaviour
{

    public Transform initPlayerCoords;
    private Vector3 currentPlayerCoords;
    public AudioSource deathSound;
    public PlayerStats ps;
    private EnemyManager es;
    public Move2D mv;
    private bool onMovingPlat;
    
    public Text healthText;
    public Text maxHealthText;
    public Slider sliderHealth;
    public Text def;

    public AudioSource hit;
    public AudioSource attack;
    public AudioSource enterPortal;
    public AudioSource pickPowerUp;

    private Rigidbody2D rb;
    public float xForce;
    public float yForce;
    private float input;
    private float lastInput;

    private GameManager gm;
    private GameObject gameManager;

    private float cooldown = 0f;
    private float nextCooldown = 0.5f;

    public ItemManager itemManager;

    public void ActualizarUI() {
        healthText.text = ps.getHealth().ToString();
        maxHealthText.text = ps.getMaxHealth().ToString();
        def.text = ps.getDeffense().ToString();
    }

    void Start(){

        onMovingPlat = false;

        gameManager = GameObject.Find("GameManager");

        gm = gameManager.GetComponent<GameManager>();

        transform.position = initPlayerCoords.position;

        UpdateUI();

        rb = GetComponent<Rigidbody2D>();

        itemManager = GameObject.Find("GameManager").gameObject.GetComponent<ItemManager>();


    }

    void Update(){
        
        if(Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D)){
            input = Input.GetAxisRaw("Horizontal");
            lastInput = input;
        }else{
            input = lastInput;
        }
        

        if(mv.Grounded() && !onMovingPlat){

            currentPlayerCoords = transform.position;

        }

        if(ps.getHealth() <= 0){

            Death();

        }

        if(Input.GetKeyDown(KeyCode.Mouse0)){

            if(Time.time > cooldown){

                attack.Play();

                cooldown = Time.time + nextCooldown;

            }

        }

    }

    public float getInput(){

        return input;

    }


    void OnCollisionEnter2D(Collision2D collision){

        string name = collision.gameObject.name;

        //Debug.Log(name);

        switch(name){

            case "MovablePlatform":
                onMovingPlat = true;
                this.transform.parent = collision.transform;
                break;
            default:
                onMovingPlat = false;
                break;

        }

        //Debug.Log(collision.gameObject.tag);

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

                rb.velocity = new Vector3(-input * xForce, 0f, transform.position.z);
                rb.AddForce(Vector2.up * yForce, ForceMode2D.Impulse);

                if(name.Equals("Arrow(Clone)") || name.Equals("Projectile(Clone)")){

                    Destroy(collision.gameObject);

                }

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

            case "Finish":

                //SAVE//
                PlayerPrefs.SetFloat("PlayerHealth", ps.getHealth());
                PlayerPrefs.SetFloat("MaxHealth", ps.getMaxHealth());
                PlayerPrefs.SetFloat("Attack", ps.getAttack());
                PlayerPrefs.SetInt("Deffense", ps.getDeffense());
                PlayerPrefs.SetFloat("Speed", ps.getSpeed());

                PlayerPrefs.Save();

                enterPortal.Play();

                gm.ChangeScene();

                break;

            case "PowerUp":

                GameObject powerUp = GameObject.Find(collider.gameObject.name);

                PowerUpStats pw = powerUp.GetComponent<PowerUpStats>();

                ps.setAttack(ps.getAttack() + pw.getAttack());

                ps.setDeffense(ps.getDeffense() + pw.getDeffense());
                def.text = ps.getDeffense().ToString();

                if(pw.getHealth() + ps.getHealth() > ps.getMaxHealth()){
                    ps.setHealth(ps.getMaxHealth());
                }else{
                    ps.setHealth(ps.getHealth() + pw.getHealth());
                }
                healthText.text = ps.getHealth().ToString();
                sliderHealth.value = ps.getHealth();

                ps.setMaxHealth(ps.getMaxHealth() + pw.getMaxHealth());
                maxHealthText.text = ps.getMaxHealth().ToString();
                sliderHealth.maxValue = ps.getMaxHealth();

                ps.setSpeed(ps.getSpeed() + pw.getSpeed());

                pickPowerUp.Play();

                powerUp.SetActive(false);

                break;
            
            case "End":

                gm.Ending();

                break;
                                            
        }
            

    }

    void Death(){

        deathSound.Play();
        gm.ReloadScene();

    }

    void UpdateUI() {

        if (SceneManager.GetActiveScene().buildIndex == 1)
        {

            healthText.text = ps.getHealth().ToString();
            maxHealthText.text = ps.getMaxHealth().ToString();
            def.text = ps.getDeffense().ToString();

        }
        else if(SceneManager.GetActiveScene().buildIndex != 0 && SceneManager.GetActiveScene().buildIndex != 1){

            healthText.text = PlayerPrefs.GetFloat("PlayerHealth").ToString();
            maxHealthText.text = PlayerPrefs.GetFloat("MaxHealth").ToString();
            def.text = PlayerPrefs.GetInt("Deffense").ToString();

            sliderHealth.value = PlayerPrefs.GetFloat("PlayerHealth");
            sliderHealth.maxValue = PlayerPrefs.GetFloat("MaxHealth");

        }

    }

}
