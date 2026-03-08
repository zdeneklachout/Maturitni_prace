using UnityEngine;
using UnityEngine.UI;

public class AttemptCounter : MonoBehaviour
{

    public static int attemptCounter;
    public Text attemptText;
    public float visiilityDuration = 1.5f;

    private void Start()
    {
        ShowAttempts();
    }

    void ShowAttempts()
    {
        if (FinishLine.vyhra == true)
        {
            attemptText.text = "Vyhrál jsi!";
            FinishLine.vyhra = false;
        } 
        else
        {
            attemptText.gameObject.SetActive(true);
            attemptText.text = "Attempts: " + attemptCounter;
        }

        StartCoroutine(HideAttemptAfterDelay());

    }

    System.Collections.IEnumerator HideAttemptAfterDelay()
    {
        yield return new WaitForSeconds(visiilityDuration);
        attemptText.gameObject.SetActive(false);
    }

    public static void AddAttempt()
    {
        attemptCounter++;
    }











}
