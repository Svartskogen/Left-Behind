using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndMenuButtons : MonoBehaviour
{
    public Type type;
    
    public void OnButton()
    {
        if(type == Type.PlayAgain)
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene(0);
        }
        else
        {
            Application.Quit();
        }
    }
    public enum Type { PlayAgain, Quit}
}
