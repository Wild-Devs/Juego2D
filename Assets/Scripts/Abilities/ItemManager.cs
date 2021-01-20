using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemManager : MonoBehaviour {
    
    private GameObject inventory;
    private List<GameObject> panels = new List<GameObject>();
    public static ItemManager _instance;
    // Start is called before the first frame update
    
    void Start() {
        _instance = this;
        inventory = GameObject.Find("Inventory");
        panels.Add(GameObject.Find("SlotCabeza"));
        panels.Add(GameObject.Find("SlotTorso"));
        panels.Add(GameObject.Find("SlotBrazoIzquierdo"));
        panels.Add(GameObject.Find("SlotBrazoDerecho"));
        panels.Add(GameObject.Find("SlotPiernaIzquierda"));
        panels.Add(GameObject.Find("SlotPiernaDerecha"));
    }

    // Update is called once per frame
    void Update()
    {
    
    }

}
    public enum SlotsInventory 
    {
        cabeza,
        torso,
        brazoIzquierdo,
        brazoDerecho,
        piernaIzquierda,
        piernaDerecha
    }
