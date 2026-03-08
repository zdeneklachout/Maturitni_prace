using UnityEngine;

public class PositionOfGroundCheck : MonoBehaviour
{

    float positionOnY = 0;

    private void Update()
    {
        if (GetComponentInParent<Transform>().rotation != Quaternion.Euler(0, 0, 0))
        {
            positionOnY = 0.4f;
        } 
        else
        {
            positionOnY = -0.4f;    
        }

        transform.localPosition = new Vector3(transform.localPosition.x, positionOnY, transform.localPosition.z);


    }

}
