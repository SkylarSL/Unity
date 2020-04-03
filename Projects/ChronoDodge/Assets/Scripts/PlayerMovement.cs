using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    //managers
    public GameManager gameManager;
    public TimeManager timeManager;
    public ResourceManager resourceManager;
   
    //attributes
    public float speed = 15f;
    public float playerShadowOffset = 2f;
    public float steadyManaIncrease = 0.05f;
    public float instantManaIncrease = 10f;
    public float steadyManaDecrease = 0.3f;
    public float instantManaDecrease = 30f;

    //spawners
    public ManaPotionSpawner manaPotionSpawner;

    public GameObject playerShadow;
    private Rigidbody2D player;
    private Queue<Vector3> playerTrail;
   
    // Start is called before the first frame update
    void Start()
    {
        player = GetComponent<Rigidbody2D>();
        resourceManager.SetMaxMana(100f);
        resourceManager.SetMana(100f);
        playerTrail = new Queue<Vector3>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float currentMana = resourceManager.GetCurrentMana();
        float currentSpark = resourceManager.GetCurrentSpark();
        if (Input.GetKeyDown("n") && currentMana > 30)
        {
            BackInTime();
            resourceManager.DecreaseMana(instantManaDecrease);
        }
        else if (Input.GetKey("j") && currentMana > 1)
        {
            timeManager.SlowTime();
            Movement(Time.timeScale);
            resourceManager.DecreaseMana(steadyManaDecrease);
        }
        else
        {
            timeManager.DefaultTime();
            Movement(Time.timeScale);
            resourceManager.IncreaseMana(steadyManaIncrease);
        }

        playerTrail.Enqueue(transform.position);

        if(Time.timeSinceLevelLoad > playerShadowOffset)
        {
            PlayerShadow();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "ball")
        {
            gameManager.ActivateResetGame();
            GetComponent<PlayerMovement>().enabled = false;
        }
        if (collision.gameObject.tag == "manaPotion")
        {
            Destroy(collision.gameObject);
            manaPotionSpawner.Spawn();
            resourceManager.IncreaseMana(instantManaIncrease);
        }
        if(collision.gameObject.tag == "spark")
        {
            Destroy(collision.gameObject);
            resourceManager.IncreaseSpark(1);
        }
    }

    private void Movement(float timeOffset)
    {
        //Debug.Log(Input.GetAxis("Horizontal"));
        if(Input.GetAxis("Horizontal") > 0)
        {
            player.GetComponent<SpriteRenderer>().flipX = true;
        }
        else
        {
            player.GetComponent<SpriteRenderer>().flipX = false;
        }

        Vector2 movementScale = new Vector2(Input.GetAxis("Horizontal") * speed * Time.fixedDeltaTime, Input.GetAxis("Vertical") * speed * Time.fixedDeltaTime);

        Vector2 newPosition = player.position + Vector2.one * (movementScale / timeOffset);
        
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
