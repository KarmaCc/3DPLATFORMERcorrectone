using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonUI : MonoBehaviour
{
    public void Play()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(1);
    }
    public void Quit()
    {
        Application.Quit();
        //debug.log ("BBC");
    }

}
