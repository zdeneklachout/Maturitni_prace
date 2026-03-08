using Unity.VisualScripting;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public Transform player;   // Odkaz na komponentu transform jiného objektu(hráèe), díky ní mám pøístup k pozici, rotaci a velikosti hráèe 
    public PlayerMovement playerMovement;
    public float offsetX = 2f;
    public float offsetY = 4f;


    private float cameraY;
    private float lastPlayerY;

    private Quaternion initialRotation;

    private void Start()
    {
        initialRotation = transform.rotation;
        lastPlayerY = player.position.y;
    }
    void LateUpdate()  // Funkce od Unity stejná jako Update akorát se volá po všech Update funkcích, funkce Update se volá každý snímek od zaèátku programu
    {
       
        if (player.position.y > lastPlayerY + 5 && playerMovement.isGrounded == true && TriggerJump.newJump == false)
        {
            cameraY = player.position.y + offsetY;
            lastPlayerY = player.position.y;
        }
        else
        {
            cameraY = lastPlayerY + offsetY;    
        }

        if (player.position.y < lastPlayerY - 5  && playerMovement.isGrounded == true && TriggerJump.newJump == false)
        {
            cameraY = player.position.y + offsetY;
            lastPlayerY = player.position.y;
        }
        else
        {
            cameraY = lastPlayerY + offsetY;
        }

        transform.position = new Vector3(player.position.x + offsetX, cameraY, transform.position.z); 
                                                                                                               
    }
}
