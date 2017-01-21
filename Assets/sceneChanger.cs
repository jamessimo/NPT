using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class sceneChanger : MonoBehaviour {
    public void newGame()
    {
       SceneManager.LoadScene("Game");
    }
}
