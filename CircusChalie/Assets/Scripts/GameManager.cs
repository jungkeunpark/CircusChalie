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
    public TMP_Text scoreText;// Text mesh pro ������Ʈ �� ���
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
            GFunc.LogWarning("���� �� �� �̻��� ���� �Ŵ����� �����մϴ�!");
            Destroy(gameObject);


        }

        //List<int> intList = new List<int>();
        //intList.Add(0);

        //Debug.LogFormat("intList�� ��ȿ����? (�����ϴ���?) : {0}", intList.IsValid());
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

