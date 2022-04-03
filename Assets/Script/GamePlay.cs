using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GamePlay : MonoBehaviour
{
    public GameObject Panel;
 
    // Start is called before the first frame update

        public void PauseButton()
    {
        Panel.SetActive(true);
        Time.timeScale = 0f;
    }

    public void Resume()
    {
        Panel.SetActive(false);
        Time.timeScale = 1f;   
    }

    public void Quit()
    {
        Application.Quit();
    }
    public void Tieptuc()
    {
        //Application.LoadLevel("lv1");
        SceneManager.LoadScene("lv1");
    }

}
