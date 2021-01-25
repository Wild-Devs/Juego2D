using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemManager : MonoBehaviour {

    private GameObject inventory, item, player;
    private List<GameObject> slots = new List<GameObject>();
    private ItemProperties[] dropProperties = { null, null, null, null, null, null };
    private bool[] isEquipado = {false, false, false, false, false, false};
    private static string[] buttonsKeys = {"EquiparCabeza", "EquiparTorso", "EquiparBrazoIzquierdo", "EquiparBrazoDerecho", "EquiparPiernaIzquierda", "EquiparPiernaDerecha" };
    private bool isPlayerInside = false;
    private AbilityController AbilityController;

    public GameObject ItemPrefab; 
    public static ItemManager _instance;

    void Start() {
        _instance = this;
        inventory = GameObject.Find("Inventory");
        player = GameObject.Find("Player");
        GameObject panel = inventory.transform.GetChild(0).gameObject;
        for (int i = 0; i < panel.transform.childCount; i++) {
            slots.Add(panel.transform.GetChild(i).gameObject);
        }
        AbilityController = player.gameObject.GetComponent<AbilityController>();

        OcultarInventario();
    }

    void Update() {
        if (isPlayerInside) {
            ControlarBotones();
        }
    }

    public void EquiparItem(int posicion) {
        if (isEquipado[posicion]) {         
            drop(dropProperties[posicion]);
            AbilityController.HabilitarYDeshabilitarEquipo(posicion, dropProperties[posicion].GetIndexEquipo(), false);
        }
        Debug.Log("Se ha equipado el item");
        isEquipado[posicion] = true;
        dropProperties[posicion] = item.gameObject.GetComponent<Item>().propiedades;
        AbilityController.HabilitarYDeshabilitarEquipo(posicion, dropProperties[posicion].GetIndexEquipo(), true);
        Destroy(item.gameObject);
        
    }

    public void drop(ItemProperties properties) {
        Debug.Log("Dropea el item");
        GameObject drop = ItemPrefab;
        Vector3 dropPosition = new Vector3(player.transform.position.x + 1, player.transform.position.y + 1, player.transform.position.z);
        drop.gameObject.GetComponent<Item>().propiedades.SetIndexEquipo(properties.GetIndexEquipo());
        drop.gameObject.GetComponent<Item>().propiedades.SetPosicion(properties.GetPosicion());
        drop.gameObject.GetComponent<Item>().propiedades.SetSprite(properties.GetSprite());
        Instantiate(drop, dropPosition, player.transform.rotation);
    }


    public void ControlarBotones() {
        switch (item.gameObject.GetComponent<Item>().propiedades.GetPosicion()){
            case EnumsAbilities.PosicionesEquipo.brazos:
                if (Input.GetButton(buttonsKeys[(int)EnumsAbilities.SlotsInventory.brazoDerecho])) EquiparItem((int)EnumsAbilities.SlotsInventory.brazoDerecho);
                if (Input.GetButton(buttonsKeys[(int)EnumsAbilities.SlotsInventory.brazoIzquierdo])) EquiparItem((int)EnumsAbilities.SlotsInventory.brazoIzquierdo);
                break;
            case EnumsAbilities.PosicionesEquipo.piernas:
                if (Input.GetButton(buttonsKeys[(int)EnumsAbilities.SlotsInventory.piernaDerecha])) EquiparItem((int)EnumsAbilities.SlotsInventory.piernaDerecha);
                if (Input.GetButton(buttonsKeys[(int)EnumsAbilities.SlotsInventory.piernaIzquierda])) EquiparItem((int)EnumsAbilities.SlotsInventory.piernaIzquierda);
                break;
            case EnumsAbilities.PosicionesEquipo.torso:
                if (Input.GetButton(buttonsKeys[(int)EnumsAbilities.SlotsInventory.torso])) {
                    EquiparItem((int)EnumsAbilities.SlotsInventory.torso);
                }
                break;
            case EnumsAbilities.PosicionesEquipo.cabeza:
                if (Input.GetButton(buttonsKeys[(int)EnumsAbilities.SlotsInventory.cabeza])) EquiparItem((int)EnumsAbilities.SlotsInventory.cabeza);
                break;
        } 
    }

    public void OcultarInventario() {inventory.SetActive(false);}

    public void MostrarInventario() {
        for (int i = 0; i < isEquipado.Length; i++) {
            if (isEquipado[i]) {
                GameObject child = slots[i].transform.GetChild(0).gameObject;
                child.gameObject.GetComponent<Image>().sprite = Resources.Load<Sprite>(dropProperties[i].GetSprite());
                child.SetActive(true);
            }
        }
        inventory.SetActive(true);
    }

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
        switch (item.gameObject.GetComponent<Item>().propiedades.GetPosicion()) {
            case EnumsAbilities.PosicionesEquipo.brazos:
                CambiarColorPanel(slots[(int)EnumsAbilities.SlotsInventory.brazoIzquierdo]);
                CambiarColorPanel(slots[(int)EnumsAbilities.SlotsInventory.brazoDerecho]);
                break;
            case EnumsAbilities.PosicionesEquipo.piernas:
                CambiarColorPanel(slots[(int)EnumsAbilities.SlotsInventory.piernaIzquierda]);
                CambiarColorPanel(slots[(int)EnumsAbilities.SlotsInventory.piernaDerecha]);
                break;
            default:
                CambiarColorPanel(slots[(int)item.gameObject.GetComponent<Item>().propiedades.GetPosicion()]);
                break;
        }
    }


    private void CambiarColorPanel(GameObject panel) {
        CanvasRenderer renderer = panel.GetComponent<CanvasRenderer>();
        renderer.SetColor(Color.green);
    }

}
