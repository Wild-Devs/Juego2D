using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbilityController : MonoBehaviour {
    private GameObject player;
    private List<GameObject> posicionesEquipo = new List<GameObject>();

    void Start() {
        player = GameObject.Find("Player");
        GameObject equipo = player.transform.GetChild(3).gameObject;
        for (int i = 0; i < equipo.transform.childCount; i++) {
            posicionesEquipo.Add(equipo.transform.GetChild(i).gameObject);
        }
    }
    
    public void HabilitarYDeshabilitarEquipo(int posicion, int indexHabilidad, bool isHabilitar) {
        posicionesEquipo[posicion].gameObject.transform.GetChild(indexHabilidad).gameObject.SetActive(isHabilitar);
    }
}
