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
    public int maxDef;


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

    public void setMaxDeffense(int maxDef)
    {

        this.maxDef = maxDef;

    }

    public int getMaxDeffense()
    {

        return maxDef;

    }

    //SPEED//
    public void setSpeed(float speed){

        this.speed = speed;

    }

    public float getSpeed(){

        return speed;

    }

}
