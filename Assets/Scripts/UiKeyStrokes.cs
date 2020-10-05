using System.Collections;
using System;
using UnityEngine;
using UnityEngine.UI;
using System;


public class UiKeyStrokes : MonoBehaviour
{
    // Start is called before the first frame update
    public Canvas UserInterface;
    public GameObject[] command;
    public Text[] text;
    public RectTransform[] trans;
    public static int count;

    void Start()
    {
        count = 0;
        trans = new RectTransform[50];
        text = new Text[50];
        command = new GameObject[50];
        for (int i = 0; i < 50; i++)
        {
            command[i] = new GameObject("Command");
            command[i].transform.SetParent(UserInterface.transform, false);
            trans[i] =command[i].AddComponent<RectTransform>();
            trans[i].anchoredPosition = new Vector2(-7000, 200 - 30 * count);
            trans[i].sizeDelta = new Vector2(500, 100);
            text[i] = command[i].AddComponent<Text>();
            text[i].fontSize = 24;
            text[i].color = Color.white;
            text[i].font = Resources.GetBuiltinResource(typeof(Font), "Arial.ttf") as Font;
        }
    }

    // Update is called once per frame
    void Update()
    {
        string message = RecordKeyStrokes.message;
        count = 0;
        if (String.IsNullOrEmpty(message))
        {
            foreach(Text t in text)
            {
                t.text = "";
            }
        }
       
        foreach (char motion in message)
        {
            
            Debug.Log(message);
            trans[count].anchoredPosition = new Vector2(-700, 200 - 30 * count);
            switch (motion)
            {
                case 'N':
                    continue;
                    break;
                case 'U':
                    count += 1;
                    text[count].text = "Perseverance@Mars:~$ Drive Forward";
                    break;
                case 'D':
                    count += 1;
                    text[count].text = "Perseverance@Mars:~$ Drive Backward";
                    break;
                case 'R':
                    count += 1;
                    text[count].text = "Perseverance@Mars:~$ Turn Right";
                    break;
                case 'L':
                    count += 1;
                    text[count].text = "Perseverance@Mars:~$ Turn Left";
                    break;
            }
        }
        

    }
}
