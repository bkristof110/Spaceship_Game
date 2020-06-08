using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Laser : MonoBehaviour
{

    public float time;

    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, time);
    }
    
    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.tag == "aszteroida")
        {
            GameManager.score += 50;
            GameObject.Find("Text_Score").GetComponent<Text>().text = "Score: " + GameManager.score;

            Destroy(coll.gameObject);
            Destroy(gameObject);
        }
        else if (coll.gameObject.tag == "satellite")
        {
            coll.gameObject.GetComponent<Satellite>().hp--;
            if (coll.gameObject.GetComponent<Satellite>().hp <= 0)
            {
                Destroy(coll.gameObject);
                GameManager.score += 100;
                GameObject.Find("Text_Score").GetComponent<Text>().text = "Score: " + GameManager.score;
            }
            
            Destroy(gameObject);
        }
    }
}
