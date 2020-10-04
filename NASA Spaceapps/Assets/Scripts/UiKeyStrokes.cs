/*using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;
public class UiKeyStrokes : MonoBehaviour
{
    // Start is called before the first frame update
    public Canvas UserInterface;
    public GameObject[] command;
    public Text[] text;
    public RectTransform[] trans;

    
    void Start()
    {
        trans = new RectTransform[10];
        text = new Text[10];
        command = new GameObject[10];
        for (int i = 0; i < 5; i++) {
            command[i] = new GameObject("Command");
            command[i].transform.SetParent(UserInterface.transform, false);
            trans[i] = command[i].AddComponent<RectTransform>();
            text[i] = command[i].AddComponent<Text>();
            text[i].fontSize = 24;
            text[i].color = Color.white;
            text[i].font = Resources.GetBuiltinResource(typeof(Font), "Arial.ttf") as Font;
        }
    }

    // Update is called once per frame
    void Update()
    {
        var signals = Resources.FindObjectsOfTypeAll<GameObject>().Where(obj => obj.name == "Name");
        for (int i = 0; i < 10; i++)
        {
            if (i < signals.Length)
            {
                trans[i].anchoredPosition = new Vector2(-858, -100 + 30 * i);
                text[i].text = "asdfasdf";
            }
            else
            {
                trans[i].anchoredPosition = new Vector2(-8058, -100 + 30 * i);

                text[i].text = "0";
            }
            
        }
        
    }
}
*/