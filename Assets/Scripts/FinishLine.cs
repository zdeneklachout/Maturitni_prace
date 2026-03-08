using UnityEngine;
using UnityEngine.SceneManagement;
public class FinishLine : MonoBehaviour
{
    public static bool vyhra;

    private void Update()
    {
        Debug.Log(Time.time);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {   
            SceneManager.LoadScene(1);

            AttemptCounter.attemptCounter = 0;
            vyhra = true;
        }
    }
}
