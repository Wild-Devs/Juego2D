using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemMenuManager : MonoBehaviour {

    public GameObject itemMenu, cabeza, torso, brazoDerecho, brazoIzquierdo, piernaDerecha, piernaIzquierda, itemEquipado;
    private PlayerStats stats;

    private void OnTriggerEnter2D(Collider2D collision) {
        Debug.Log("Ha entrado");
        stats = collision.gameObject.GetComponent<PlayerStats>();
        if (collision.gameObject.tag == "Player") {
            string tag = this.gameObject.tag;
            itemMenu.SetActive(true);
            switch(tag) {
                case "Cabeza":
                    cambiarColor(cabeza);
                    break;
                case "Torso":
                    cambiarColor(torso);
                    break;
                case "Brazos":
                    cambiarColor(brazoDerecho);
                    cambiarColor(brazoIzquierdo);
                    break;
                case "Piernas":
                    cambiarColor(piernaDerecha);
                    cambiarColor(piernaIzquierda);
                    break;
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision) {
        Debug.Log("Ha salido");
        if (collision.gameObject.tag == "Player") {
            itemMenu.SetActive(false);
        }
    }

    private void OnTriggerStay2D(Collider2D collision) {
        string tag = this.gameObject.tag;
        switch (tag) {
            case "Cabeza":
                if (Input.GetButtonDown("EquiparCabeza")) {
                    Debug.Log("Se ha equipado la cabeza");
                    if (stats.getCabeza() != null) drop(stats.getCabeza(), collision.gameObject);
                    stats.setCabeza(itemEquipado);
                    Destroy(this.gameObject);
                }
                break;
            case "Torso":
                if (Input.GetButton("EquiparTorso")) {
                    Debug.Log("Se ha equipado el torso");
                    if (stats.getTorso() != null) drop(stats.getTorso(), collision.gameObject);
                    stats.setTorso(itemEquipado);
                    Destroy(this.gameObject);
                }
                break;
            case "Brazos":
                if (Input.GetButton("EquiparBrazoDerecho")) {
                    Debug.Log("Se ha equipado el brazo derecho");
                    if (stats.getBrazoDerecho() != null) drop(stats.getBrazoDerecho(), collision.gameObject);
                    stats.setBrazoDerecho(itemEquipado);
                    Destroy(this.gameObject);
                }
                if (Input.GetButton("EquiparBrazoIzquierdo")) {
                    Debug.Log("Se ha equipado el brazo izquierdo");
                    if (stats.getBrazoIzquierdo() != null) drop(stats.getBrazoIzquierdo(), collision.gameObject);
                    stats.setBrazoIzquierdo(itemEquipado);
                    Destroy(this.gameObject);
                }
                break;
            case "Piernas":
                if (Input.GetButton("EquiparPiernaDerecha")) {
                    Debug.Log("Se ha equipado la pierna derecha");
                    if (stats.getPiernaDerecha() != null) drop(stats.getPiernaDerecha(), collision.gameObject);
                    stats.setPiernaDerecha(itemEquipado);
                    Destroy(this.gameObject);
                }
                if (Input.GetButton("EquiparPiernaIzquierda")) {
                    Debug.Log("Se ha equipado la pierna izquierda");
                    if (stats.getPiernaIzquierda() != null) drop(stats.getPiernaIzquierda(), collision.gameObject);
                    stats.setPiernaIzquierda(itemEquipado);
                    Destroy(this.gameObject);
                }
                break;
        }
    }

    private void drop(GameObject drop, GameObject player) {
        Instantiate(drop, player.transform.position, player.transform.rotation);
    }

    private void cambiarColor(GameObject slot) {
        CanvasRenderer renderer = slot.GetComponent<CanvasRenderer>();
        renderer.SetColor(Color.green);
    }
}
