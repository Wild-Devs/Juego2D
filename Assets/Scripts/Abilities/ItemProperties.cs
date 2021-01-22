using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemProperties {
    private Sprite sprite;
    private EnumsAbilities.SlotsInventory posicionEquipo;
    private string nombreEquipo;
    private string[][] matrizEquipo = {EnumsAbilities.equipablesCabeza, EnumsAbilities.equipablesTorso, EnumsAbilities.equipablesBrazos, EnumsAbilities .equipablesPiernas};

    public Sprite GetSprite() {return sprite;}

    public EnumsAbilities.SlotsInventory GetPosicion() {return posicionEquipo; }

    public string GetNombreEquipo() {return nombreEquipo;}

    public ItemProperties(EnumsAbilities.Equipables equipables, bool isDerecho) {
        bool flag = false;
        for (int i = 0; i < matrizEquipo.Length && !flag; i++) {
            for (int j = 0; j < matrizEquipo[i].Length && !flag; j++) {
                if (matrizEquipo[i][j] == equipables.ToString()) {
                    nombreEquipo = matrizEquipo[i][j];
                    AsignarposicionEquipo(i, isDerecho);
                    //Asignar sprite
                    flag = !flag;
                }
            }
        }
    }

    public void AsignarposicionEquipo(int posicion, bool isDerecho) {
        switch (posicion) {
            case 0:
                posicionEquipo = EnumsAbilities.SlotsInventory.cabeza;
                break;
            case 1:
                posicionEquipo = EnumsAbilities.SlotsInventory.torso;
                break;
            case 2:
                if (isDerecho) posicionEquipo = EnumsAbilities.SlotsInventory.brazoDerecho;
                else posicionEquipo = EnumsAbilities.SlotsInventory.brazoIzquierdo;
                break;
            case 3:
                if (isDerecho) posicionEquipo = EnumsAbilities.SlotsInventory.piernaDerecha;
                else posicionEquipo = EnumsAbilities.SlotsInventory.piernaIzquierda;
                break;
        }
    }

}
