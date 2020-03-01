using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public GameManager gameManager;

    public float speed = 15f;
    public GameObject playerShadow;
    public TimeManager timeManager;
    public PointSpawner pointSpawner;

    private Rigidbody2D player;
    private Queue<Vector3> playerTrail = new Queue<Vector3>();
    private float playerShadowOffset = 2f;


    // Start is called before the first frame update
    void Start()
    {
        player = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    { 

        if (Input.GetKeyDown("n"))
        {
            BackInTime();
        }
        else if (Input.GetKey("j"))
        {
            timeManager.SlowTime();
            Movement(Time.timeScale);
        }
        else
        {
            timeManager.DefaultTime();
            Movement(Time.timeScale);
        }

        playerTrail.Enqueue(transform.position);

        if(Time.time > playerShadowOffset)
        {
            PlayerShadow();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log(collision.gameObject.tag);
        if (collision.gameObject.tag == "ball")
        {
            gameManager.ActivateResetGame();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "point")
        {
            pointSpawner.Spawn();
            gameManager.IncrementPoints();
        }
    }

    private void Movement(float timeOffset)
    {
        
        Vector2 movementScale = new Vector2(Input.GetAxis("Horizontal") * speed * Time.fixedDeltaTime / timeOffset, Input.GetAxis("Vertical") * speed * Time.fixedDeltaTime / timeOffset);

        Vector2 newPosition = player.position + Vector2.one * movementScale;

        newPosition.x = Mathf.Clamp(newPosition.x, -11.5f, 11.5f);
        newPosition.y = Mathf.Clamp(newPosition.y, -11.5f, 11.5f);

        player.MovePosition(newPosition);
    }

    private void PlayerShadow()
    {
        Vector3 playerPastPosition = playerTrail.Dequeue();

        playerShadow.transform.position = playerPastPosition;
    }

    private void BackInTime()
    {
        transform.position = playerShadow.transform.position;
    }
}
