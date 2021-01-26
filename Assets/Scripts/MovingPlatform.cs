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

    void Start()
    {
        startPos = transform.position;
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

    }
}
