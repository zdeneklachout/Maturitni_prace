using UnityEngine;

public class MovingObjectStartPos : MonoBehaviour
{
    public Vector3 startPos;
    private void Awake()
    {
        startPos = transform.position;
    }
}
