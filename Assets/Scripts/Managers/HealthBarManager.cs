using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBarManager : MonoBehaviour
{

    public static HealthBarManager Instance;

    public Slider bar;

    public void SetHealthBar(int num)
    {
        bar.value = num;
    }
}
