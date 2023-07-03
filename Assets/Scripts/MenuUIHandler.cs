using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuUIHandler : MonoBehaviour
{
    public TMP_InputField userNameInputField;
    public void StartNew()
    {
        Debug.Log("Start new game");
        PersistenceManager.Instance.CurrentPlayerName = userNameInputField.text;
        SceneManager.LoadScene("main");
    }

    private void Start()
    {
        userNameInputField.text = PersistenceManager.Instance.CurrentPlayerName;
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
