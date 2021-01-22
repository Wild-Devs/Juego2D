using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbilityManager : MonoBehaviour {
    private List<GameObject> dropItems = new List<GameObject>(6);
    private GameObject player;

    void Start() {
        player = GameObject.Find("Player");
    }

    void Update() {

    }

    public void equipar(GameObject item, int posicion, int tipoAbility) {
        dropItems[posicion] = item;
    }

    public void drop(GameObject item, int posicion) {
        Instantiate(item, player.transform.position, player.transform.rotation);
    }
}
