using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFunctions : MonoBehaviour
{
    //game objects
    public GameObject projectile;
    public GameObject ember;

    //scripts
    public EmberSpawner emberSpawner;
    private GameManager gm;

    //attributes
    public Transform rb;
    private int timeOffset = 0;

    //renderer
    public UnityEngine.Experimental.Rendering.LWRP.Light2D lightSource;

    //UI
    public GameObject gameOverCanvas;

    //massive explosion
    public GameObject massiveExplosion;

    // Start is called before the first frame update
    void Start()
    {
        if (GameObject.Find("GameManager") != null)
        {
            gm = GameObject.Find("GameManager").GetComponent<GameManager>();
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Input.GetMouseButtonDown(0) && lightSource.pointLightInnerRadius > 0f)
        {
            Vector3 mousePos = Input.mousePosition;
            mousePos = Camera.main.ScreenToWorldPoint(mousePos);
            float angle = Mathf.Atan2(mousePos.y, mousePos.x);
            float xAxis = Mathf.Cos(angle) * 0.5f;
            float yAxis = Mathf.Sin(angle) * 0.5f;

            Instantiate(projectile, new Vector3(xAxis, yAxis, 0f), Quaternion.identity);
            float innerRadius = lightSource.pointLightInnerRadius;
            float outerRadius = lightSource.pointLightOuterRadius;
            lightSource.pointLightInnerRadius -= 1f;
            lightSource.pointLightOuterRadius -= (outerRadius / innerRadius);
        }

        if (Input.GetMouseButtonDown(1))
        {
            Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(mousePos, Vector2.zero);
            if(hit.collider != null)
            {
                //do something else
            }
        }

        if (Input.GetKeyDown("r") && lightSource.pointLightInnerRadius > 5)
        {
            massiveExplosion.SetActive(true);
            Instantiate(massiveExplosion, new Vector3(0, 0, 0), Quaternion.identity);

            float innerRadius = lightSource.pointLightInnerRadius;
            float outerRadius = lightSource.pointLightOuterRadius;
            lightSource.pointLightInnerRadius -= 5;
            lightSource.pointLightOuterRadius -= (outerRadius / innerRadius) * 5;
        }

        if(lightSource.pointLightInnerRadius == 0)
        {
            gm.LoadCanvas(gameOverCanvas);
            gm.GameOver();
        }

        if(Time.timeSinceLevelLoad > timeOffset)
        {
            if(Time.time < 101)
            {
                emberSpawner.SpawnEmberLow(0.85f, 3.5f, Vector3.zero);
            }
            else
            {
                emberSpawner.SpawnEmberMed(0.85f, 3.5f, Vector3.zero);
            }
            timeOffset++;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log(collision.gameObject);
        if (collision.collider.tag == "Enemy")
        {
            Destroy(collision.collider.gameObject);
            float innerRadius = lightSource.pointLightInnerRadius;
            float outerRadius = lightSource.pointLightOuterRadius;
            lightSource.pointLightInnerRadius -= 1f;
            lightSource.pointLightOuterRadius -= (outerRadius / innerRadius);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Ember")
        {
            Destroy(collision.gameObject);
            float innerRadius = lightSource.pointLightInnerRadius;
            float outerRadius = lightSource.pointLightOuterRadius;
            lightSource.pointLightInnerRadius += 1f;
            lightSource.pointLightOuterRadius += (outerRadius / innerRadius);
        }
    }
}
