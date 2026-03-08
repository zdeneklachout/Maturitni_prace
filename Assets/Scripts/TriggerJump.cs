using UnityEngine;

public class TriggerJump : MonoBehaviour
{
    public PlayerMovement playerMovement;
    public static bool newJump = false;
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            playerMovement.isGrounded = true;
            newJump = true;
        } 
        
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            playerMovement.isGrounded = false;
            newJump = false;
        }
    }
}
