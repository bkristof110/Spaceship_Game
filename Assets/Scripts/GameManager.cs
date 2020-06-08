using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject asteroid;
    public GameObject camera;
    public GameObject ship;

    public static int shipHP = 10;
    public static int score = 0;

    // Update is called once per frame
    void Start()
    {
        camera.transform.rotation = new Quaternion(0, 0, 0,0);
        for (int i = 0; i < 50; i++)
        {
            GameObject a = Instantiate(asteroid, new Vector2(Random.Range(-50, 50), Random.Range(-25, 25)), Quaternion.identity);
            a.GetComponent<Rigidbody2D>().AddForce(new Vector2(Random.Range(-50, 50), Random.Range(-50, 50)));
        }
        
    }
}
