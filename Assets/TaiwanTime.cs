using UnityEngine;
using TMPro;
using System;

public class TaiwanTime : MonoBehaviour
{
    TMP_Text text;

    void Start()
    {
        text = GetComponent<TMP_Text>();
    }

    void Update()
    {
        DateTime taiwanTime = DateTime.UtcNow.AddHours(8);
        text.text = taiwanTime.ToString("hh:mm tt");
    }
}