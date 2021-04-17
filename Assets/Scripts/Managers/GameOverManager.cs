using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameOverManager : MonoBehaviour
{

    public TextMeshProUGUI highscore;
    public TextMeshProUGUI score;
    public TextMeshProUGUI cashearned;

    // Start is called before the first frame update
    void Start()
    {
        highscore.SetText("High Score: " + GlobalManager.Instance.highScore.ToString());
        score.SetText("Score: " + GlobalManager.Instance.recentScore.ToString());
        cashearned.SetText("Cash Earned: " + (GlobalManager.Instance.recentScore / 10).ToString());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
