using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Countdown : MonoBehaviour
{
    public string m_Timer = @"00:00";
    private static float m_TotalSeconds = 600;
    public bool m_IsPlaying;
    public Text m_Text;

    // Start is called before the first frame update
    void Start()
    {
        m_Timer = CountdownTimer(false);
        m_IsPlaying = false;
    }

    // Update is called once per frame
    void Update()
    {

        if (m_IsPlaying)
        {
            m_Timer = CountdownTimer();
            //if (m_TotalSeconds <= 420)
            //    HPManager.hp = 2;
            //if (m_TotalSeconds <= 240)
            //    HPManager.hp = 1;

            if (m_TotalSeconds <= 0)
            {
                //HPManager.hp = 0;
                SetZero();
            }
        }

        if (m_Text)
            m_Text.text = m_Timer;
    }

    private string CountdownTimer(bool IsUpdate = true)
    {
        if (IsUpdate)
            m_TotalSeconds -= Time.deltaTime;

        TimeSpan timespan = TimeSpan.FromSeconds(m_TotalSeconds);
        string timer = string.Format("{0:00}:{1:00}", timespan.Minutes, timespan.Seconds);
        return timer;       
    }

    private void SetZero()
    {
        m_Timer = @"00:00";
        m_TotalSeconds = 0;
        m_IsPlaying = false;
        SceneManager.LoadScene("GameOver");
    }
    public void StartPlaying() { m_IsPlaying = true; }
    public void StopPlaying() { m_IsPlaying = false; }
}
