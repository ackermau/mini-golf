using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;

// End Screen code
public class Credits : MonoBehaviour
{  
    // loads game - retry button
    public void LoadGame() {
        SceneManager.LoadScene(1);
    }
    // loads main menu - main menu button
    public void LoadMain() {
        SceneManager.LoadScene(0);
    }
}