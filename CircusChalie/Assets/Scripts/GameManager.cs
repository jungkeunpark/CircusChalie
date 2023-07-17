using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public bool GameClear = false;
    public bool isGameOver = false;
    public TMP_Text scoreText;// Text mesh pro 컴포넌트 쓴 경우
    public GameObject gameoverUi;
    private int score = 0;
    private int stage = 1;

    private void Awake()
    {
        if (instance.IsValid() == false)
        {
            instance = this;
        }
        else
        {
            GFunc.LogWarning("씬에 두 개 이상의 게임 매니저가 존재합니다!");
            Destroy(gameObject);


        }

        //List<int> intList = new List<int>();
        //intList.Add(0);

        //Debug.LogFormat("intList가 유효한지? (존재하는지?) : {0}", intList.IsValid());
    }


    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (isGameOver == true && Input.GetKey(KeyCode.Z))
        {
            GFunc.LoadScene(GFunc.GetActiveSceneName());
        }
    }

    public void AddScore(int newScore)
    {
        if (isGameOver == false)
        {
            score += newScore;
            scoreText.text = string.Format("Score : {0}", score);
        }
    }


    public void Stage(int newstage)
    {
        if (isGameOver == false)
        {
            stage += newstage;
            scoreText.text = string.Format("Stage : {0}", stage);
        }
    }

    public void onPlayerDead()
    {
        if (isGameOver == false)
        {
            gameoverUi.SetActive(true);
        }
        else if (isGameOver == true)
        {
            gameoverUi.SetActive(false);
        }
    }
}

