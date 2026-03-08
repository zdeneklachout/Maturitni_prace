using UnityEngine;

public class SpawnOfObstacle : MonoBehaviour
{
    public float radius = 10f;
    public float speed = 0f;
    public float elevation = 4.2f;
    public MovingObjectStartPos movingObjectStartPos;
    void Update()
    {
        Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, radius);

        for (int i = 0; i < colliders.Length; i++)
        {   
            if (colliders[i].CompareTag("MovingObject"))
            {
                Vector3 positionOfObject = colliders[i].transform.position;
                Debug.Log(movingObjectStartPos.startPos);

                colliders[i].transform.position = Vector2.MoveTowards(positionOfObject, movingObjectStartPos.startPos + new Vector3(0, elevation, 0), speed * Time.deltaTime); 
                                                                                                                                                                                       

                    
            }
        }
    }

    
}
