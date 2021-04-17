using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobalManager : MonoBehaviour
{

    public static GlobalManager Instance;

    public AudioSource song;
    public AudioLowPassFilter audioEdit;

    public float Currency;

    public int recentScore;
    public int highScore;

    // Start is called before the first frame update
    void Awake()
    {
        if (Instance == null)
        {
            DontDestroyOnLoad(gameObject);
            Instance = this;
        }
        else if(Instance != this)
        {
            Destroy(gameObject);
        }
    }

    public void UpMusic()
    {
        song.volume = 1;
        audioEdit.cutoffFrequency = 16000;
    }

    public void DownMusic()
    {
        song.volume = 0.6f;
        audioEdit.cutoffFrequency = 1250;
    }

    public void SavePlayer()
    {
        GlobalManager.Instance.Currency = Currency;
        GlobalManager.Instance.recentScore = recentScore;
        GlobalManager.Instance.highScore = highScore;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
