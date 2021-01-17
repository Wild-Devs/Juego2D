using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    public PlayerStats ps;
    private GameObject player;
    public  Animator endPanel;

    void Start()
    {
        
        if(SceneManager.GetActiveScene().buildIndex == 1){

            Time.timeScale = 1f;
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;

            player = GameObject.Find("Player");

            ps = player.GetComponent<PlayerStats>();

            ps.setAttack(15);
            ps.setHealth(200);
            ps.setMaxHealth(200);
            ps.setDeffense(3);
            ps.setSpeed(5);

        }else if (SceneManager.GetActiveScene().buildIndex != 0 && SceneManager.GetActiveScene().buildIndex != 1){
            Time.timeScale = 1f;
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;

            player = GameObject.Find("Player");

            ps = player.GetComponent<PlayerStats>();

            ps.setAttack(PlayerPrefs.GetFloat("Attack"));
            ps.setHealth(PlayerPrefs.GetFloat("PlayerHealth"));
            ps.setMaxHealth(PlayerPrefs.GetFloat("MaxHealth"));
            ps.setDeffense(PlayerPrefs.GetInt("Deffense"));
            ps.setSpeed(PlayerPrefs.GetFloat("Speed"));
        }
    }

    void Update()
    {

        if(Input.GetKey(KeyCode.Escape)){

            Quit();

        }
        
    }

    public void ChangeScene(){

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);

    }

    public void ReloadScene() {

        SceneManager.LoadScene(SceneManager.GetActiveScene().name);

    }

    public void Ending(){

        endPanel.Play("end");

        player.SetActive(false);

    }

    public void Quit(){

        Application.Quit();

    }

}
