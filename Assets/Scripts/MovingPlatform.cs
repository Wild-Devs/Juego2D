using UnityEngine;

public class MovingPlatform : MonoBehaviour
{   

    private Vector3 startPos;
    public bool backAndForth;
    public float travelDistance;
    public bool reverse;
    public bool x;
    public bool y;
    public float velocity;
    public bool isEnemy;
    private float scale;

    void Start()
    {
        startPos = transform.position;
        scale = transform.localScale.x;
    }

    
    void Update()
    {

        if(backAndForth){
            if(reverse){
                if(x){
                    transform.position = new Vector3(startPos.x - Mathf.PingPong(Time.time, travelDistance) * velocity, transform.position.y, transform.position.z);
                }
                if(y){
                    transform.position = new Vector3(transform.position.x, startPos.y - Mathf.PingPong(Time.time, travelDistance) * velocity, transform.position.z);
                }
            }else{
                if(x){
                    transform.position = new Vector3(startPos.x + Mathf.PingPong(Time.time, travelDistance) * velocity, transform.position.y, transform.position.z);
                }
                if(y){
                    transform.position = new Vector3(transform.position.x, startPos.y + Mathf.PingPong(Time.time, travelDistance) * velocity, transform.position.z);
                }
            } 
        }

        if(gameObject.name == "BasicEnemy"){

            if(reverse){

                if(Mathf.PingPong(Time.time, travelDistance) <= 0.1f){
                
                    transform.localScale = new Vector3(-scale, transform.localScale.y, transform.localScale.z);
                }

                if(Mathf.PingPong(Time.time, travelDistance) >= travelDistance - 0.1f){
                
                    transform.localScale = new Vector3(scale, transform.localScale.y, transform.localScale.z);

                }

            }else{

                if(Mathf.PingPong(Time.time, travelDistance) <= 0.1f){
                
                    transform.localScale = new Vector3(scale, transform.localScale.y, transform.localScale.z);
                }

                if(Mathf.PingPong(Time.time, travelDistance) >= travelDistance - 0.1f){
                
                    transform.localScale = new Vector3(-scale, transform.localScale.y, transform.localScale.z);

                }

            }

            
        }

    }
}
