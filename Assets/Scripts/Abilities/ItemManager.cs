using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemManager : MonoBehaviour {
    
    private GameObject inventory, item;
    private List<GameObject> panels = new List<GameObject>();
    private bool[] isEquiped = {false, false, false, false, false, false};
    private static string[] buttonsKeys = {"EquiparCabeza", "EquiparTorso", "EquiparBrazoIzquierdo", "EquiparBrazoDerecho", "EquiparPiernaIzquierda", "EquiparPiernaDerecha" };
    private bool isPlayerInside = false;
    private EnumsAbilities.SlotsInventory posicionEquipo;

    public static ItemManager _instance;

    void Start() {
        _instance = this;
        inventory = GameObject.Find("Inventory");
        panels.Add(GameObject.Find("SlotCabeza"));
        panels.Add(GameObject.Find("SlotTorso"));
        panels.Add(GameObject.Find("SlotBrazoIzquierdo"));
        panels.Add(GameObject.Find("SlotBrazoDerecho"));
        panels.Add(GameObject.Find("SlotPiernaIzquierda"));
        panels.Add(GameObject.Find("SlotPiernaDerecha"));

        OcultarInventario();
    }

    void Update() {
        if (isPlayerInside) {
            if (Input.GetButton(buttonsKeys[(int) posicionEquipo])) {          
                if (isEquiped[(int)posicionEquipo]) {
                    Debug.Log("Dropea el item");

                }
                else {
                    Debug.Log("Se ha equipado el item");
                    isEquiped[(int)posicionEquipo] = true;
                }
                Destroy(item.gameObject);
            }
        }
    }

    public void OcultarInventario() {inventory.SetActive(false);}

    public void MostrarInventario() {inventory.SetActive(true);}

    public void PayerEnter(GameObject item) {
        this.item = item;
        isPlayerInside = true;
        MostrarInventario();
        QuePanelesCambianDeColor();
    }

    public void PayerExit() {
        isPlayerInside = false;
        OcultarInventario();
    }

    public void QuePanelesCambianDeColor() {
        posicionEquipo = item.gameObject.GetComponent<Item>().propiedades.GetPosicion();
        switch (posicionEquipo) {
            case EnumsAbilities.SlotsInventory.brazoDerecho:
                pintarBrazos();
                break;
            case EnumsAbilities.SlotsInventory.brazoIzquierdo:
                pintarBrazos();
                break;
            case EnumsAbilities.SlotsInventory.piernaIzquierda:
                pintarPiernas();
                break;
            case EnumsAbilities.SlotsInventory.piernaDerecha:
                pintarPiernas();
                break;
            default:
                CambiarColorPanel(panels[(int)posicionEquipo]);
                break;
        }
    }

    private void CambiarColorPanel(GameObject panel) {
        CanvasRenderer renderer = panel.GetComponent<CanvasRenderer>();
        renderer.SetColor(Color.green);
    }

    public void pintarBrazos() {
        CambiarColorPanel(panels[(int)EnumsAbilities.SlotsInventory.brazoIzquierdo]);
        CambiarColorPanel(panels[(int)EnumsAbilities.SlotsInventory.brazoDerecho]);
    }

    public void pintarPiernas() {
        CambiarColorPanel(panels[(int)EnumsAbilities.SlotsInventory.piernaIzquierda]);
        CambiarColorPanel(panels[(int)EnumsAbilities.SlotsInventory.piernaDerecha]);
    }
}
