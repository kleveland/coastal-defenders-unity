using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;
using UnityEngine.SceneManagement;

public class gameEnd : MonoBehaviour {
    public RawImage backdrop;
    public Text text;
    public static bool endGameLoop;
    public UnityEngine.Video.VideoPlayer videoPlayer;
    public VideoClip[] videoClips = new VideoClip[3];
    public RawImage image;
    private bool breakLoop;
    private float time;
    public float duration;
    private Color initCol;
    // Use this for initialization
    void Start () {
        initCol = backdrop.color;
        endGameLoop = false;
        breakLoop = true;
	}
	
	// Update is called once per frame
	void Update () {
		if(Timer.endgame)
        {
            Timer.endgame = false;
            endGameLoop = true;
            text.text = "Brace for Impact!";
        }
        if(endGameLoop && breakLoop)
        {
            backdrop.raycastTarget = true;
            time += Time.deltaTime / duration;
            text.color = Color.Lerp(Color.clear, Color.white, time);
            backdrop.color = Color.Lerp(Color.clear, initCol, time);

        }
        if (endGameLoop && Mathf.Approximately(backdrop.color.a, initCol.a) && breakLoop)
        {
            breakLoop = false;
            StartCoroutine(playVideo());
            Debug.Log("STARTING END ANIMATION");
        }
    }

    IEnumerator playVideo()
    {
        Debug.Log("VIDEO HERE");
        videoPlayer.clip = videoClips[0];
        videoPlayer.Prepare();
        //Disable Play on Awake for both Video and Audio
        //videoPlayer.playOnAwake = false;

        //Wait until video is prepared
        while (!videoPlayer.isPrepared)
        {
            yield return null;
        }

        Debug.Log("Done Preparing Video");

        //Assign the Texture from Video to RawImage to be displayed
        image.texture = videoPlayer.texture;



        //Play Video
        videoPlayer.Play();


        //image.color = new Color(255.0f, 255.0f, 255.0f, 1f);

        Debug.Log("Playing Video");
        while (videoPlayer.isPlaying)
        {
            //Debug.LogWarning("Video Time: " + Mathf.FloorToInt((float)videoPlayer.time));
            yield return null;
        }
        

        Debug.Log("Done Playing Video");
        backdrop.color = initCol;
        SceneManager.LoadScene("endgame");
    }
}
