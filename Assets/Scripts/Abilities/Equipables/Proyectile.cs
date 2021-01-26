using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Proyectile : MonoBehaviour {
    private float dmg;

    void Start() {
    }

    void OnCollisionEnter2D(Collision2D collision){
        Debug.Log("SeChoca");
        if(collision.collider.gameObject.layer == 8){
            Destroy(this.gameObject);
        }
    }

    void Update() {
        transform.position += transform.right;
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.tag == "Enemy") {
            EnemyManager manager = collision.gameObject.GetComponent<EnemyManager>();
            manager.setHealth(manager.getHealth() - dmg);
            Destroy(this.gameObject);
        }
        if(collision.gameObject.layer == 8){
            Destroy(this.gameObject);
        }
    }

    public void setDmg(float dmg) {
        this.dmg = dmg;
    }
}
