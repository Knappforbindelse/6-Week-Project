using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class restartController : MonoBehaviour
{
    public int Respawn;
    public void restartGame()
    {
        SceneManager.LoadScene(Respawn);
        Debug.Log("Restarting...");
    }

    public void endGame()
    {
        Debug.Log("Back to menu...");
        SceneManager.LoadScene(0);
    }
}
