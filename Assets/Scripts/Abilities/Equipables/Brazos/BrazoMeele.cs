using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrazoMeele : Brazo {
    private bool isAttacking = false;
    private Animation animation;

    private void Start() {
        animation = this.gameObject.GetComponent<Animation>();
    }

    public override void accion() {
        isAttacking = true;
        animation.Play();
    }

    void Update() {
        SeguirAlRaton();
        if (ControlarBotones() && !animation.isPlaying) {
            accion();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if (isAttacking && collision.tag == "Enemy") {
            collision.gameObject.GetComponent<EnemyManager>().health -= dmg;
        }
    }
}
