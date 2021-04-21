using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; // Unity UI related library
using UnityEngine.SceneManagement; // Unity Scene related library

public class GameManager : MonoBehaviour
{
    public GameObject gameoverText; // object to display when gameover
    public Text timeText; // display time that player is alive
    public Text recordText; // display the best time it survived

    private float surviveTime; // survival time variable
    private bool isGameover; // gameover boolean variable

    // Start is called before the first frame update
    void Start()
    {
        // reset survive time and gameover status
        surviveTime = 0;
        isGameover = false;
    }

    // Update is called once per frame
    void Update()
    {
        // when its not gameover
        if (!isGameover)
        {
            // update survive time
            surviveTime += Time.deltaTime;
            // display updated time using timeText component
            timeText.text = "Time: " + (int)surviveTime;
        }
        else
        {

            //when pressed R in gameover status
            if (Input.GetKeyDown(KeyCode.R))
            {
                //SampleScene load
                SceneManager.LoadScene("SampleScene");
            }
        }
    }

    //change the current game to gameover status
    public void EndGame()
    {
        // change gameover boolean to true
        isGameover = true;
        // activate gameover text
        gameoverText.SetActive(true);

        // Bring the best time
        float bestTime = PlayerPrefs.GetFloat("BestTime");

        // if best time is smaller than current time
        if(surviveTime > bestTime)
        {
            //update bestTime
            bestTime = surviveTime;
            // change best time using PlayerPrefs
            PlayerPrefs.SetFloat("BestTime", bestTime);
        }

        // give best time to record text component
        recordText.text = "Best Time:" + (int)bestTime;
    }
}
