using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ReturnToMainMenu : MonoBehaviour
{
    void Start()
    {
        SceneManager.LoadScene(GetSceneName.mainMenu);
    }
}
