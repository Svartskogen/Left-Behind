using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Generic UI buttons event handlers
/// </summary>
public class EndMenuButtons : MonoBehaviour
{
    [SerializeField] Type type;
    
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
