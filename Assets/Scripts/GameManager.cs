using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    public PlayerStats ps;
    private GameObject player;
    public  Animator endPanel;

    private bool gamePaused;
    public GameObject pauseMenu;
    public bool canPause;

    void Start()
    {
        gamePaused = false;
        
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
        
        if(canPause){
            if (Input.GetKeyDown(KeyCode.Escape)){
                if (!gamePaused)
                {
                    Pause();
                }
                else{
                    Resume();
                }
            }
        }
        
    }

    public void ChangeScene(){

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);

    }

    public void ReloadScene() {

        SceneManager.LoadScene(SceneManager.GetActiveScene().name);

    }

    public void ResetGame(){

        SceneManager.LoadScene(0);

    }

    public void Ending(){

        endPanel.Play("end");

        player.SetActive(false);

    }

    public void Quit(){

        Application.Quit();

    }

    public void Resume(){

        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        player.GetComponent<Move2D>().enabled = true;
        player.GetComponent<PlayerManager>().enabled = true;

        pauseMenu.SetActive(false);
        gamePaused = false;
        Time.timeScale = 1f;

    }

    void Pause(){

        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;

        Time.timeScale = 0f;
        player.GetComponent<Move2D>().enabled = false;
        player.GetComponent<PlayerManager>().enabled = false;
        gamePaused = true;
        pauseMenu.SetActive(true);

    }

}
