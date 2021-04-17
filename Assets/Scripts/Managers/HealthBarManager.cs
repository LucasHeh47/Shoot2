using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBarManager : MonoBehaviour
{

    public static HealthBarManager Instance;

    public Slider bar;
    public Slider shieldBar;

    public void Start()
    {
        Instance = this;
    }

    public void SetHealthBar(float num)
    {
        bar.value = num;
    }

    public void SetShieldBar(float num)
    {
        shieldBar.value = num;
    }
}
