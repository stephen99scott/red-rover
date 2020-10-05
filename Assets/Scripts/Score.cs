using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public static float score;
    // Start is called before the first frame update
    void Start()
    {
        score = 0f;
        gameObject.GetComponent<Text>().text = "Score: " + score;
    }
}
