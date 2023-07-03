using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainUIHandler : MonoBehaviour
{
    public void BackToMainMenu()
    {
        Debug.Log("Back to menu");
        SceneManager.LoadScene("menu");
    }
}
