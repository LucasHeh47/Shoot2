using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerScore : MonoBehaviour
{

    public static PlayerScore Instance;

    public int score;
    public TextMeshProUGUI text;

    // Start is called before the first frame update
    void Start()
    {
        Instance = this;
    }

    public void AddScore(int num)
    {
        score = score + num;
        text.SetText("Score: " + score);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
