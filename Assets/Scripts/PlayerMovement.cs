using UnityEngine.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class PlayerMovement : PlayerForm
{
    //public LayerMask groundLayer;
    private int groundLayer;
    private int platformLayer;


    public Transform groundCheck;      // malý objekt pod hráèem
    public float groundCheckRadius = 0.15f;

    public float speed = 5f;  

    public float jumpForce = 15f;
    public bool isGrounded = false;
    public bool newGround = false;

    public float rotationSpeed = 360f;
    private float targetAngle = 0f;
    private bool isRotating = false;
    private bool isJumping = false;
    private float jumpHoldTimer = 0f;
    public float maxJumpHoldTime = 0.2f; // Maximální doba podržení pro vyšší skok

    void Start()    // Funkce od Unity která se volá pouze jednou pøi spuštìní programu
    {
        //rb = GetComponent<Rigidbody2D>();    // Získám konkrétní Rigidbody2D které je v Unity pøipojeno k hráèovi 

        groundLayer = LayerMask.NameToLayer("Ground");
        platformLayer = LayerMask.NameToLayer("Platforms");
        StartCoroutine(HideCursor());

    }

    IEnumerator HideCursor()
    {

        yield return new WaitForSeconds(3f);

        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;

    }


    public override void UpdateForm()   
    {
         

        rb.linearVelocityX = speed;    // Nastavení hráèovo rychlosti ve smìru X na speed

        

        if ((Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0)) && isGrounded && PauseMenuCaller.gamePaused == false)   // Pokud hráè stiskne mezerník nebo levé tlaèítko myši
        {
            Jump();
            StartRotation();
            isJumping = true;
            jumpHoldTimer = 0f;
        }

        if (isJumping)
        {
            if (Input.GetKey(KeyCode.Space) || Input.GetMouseButton(0))
            {
                jumpHoldTimer += Time.deltaTime;
                if (jumpHoldTimer >= maxJumpHoldTime)
                {
                    // Dosáhli jsme maximální doby podržení, už jen pøestaneme sledovat (plná výška skoku)
                    isJumping = false;
                }
            }
            else
            {
                // Tlaèítko bylo puštìno pøed limitem -> zkrátíme skok (snížíme vertikální rychlost)
                if (rb.linearVelocityY > 0)
                {
                    rb.linearVelocityY *= 0.5f;
                }
                isJumping = false;
            }
        }

        if (isRotating)
        {
            playerTransform.Rotate(0f, 0f, -rotationSpeed * Time.deltaTime);  // Díky transform odkazuji na pozici, rotaci a velikost hráèe a pomocí funkce Rotate øíkám:
                                                                        // rotuj na ose Z o -rotationSpeed za sekundu
                                                                        // znaménko - mi urèuje smìr rotace doprava

            // Díky Mathf.DeltaAngle zjistí rozdíl mezi dvìma úhly:
            // stávající úhel(transform.eulerAngles.z -> naklonìní hráèe na ose z) a cílovej targetAngle
            // pokud je rozdíl v absolutní hodnotì menší než 2, úhel se automaticky nastaví na ten požadovaný
            if (Mathf.Abs(Mathf.DeltaAngle(playerTransform.eulerAngles.z, targetAngle)) < 5f)   
            {
                playerTransform.rotation = Quaternion.Euler(0, 0, targetAngle);   // Pomocí Quaternion.Euler vytvoøíme rotaci z cílového úhlu (Unity ukládá rotaci jako quaternion,
                                                                            // díky funkci Euler mohu rotaci napsat ve tøech souøadních x,y,z)
                isRotating = false;
                
            }
        }


    }

    

    public override void OnEnter()
    {
        Debug.Log("Cube form activated");

    }

    public override void OnExit()
    {
        Debug.Log("Cube form deactivated");
    }

    void Jump()
    {
        rb.linearVelocityY = jumpForce * 1.3f;   // Zaèneme skokem s maximální možnou silou
        isGrounded = false;
    }

    void StartRotation()
    {
        targetAngle -= 180f; // Znaménko mínus uèuje smìr rotace doprava
        isRotating = true;
    }

    
    public override void OnCollisionEnter2D(Collision2D collision)    // Funkce od Unity, která se zaène volat pokud se tìleso zaène dotýkat jiného kolidujícího tìlesa
    {

        if (collision.collider.gameObject.layer == groundLayer || collision.collider.gameObject.layer == platformLayer)   
        {
            isGrounded = true;
            newGround = true;
            Vector2 normal = collision.GetContact(0).normal;

            if (normal.y < 0.5)
            {
                //SceneManager.LoadScene(SceneManager.GetActiveScene().name); // !!! 
                PlayerDeath.Die();
            }
            else if (normal.y < 0.98) // Pokud narazí na roh
            {
                // Posuneme hráèe trochu nahoru, aby se nezasekl
                playerTransform.position += new Vector3(0, 0.1f, 0);
            }

        }  

    }

    public override void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.collider.gameObject.layer == groundLayer)
        {
            isGrounded = false;
        }
    }

}
