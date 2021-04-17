using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class EnemyManager : MonoBehaviour
{

    public static EnemyManager Instance;

    public GameObject[] enemies;
    public GameObject DefaultSpawnEnemy;

    public TextMeshProUGUI roundText;
    public TextMeshProUGUI nextRoundCooldown;
    public TextMeshProUGUI enemiesLeftText;

    public bool startingRound = false;

    public int Kills;

    public float SpawnMinY;
    public float SpawnMaxY;
    public float SpawnMinX;
    public float SpawnMaxX;

    public int enemiesThisRound;
    public int enemiesLeft;
    public int enemiesRoundOne;
    public float enemiesPerRoundMultiplier;

    public int enemiesOnMap = 0;
    public int Round = 0;

    public float remainingTime = 0f;

    // Start is called before the first frame update
    void Start()
    {
        Instance = this;
        Kills = 0;
        for(int i = 0; i < enemies.Length; i++)
        {
            enemies[i].GetComponent<EnemyHealth>().enemy.MaxHealth = enemies[i].GetComponent<EnemyHealth>().enemy.DefaultMaxHealth;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (enemiesOnMap == 0 && enemiesLeft == 0 && !startingRound)
        {
            StartCoroutine(NewRound());
        }
    }

    IEnumerator StartRound()
    {
        for (int i = 0; i < enemiesThisRound; i++)
        {
            yield return new WaitForSeconds(Random.Range(1, 3));
            GameObject ChosenEnemy;
            ChosenEnemy = enemies[Random.Range(0, enemies.Length)];
            if (ChosenEnemy.GetComponent<EnemyHealth>().enemy.StartSpawningRound > Round) ChosenEnemy = DefaultSpawnEnemy;
            Instantiate(ChosenEnemy, new Vector3(Random.Range(SpawnMinX, SpawnMaxX), Random.Range(SpawnMinY, SpawnMaxY)), transform.rotation);
            enemiesOnMap++;
        }
    }

    IEnumerator NewRound()
    {
        startingRound = true;
        Round++;
        roundText.SetText(Round.ToString());
        if(Round == 1)
        {
            enemiesThisRound = enemiesRoundOne;
        }
        else
        {
            enemiesThisRound = (int)(enemiesThisRound * enemiesPerRoundMultiplier);
        }
        enemiesLeft = enemiesThisRound;
        enemiesLeftText.SetText(enemiesLeft.ToString());
        if(Round < 50 && Round > 1)
        {
            for (int i = 0; i < enemies.Length; i++)
            {
                if(enemies[i].GetComponent<EnemyHealth>().enemy.StartSpawningRound < Round) enemies[i].GetComponent<EnemyHealth>().IncreaseMaxHealth();
            }
        }
        float duration = 10f;
        remainingTime = duration;
        while (remainingTime > 0f)
        {
            remainingTime -= Time.deltaTime;
            nextRoundCooldown.SetText("Round Starting in: " + ((int)remainingTime).ToString() + " Seconds");
            yield return null;
        }
        StartCoroutine(StartRound());
        startingRound = false;
        nextRoundCooldown.SetText(" ");
    }
}
