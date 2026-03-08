using System.Runtime.CompilerServices;
using UnityEngine;

public class PlayerFormManager : MonoBehaviour
{
    private Rigidbody2D rb;
    private PolygonCollider2D polygonCollider2D;
    private Transform playerTransform;

    public PlayerForm cubeForm;    // Odkazy na script PlayerForm
    public PlayerForm rocketForm;
    public PlayerForm currentForm;

   
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        polygonCollider2D = GetComponent<PolygonCollider2D>();
        playerTransform = GetComponent<Transform>();

        cubeForm.Init(rb, polygonCollider2D, playerTransform);      // formy si pøebírají rigidbody hráèe atd....
        rocketForm.Init(rb, polygonCollider2D, playerTransform);


        SetForm(cubeForm);
    }
    
    void Update()
    {
      
        if (currentForm != null)
        {
            currentForm.UpdateForm();
        }
    }

    public void SetForm(PlayerForm newForm)
    {
        if (currentForm != null)
        {
            currentForm.OnExit();
        }

        currentForm = newForm;
        currentForm.OnEnter();
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        
        if (collision.CompareTag("RocketPortal"))
        {  
            SetForm(rocketForm);
        }
        else if (collision.CompareTag("CubePortal"))
        {
            SetForm(cubeForm);

        }
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (currentForm != null)
        {
            currentForm.OnCollisionEnter2D(collision);
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (currentForm != null)
        {
            currentForm.OnCollisionExit2D(collision);
        }
    }
}
