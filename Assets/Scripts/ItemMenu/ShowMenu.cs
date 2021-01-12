using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowMenu : MonoBehaviour
{

    public GameObject itemMenu;
    private void Start()
    {
        Debug.Log("El objeto vive");
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Ha entrado");
        if (other.gameObject.tag == "Player")
        {
            itemMenu.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        Debug.Log("Ha salido");
        if (other.gameObject.tag == "Player")
        {
            itemMenu.SetActive(false);
        }
    }
    
}
