using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenuScript : MonoBehaviour
{
    public static bool isPaused = false;

    public GameObject pauseMenuUi;
    public GameObject controls;
    float timecounter;
    void Start(){
        controls.SetActive(true);
    }
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape)){
            if(isPaused){
                Resume();
            }
            else{
                Pause();
            }
        }
        timecounter+=Time.deltaTime;
        if(timecounter>5f){
            controls.SetActive(false);
        }
    }
    public void Resume(){
        pauseMenuUi.SetActive(false);
        Time.timeScale=1f;
        isPaused = false;
        Cursor.visible = false;
    }
    void Pause(){
        pauseMenuUi.SetActive(true);
        Time.timeScale=0f;
        isPaused = true;
        Cursor.visible = true;
    }
    public void BackToMenu(){
        SceneManager.LoadScene("mainMenu");
        Time.timeScale=1f;

    }
    public void QuitGameFromPause(){
        Application.Quit();

    }
    public void PlayAgaian(){
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Time.timeScale = 1f;
        Cursor.visible = false;
    }
}
