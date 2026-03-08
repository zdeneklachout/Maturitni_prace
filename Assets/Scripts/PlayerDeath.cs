using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerDeath : MonoBehaviour
{

    private void OnCollisionEnter2D(Collision2D collision)   // Funkce od Unity, která se zaène volat pokud se tìleso zaène dotýkat jiného kolidujícího tìlesa
    {
        if (collision.collider.CompareTag("Obstacle")) // Pokud hráè bude kolidovat s jiným objektem ze hry který má tag "Obstacle"
        {
            Die();
        }
    } 

    public static void Die()
    {
        AttemptCounter.AddAttempt();
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);   // Naète scénu od znova 
    }
}
