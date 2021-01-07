using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{

    public Text yildizSayisi;

    private void Start()
    {
        string v = PlayerPrefs.GetInt("yildiz").ToString();
        yildizSayisi.text = v;
    }
    public void GoToMenu()
    {
        SceneManager.LoadScene(0);
        
    }

    public void GoToGame()
    {
        SceneManager.LoadScene(1);
        Time.timeScale = 1;
    }
}
