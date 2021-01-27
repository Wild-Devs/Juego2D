using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{

    public EnumsAbilities.Equipables equipable;
    public ItemProperties propiedades = new ItemProperties(EnumsAbilities.Equipables.Tronco);

    void Start()
    {
        propiedades = new ItemProperties(EnumsAbilities.Equipables.ArmaduraHierro);
        AsignarSprite();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            collision.gameObject.GetComponent<PlayerManager>().itemManager.PayerEnter(this.gameObject);

        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            collision.gameObject.GetComponent<PlayerManager>().itemManager.PayerExit();
        }
    }

    private void AsignarSprite()
    {
        this.gameObject.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>(propiedades.GetSprite());
    }
}