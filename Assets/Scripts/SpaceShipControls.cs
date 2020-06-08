using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpaceShipControls : MonoBehaviour
{

    public float speed = 30f;
    public float laserSpeed = 10f;

    public GameObject laser;
    public GameObject celKereszt;

    private bool destroyed = false;
    private float fireTime;

    // Update is called once per frame
    void FixedUpdate()
    {
        if (!destroyed)
        {
            Rigidbody2D rigidbody = gameObject.GetComponent<Rigidbody2D>();


            rigidbody.velocity = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical")) * speed;


            if (Input.GetAxis("Horizontal") != 0 || Input.GetAxis("Vertical") != 0)
            {
                rigidbody.transform.up = rigidbody.velocity;
            }
        }
        
    }

    void Update()
    {
        if (!destroyed)
        {
            if (Input.GetAxis("Fire") == 1 && Time.time > fireTime)
            {
                fireTime = Time.time + 0.4f;
                GameObject bullet = Instantiate(laser, celKereszt.transform.position, Quaternion.identity);
                bullet.GetComponent<Rigidbody2D>().AddRelativeForce(transform.up * laserSpeed);
            }
        }
        else
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                Application.Quit();
            }
        }
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (!destroyed)
        {
            if (col.gameObject.tag == "satellite" || col.gameObject.tag == "aszteroida")
            {
                GameManager.shipHP -= 1;
                GameObject.Find("Text_HP").GetComponent<Text>().text = "Health: " + GameManager.shipHP.ToString();
                if (GameManager.shipHP <= 0)
                {
                    GameObject.Find("Text_HP").GetComponent<Text>().text = "Health: 0";
                    GameObject.Find("Text_Result").GetComponent<Text>().text = "You died!\nPress Escape to quit!";
                    gameObject.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
                    destroyed = true;
                }
            }
        }
    }
}
