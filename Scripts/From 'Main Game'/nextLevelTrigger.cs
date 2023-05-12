using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class nextLevelTrigger : MonoBehaviour
{
    public GameObject Message;
    public GameObject loader;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            Message.SetActive(true);
        }
        if (Input.GetKeyDown(KeyCode.Z))
        {
            loader.GetComponent<LevelLoader>().LoadNextLevel();
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            Message.SetActive(false);
        }
    }
}
