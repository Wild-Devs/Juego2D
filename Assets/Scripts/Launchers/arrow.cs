using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class arrow : MonoBehaviour
{
    
    public float velocity;
    public float lifeTime;

    private Vector3 startPos;
    private Rigidbody2D rb;

    void Start(){

        startPos = transform.position;
        rb = gameObject.GetComponent<Rigidbody2D>();
        lifeTime = 0f;

    }

    
    void Update()
    {

        lifeTime += Time.deltaTime;

        rb.velocity = new Vector2(velocity, 0f);

        if(lifeTime >= 5f){

            this.gameObject.SetActive(false);

        }

    }

    void OnCollisionEnter2D(Collision2D collision){

        if(collision.collider.gameObject.layer == 8){

            this.gameObject.SetActive(false);

        }

    }
}
