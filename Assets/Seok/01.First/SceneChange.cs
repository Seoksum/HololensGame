using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChange : MonoBehaviour
{
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void GoFirstScene()
    {
        SceneManager.LoadScene("FirstScene");
    }
    public void GoSecondScene()
    {
        SceneManager.LoadScene("SecondScene");
    }
    public void GoThirdScene()
    {
        SceneManager.LoadScene("ThirdScene");
    }
    public void GoFourthScene()
    {
        SceneManager.LoadScene("FourthScene");
    }
    public void GoFifthScene()
    {
        SceneManager.LoadScene("FifthScene");
    }
    public void GameOver()
    {
        SceneManager.LoadScene("GameOver");
    }
}
