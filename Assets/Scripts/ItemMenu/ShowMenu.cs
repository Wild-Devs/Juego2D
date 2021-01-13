using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowMenu : MonoBehaviour {

    public GameObject itemMenu, cabeza, torso, brazoDerecho, brazoIzquierdo, piernaDerecha, piernaIzquierda;

    private void OnTriggerEnter2D(Collider2D collision) {
        Debug.Log("Ha entrado");
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
                if (Input.GetButtonDown("EquiparCabeza")) Debug.Log("Se ha equipado la cabeza");
                break;
            case "Torso":
                if (Input.GetButtonDown("EquiparTorso")) Debug.Log("Se ha equipado el torso");
                break;
            case "Brazos":
                if (Input.GetButtonDown("EquiparBrazoDerecho")) Debug.Log("Se ha equipado el brazo derecho");
                if (Input.GetButtonDown("EquiparBrazoIzquierdo")) Debug.Log("Se ha equipado el brazo izquierdo");
                break;
            case "Piernas":
                if (Input.GetButtonDown("EquiparPiernaDerecha")) Debug.Log("Se ha equipado la pierna derecha");
                if (Input.GetButtonDown("EquiparPiernaIzquierda")) Debug.Log("Se ha equipado la pierna izquierda");
                break;
            default:
                break;
        }
    }

    private void cambiarColor(GameObject slot) {
        CanvasRenderer renderer = slot.GetComponent<CanvasRenderer>();
        renderer.SetColor(Color.green);
    }
}
