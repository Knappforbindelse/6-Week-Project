using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CollectItemText : MonoBehaviour
{
    public TextMeshProUGUI shellText;
    int shellCount;

    private void OnEnable()
    {
        ShellCollectScript.OnShellCollected += IncrementShellCount;
    }

    private void OnDisable()
    {
        ShellCollectScript.OnShellCollected -= IncrementShellCount;
    }

    public void IncrementShellCount()
    {
        shellCount++;
        shellText.text = $"Shells: {shellCount}";
    }
}
