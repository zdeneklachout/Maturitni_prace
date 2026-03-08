using UnityEngine;

public abstract class PlayerForm : MonoBehaviour   // Abstraktní tøída ze které budou dìtit skripty pro rùzné formy hráèe
{

    protected Rigidbody2D rb;
    protected PolygonCollider2D polygonCollider2D;
    protected Transform playerTransform;

   // public virtual void FixedUpdateForm() { }

    public virtual void Init(Rigidbody2D rigidbody, PolygonCollider2D polygoncollider2D, Transform playertransform)   // Tato metoda ma vychozi chovani ale muzu ji prepsat
    {
        rb = rigidbody;
        polygonCollider2D = polygoncollider2D;
        playerTransform = playertransform;
    }

    public abstract void UpdateForm();     // Abstraktní metoda, nemá tìlo
    public abstract void OnEnter();
    public abstract void OnExit();

    public virtual void OnCollisionEnter2D(Collision2D collision)
    { }

    public virtual void OnCollisionExit2D(Collision2D collision) 
    { }



   
}
