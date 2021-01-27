using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Torso : MonoBehaviour
{
    public float hp;
    private PlayerStats stats;

    void Start()
    {
        stats = GameObject.Find("Player").gameObject.GetComponent<PlayerStats>();
        stats.setMaxHealth(hp);
        Debug.Log(stats.getMaxHealth());
    }
}
