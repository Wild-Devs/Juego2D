using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnumsAbilities : MonoBehaviour
{
    public enum SlotsInventory
    {
        cabeza,
        torso,
        brazoIzquierdo,
        brazoDerecho,
        piernaIzquierda,
        piernaDerecha
    }

    public enum PosicionesEquipo
    {
        cabeza,
        torso,
        brazos,
        piernas
    }

    public enum Equipables
    {
        Default,
        Tronco,
        ArmaduraHierro,
        Lanza
    }

    public static string[] equipablesCabeza = { "Ejemplo" };
    public static string[] equipablesTorso = { "Default", "Tronco", "ArmaduraHierro" };
    public static string[] equipablesBrazos = { "Lanza" };
    public static string[] equipablesPiernas = { "Ejemplo" };
    public static string[] nombresSpritesItems = { "Default", "TroncoSpriteItem", "ArmaduraHierroSpriteItem", "LanzaSpriteItem" };
}
