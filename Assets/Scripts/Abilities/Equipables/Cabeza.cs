using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cabeza : MonoBehaviour
{
    public int armor;
    private PlayerStats stats;
    private ItemManager itemManager;

    void Start()
    {
        stats = GameObject.Find("Player").gameObject.GetComponent<PlayerStats>();
        itemManager = GameObject.Find("GameManager").gameObject.GetComponent<ItemManager>();
        stats.setDeffense(armor);
        stats.setMaxDeffense(armor);
    }

    void Update()
    {
        if (stats.getDeffense() <= 0)
        {
            this.gameObject.SetActive(false);
            itemManager.eliminarPosicion(0);
        }
    }
}