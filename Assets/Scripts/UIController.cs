using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIController : MonoBehaviour
{
    public GameObject RetryPanel;
    public static bool dead;
    private void Start()
    {
        dead = false;
    }
    private void Update()
    {
        if(dead)
        {
            RetryPanel.SetActive(true);
        }
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
