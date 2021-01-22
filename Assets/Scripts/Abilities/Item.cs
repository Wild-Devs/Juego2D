using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour {

    public ItemProperties propiedades = new ItemProperties(EnumsAbilities.Equipables.Tronco, false);
    //Clase que controla pasandole una posicion de enum si la habilidad es de brazo, torso, etc

    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.gameObject.tag == "Player") {
            collision.gameObject.GetComponent<PlayerManager>().itemManager.PayerEnter(this.gameObject);
            
        }
    }

    private void OnTriggerExit2D(Collider2D collision) {
        if (collision.gameObject.tag == "Player") {
            collision.gameObject.GetComponent<PlayerManager>().itemManager.PayerExit();
        }
    }

    //metodo para asignar el sprite cuando se crea
}
