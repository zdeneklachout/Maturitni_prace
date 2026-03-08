using System.Runtime.CompilerServices;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{

    public float radius = 10f;
    public float speed = 0f;
    public float elevation = 4.2f;

    private Vector2 player;
    private Vector3 platformStartPos;
    private void Start()
    {
        platformStartPos = transform.position;
    }
    private void Update()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform.position;

        float distance = Mathf.Abs(transform.position.x - player.x);

        if (distance < radius)
        {
            transform.position = Vector2.MoveTowards(transform.position, platformStartPos + Vector3.up * elevation, speed * Time.deltaTime);
        }
    }
}
