using System;
using System.Collections;
#if UNITY_EDITOR
using UnityEditor;
#endif
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

// Sets the script to be executed later than all default scripts
// This is helpful for UI, since other things may need to be initialized before setting the UI
[DefaultExecutionOrder(1000)]
public class ManuUI : MonoBehaviour
{
    public Text user;
    public Text score;

    private void Start()
    {
        user.text ="Name: " + DataStuff.Instance.userName;
        score.text = "Best Score: " + DataStuff.Instance.bestScore;
    }
    public void StartNew()
    {
        DataStuff.Instance.SaveJason();
        SceneManager.LoadScene(1);
    }
    public void ToMenu()
    {
        DataStuff.Instance.SaveJason();
        SceneManager.LoadScene(0);
    }
    public void Exit()
    {
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit(); // original code to quit Unity player
#endif
    }
}
