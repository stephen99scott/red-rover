using System.Threading;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverScript : MonoBehaviour
{
    // Start is called before the first frame update
    public Canvas GameOver;
    void Start()
    {
        MarsHealth.health = 100;
        GameOver.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(MarsHealth.health <= 0){

            GameOver.enabled = true;
            Time.timeScale = 0;
        }
    }

    public void PlayAgain()
    {
        MarsHealth.health = 100f;
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
       
    }
}
