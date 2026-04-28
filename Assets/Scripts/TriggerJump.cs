using UnityEngine;

public class TriggerJump : MonoBehaviour
{
    public PlayerMovement playerMovement;
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            playerMovement.isGrounded = true;
        } 
        
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            playerMovement.isGrounded = false;
        }
    }
}
