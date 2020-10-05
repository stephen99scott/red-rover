using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HandleRockCollision : MonoBehaviour
{
    public GameObject ScoreText;

    // Increase health on collision
    void OnCollisionEnter(Collision col)
    {
        //Debug.Log(col.gameObject.tag);
        if (col.gameObject.tag == "RoverCollider")
        {
            //Debug.Log("Collision detected");
            Score.score += 1f;
            ScoreText.GetComponent<Text>().text = "Score: " + Score.score;
            MarsHealth.health += 10f;
            if (MarsHealth.health > 100f)
            {
                MarsHealth.health = 100f;
            }
            Destroy(gameObject);
        }
    }
}
