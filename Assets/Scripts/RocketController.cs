using UnityEngine;
public class RocketController : PlayerForm 
{

    public PlayerMovement playerMovement;


    public float Maxthrust = 15f;
    public float thrust = 5;
    public float speed = 10f; 

    private float targetAngle = 0f;
    private float time = 0f;

    private bool rotationDown;
    private bool rotationUp;
    private int platformLayer;



    public Sprite rocketSprite;

    Vector2 thrustVector;

    private void Start()
    {
        platformLayer = LayerMask.NameToLayer("Platforms");

    }
    public override void UpdateForm()
    { 
        rb.linearVelocityX = speed;

        if ((Input.GetKey(KeyCode.Space) || Input.GetMouseButton(0)) && PauseMenuCaller.gamePaused == false)
        {
            thrustVector = new Vector2(0, Mathf.MoveTowards(rb.linearVelocityY, Maxthrust ,thrust * Time.deltaTime));
            rb.linearVelocityY = thrustVector.y; 
            rotationUp = true; 

            targetAngle = 30f;

            /*
            if (rb.linearVelocityY > Maxthrust)   // nastaveni maximalni rychlosti stoupani
            {
                rb.linearVelocityY = Maxthrust;
            } 

            if (rb.linearVelocityY < -Maxthrust)  // nastaveni maximalni rychlosti padani
            {
                rb.linearVelocityY = -Maxthrust;
            } 
            */

            if (time >= 0f && rotationDown)    
            {
                time = 0f;
            }

            if (time <= 1)
            {
                time = Time.deltaTime;
            }

            rotationDown = false;


        }
        else
        {
            thrustVector = new Vector2(0, Mathf.MoveTowards(rb.linearVelocityY, -Maxthrust, thrust * Time.deltaTime));
            rb.linearVelocityY = thrustVector.y;

            rotationDown = true;

            targetAngle = -30f;

            if (time >= 0f && rotationUp)   // Pøehoupnutí rotace 
            {
                time = 0f;
            }

            if (time <= 1)
            {
                time = Time.deltaTime; 
            }

            rotationUp = false;
        }


        Quaternion targetRotation = Quaternion.Euler(0f, 0f, targetAngle);

        playerTransform.rotation = Quaternion.Lerp(playerTransform.rotation, targetRotation,  time * 2.5f);


    }


    public override void OnEnter()  
    {

        playerTransform.rotation = Quaternion.Euler(0, 0, 0);
        SpriteRenderer playerSprite = GetComponentInParent<SpriteRenderer>();
        playerMovement.isGrounded = false;
        if (playerSprite != null)
        {
            playerSprite.sprite = rocketSprite;
        }
        rb.gravityScale = 0;

    }

    public override void OnExit() 
    {


    }

    public override void OnCollisionEnter2D(Collision2D collision)
    { 
        if (collision.collider.gameObject.layer == platformLayer)
        {
            Vector2 normal = collision.GetContact(0).normal;

            if (normal.y < 0.5f)
            {
                PlayerDeath.Die();

            }
        }
    }
}
