using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuScript : MonoBehaviour
{
    public Canvas pauseMenu;
    public AudioSource soundTrack;

    public void PlayGame()
    {
        SceneManager.LoadScene(1); 
        
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void ResumeGame()
    {   
        pauseMenu.enabled = false;
        Time.timeScale = 1;
        PauseMenuCaller.gamePaused = false;
        soundTrack.Play();
        StartCoroutine(HideCursor());

    }

    IEnumerator HideCursor()
    {

        yield return new WaitForSeconds(1f);

        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;

    }
}
