using UnityEngine;

public class PauseMenuCaller : MonoBehaviour
{
    public Canvas pauseMenu;
    public PlayerMovement playerMovement;
    public AudioSource soundTrack;
    // Update is called once per frame 

    public static bool gamePaused = false;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
            soundTrack.Pause();

            pauseMenu.enabled = true;
            gamePaused = true;
            Time.timeScale = 0; 

        }
    }
}
    