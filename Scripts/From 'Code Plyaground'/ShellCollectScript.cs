using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class ShellCollectScript : MonoBehaviour, ICollectible
{
   public static event Action OnShellCollected;//This is for collecting "Egg Shell"
   public void Collect()
   {
        OnShellCollected?.Invoke();
        Debug.Log("You Got A Shell!!");
        Destroy(gameObject);
   }
}
