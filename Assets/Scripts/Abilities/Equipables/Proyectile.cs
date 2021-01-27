using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Proyectile : MonoBehaviour
{
    public float projectileDmg;

    void Start() {
        Debug.Log(projectileDmg);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("SeChoca");
        if (collision.collider.gameObject.layer == 8)
        {
            Destroy(this.gameObject);
        }
    }

    void Update()
    {
        transform.position += transform.right;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            EnemyManager manager = collision.gameObject.GetComponent<EnemyManager>();
            Debug.Log(manager);
            manager.setHealth(manager.getHealth() - projectileDmg);
            
            Destroy(this.gameObject);
        }
        if (collision.gameObject.layer == 8)
        {
            Destroy(this.gameObject);
        }
    }
}
