using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    
    //TIMER//
    public Text timerMin;
    public Text timerSec;
    public Text timerMill;
    public float timeLeft;
    private int min;
    private int sec;
    private int mill;

    void Start()
    {
        if(SceneManager.GetActiveScene().buildIndex == 0){
        }else{
            Time.timeScale = 1f;
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;
        }
    }

    void Update()
    {

        startTimer();

        if(Input.GetKey(KeyCode.Escape)){

            Application.Quit();

        }
        
    }


    void startTimer(){

            timeLeft -= Time.deltaTime;

            min = (int) (timeLeft / 60) % 60;
            sec = (int) (timeLeft % 60);
            mill = (int) (timeLeft * 1000) % 1000;

            string timerStringMin = string.Format("{0:00}:",min);

            timerMin.text = timerStringMin;

            string timerStringSec = string.Format("{0:00}.",sec);

            timerSec.text = timerStringSec;

            string timerStringMill = string.Format("{0:000}",mill);

            timerMill.text = timerStringMill;

            if(timeLeft <= 0){

                SceneManager.LoadScene(SceneManager.GetActiveScene().name);

            }
    }

}
