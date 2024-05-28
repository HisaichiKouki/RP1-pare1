using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManagerScript : MonoBehaviour
{
    // Start is called before the first frame update
    public float MaxTime;
    float gameTimer;

    [SerializeField, Header("プレイヤー落下時に減らす秒数")] private float damegeCount;
    public TextMeshProUGUI text;

    public GameObject finishText;
    bool isFinish;
    void Start()
    {
        gameTimer = MaxTime;
        isFinish = false;
    }

    // Update is called once per frame
    void Update()
    {

        CountDown();
        if (isFinish)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                SceneManager.LoadScene("ResultScene");
            }
        }

    }
    void CountDown()
    {
        if (isFinish)
        {
            return;
        }
        else
        {
            gameTimer -= Time.deltaTime;
            if (gameTimer <= 0)
            {
                isFinish = true;
                finishText.SetActive(true);
            }
        }
        text.SetText("Time" + gameTimer.ToString("f1"));
    }

    public void IsDamage() { gameTimer -= damegeCount; }
    public bool IsFinish() { return isFinish; }
}
