/*
using UnityEngine;

public class RotaceTest : MonoBehaviour
{
    float time;
    float targetAngle;

    bool leftmouse;
    bool nothing;


    // Update is called once per frame
    void Update()
    {

        if (Input.GetMouseButton(0))
        {
            leftmouse = true;
            Debug.Log("leva");
            targetAngle = 30;
            time += Time.deltaTime;

            if (nothing)
            {
                time = 0;
            }

            nothing = false;

        }
        else 
        {
            nothing = true;

            targetAngle = -30;
            time += Time.deltaTime;

            if (leftmouse)
            {
                time = 0;
            }

            leftmouse = false;


        }

        Debug.Log(time);

        Quaternion targetRotation = Quaternion.Euler(0, 0, targetAngle);
        transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, time);
    }
}  
*/

using UnityEngine;

public class RotaceTest : MonoBehaviour
{
    float lerpTime = 0f;
    float targetAngle = 0f;
    //float speed = 10f; // rychlost pøibližování

    private void Start()
    {
        transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(0, 0, 0), 0.5f);
        Debug.Log("Zacatek");
    }
    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            targetAngle = 30f;
        }
        else
        {
            targetAngle = -30f;
        }

        // hladké pøibližování
        Quaternion targetRotation = Quaternion.Euler(0, 0, targetAngle);
        transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(0, 0, 30), Time.deltaTime);

        lerpTime += Time.deltaTime;
        Debug.Log(lerpTime);
        if (lerpTime >= 1)
        {
            Debug.Log("Je to tam");

        }
    }


}
