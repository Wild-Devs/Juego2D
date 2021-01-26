using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemProperties {
    private EnumsAbilities.PosicionesEquipo posicionEquipo;
    private string sprite;
    private int indexEquipo;
    private string[][] matrizEquipo = {EnumsAbilities.equipablesCabeza, EnumsAbilities.equipablesTorso, EnumsAbilities.equipablesBrazos, EnumsAbilities .equipablesPiernas};

    public string GetSprite() {return sprite;}

    public EnumsAbilities.PosicionesEquipo GetPosicion() {return posicionEquipo; }

    public int GetIndexEquipo() {return indexEquipo; }

    public void SetSprite(string sprite) {this.sprite = sprite;}

    public void SetPosicion(EnumsAbilities.PosicionesEquipo posicionEquipo) {this.posicionEquipo = posicionEquipo;}

    public void SetIndexEquipo(int indexEquipo) {this.indexEquipo = indexEquipo; }

    public ItemProperties(EnumsAbilities.Equipables equipables) {
        bool flag = false;
        for (int i = 0; i < matrizEquipo.Length && !flag; i++) {
            for (int j = 0; j < matrizEquipo[i].Length && !flag; j++) {
                if (matrizEquipo[i][j] == equipables.ToString()) {
                    indexEquipo = j;
                    AsignarposicionEquipo(i);
                    sprite = EnumsAbilities.nombresSpritesItems[(int)equipables];
                    flag = !flag;
                }
            }
        }
    }

    private void AsignarposicionEquipo(int posicion) {
        switch (posicion) {
            case 0:
                posicionEquipo = EnumsAbilities.PosicionesEquipo.cabeza;
                break;
            case 1:
                posicionEquipo = EnumsAbilities.PosicionesEquipo.torso;
                break;
            case 2:
                posicionEquipo = EnumsAbilities.PosicionesEquipo.brazos;
                break;
            case 3:
                posicionEquipo = EnumsAbilities.PosicionesEquipo.piernas;
                break;
        }
    }

}
