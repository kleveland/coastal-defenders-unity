using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Timer : MonoBehaviour
{
    public int timeLeft;
    public Text countdownText;
    public string navToScene;
    // Use this for initialization
    void Start()
    {
        StartCoroutine("LoseTime");
        Time.timeScale = 1;
    }

    // Update is called once per frame
    void Update()
    {
      
        //timer in seconds
        //if timer runs to 0, automatically start simulation

        if (timeLeft <= 0)
        {
            StopCoroutine("LoseTime");
            countdownText.text = "Times Up!";
            SceneManager.LoadScene(navToScene);
        }

        if (timeLeft < 10)
        {
            countdownText.text = ("0:0" + timeLeft);
        }

        else
        {
            countdownText.text = ("0:" + timeLeft);
        }
    }

    IEnumerator LoseTime()
    {
        while (true)
        {
            yield return new WaitForSeconds(1);
            timeLeft--;
        }
    }
}