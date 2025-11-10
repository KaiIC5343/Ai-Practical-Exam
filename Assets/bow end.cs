using UnityEditor;
using UnityEngine;

public class bowend : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    private void OnDestroy()
    {
        if (Application.isEditor)
        {
            EditorApplication.isPlaying = false;    
        }
    }
}
