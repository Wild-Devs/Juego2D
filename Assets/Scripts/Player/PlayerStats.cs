using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{

    public float health;
    public float maxHealth;
    public float attack;
    public float speed;
    public int def;
    public GameObject cabeza, torso, brazoIzquierdo, brazoDerecho, piernaIzquierda, piernaDerecha;
    
    
    //HEALTH//
    public void setHealth(float health){

        this.health = health;

    }

    public float getHealth(){
        
        return health;

    }

    //MAX HEALTH//
    public void setMaxHealth(float maxHealth){

        this.maxHealth = maxHealth;

    }

    public float getMaxHealth(){

        return maxHealth;

    }

    //ATTACK//
    public void setAttack(float attack){

        this.attack = attack;

    }

    public float getAttack(){

        return attack;

    }

    //DEFFENSE//
    public void setDeffense(int def){

        this.def = def;

    }

    public int getDeffense(){

        return def;

    }

    //SPEED//
    public void setSpeed(float speed){

        this.speed = speed;

    }

    public float getSpeed(){

        return speed;

    }

    //EQUIPO CABEZA//
    public void setCabeza(GameObject equipable) {
        if (cabeza == null) {

        }
        cabeza = equipable;
    }

    public GameObject getCabeza() {return cabeza;}

    //EQUIPO TORSO//
    public void setTorso(GameObject equipable) {torso = equipable; }

    public GameObject getTorso() {
        if (torso == null) return null;
        else return torso;
    }

    //EQUIPO BRAZO DERECHO//
    public void setBrazoDerecho(GameObject equipable) {brazoDerecho = equipable; }

    public GameObject getBrazoDerecho() { return brazoDerecho; }

    //EQUIPO BRAZO IZQUIERDO//
    public void setBrazoIzquierdo(GameObject equipable) {brazoIzquierdo = equipable; }

    public GameObject getBrazoIzquierdo() { return brazoIzquierdo;}


    //EQUIPO PIERNA IZQUIERDA//
    public void setPiernaIzquierda(GameObject equipable) { piernaIzquierda = equipable; }

    public GameObject getPiernaIzquierda() { return piernaIzquierda; }

    //EQUIPO PIERNA DERECHA//
    public void setPiernaDerecha(GameObject equipable) { piernaDerecha = equipable; }

    public GameObject getPiernaDerecha() { return piernaDerecha; }


}
