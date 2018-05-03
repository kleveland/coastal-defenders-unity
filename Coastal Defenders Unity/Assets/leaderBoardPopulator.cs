using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class leaderBoardPopulator : MonoBehaviour {

    public string url = "localhost:4000/leaderboard/scores";
    private Text leaderboards;
    private ScoreEntry[] scoreEntries;
    private string scoreText;
    // Use this for initialization

    void Start()
    {
        leaderboards = this.GetComponent<Text>();
        Debug.Log("TEST");
        Debug.Log(leaderboards.text);
        leaderboards.text = "Leaderboard";
        StartCoroutine(getScores());
    }

    public void getScoresAgain()
    {
        StartCoroutine(getScores());
    }


    IEnumerator getScores()
    {
        using (WWW www = new WWW(url))
        {
            yield return www;
            scoreEntries = JsonHelper.FromJson<ScoreEntry>(www.text);
            string scoretext = "";
            for (int i = 0; i < scoreEntries.Length; i++)
            {
                scoretext += (i + 1) + "." + scoreEntries[i].player_initials + ": " + scoreEntries[i].total_score + "\n";
                Debug.Log(i + ": " + scoreEntries[i].player_initials + ": " + scoreEntries[i].total_score);
            }
            Debug.Log("LEADERBOARD");
            Debug.Log(leaderboards.text);
            Debug.Log(scoretext);
            leaderboards.text = scoretext;
            scoreText = scoretext;

        }
    }
	
	// Update is called once per frame
	void Update () {
        //Debug.Log("HERE");
        //Debug.Log(scoreText);
        leaderboards.text = scoreText;
	}
}
