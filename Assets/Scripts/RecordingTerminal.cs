using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RecordingTerminal : MonoBehaviour
{
    private float startTime;
    private int count2 = 0; 
    private string[] message = { "Perseverance@Mars:~$" , "Perseverance@Mars:~$ █" };
    // Start is called before the first frame update
    public Text terminal;
    void Start()
    {
        terminal.text = message[count2];
        startTime = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        RectTransform transform = terminal.GetComponent<RectTransform>();
        transform.anchoredPosition = new Vector2(-700, 200 - 30 * (UiKeyStrokes.count));
        if(count2 == 1 && Time.time - startTime > 0.5)
        {
            count2 = 0;
            startTime = Time.time;
        }else if(count2 == 0 && Time.time - startTime > 0.5)
        {
            count2 = 1;
            startTime = Time.time;
        }
        Debug.Log(count2);
        terminal.text = message[count2];
    }
}
