using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AnimShow : MonoBehaviour
{

    public GameObject circumLoad; 

    // Update is called once per frame
    void Update()
    {
        if(FindObjectOfType<OutlineProg>().progress >= 1.015f)
        {
            circumLoad.SetActive(true);
            Invoke("LoadNextSc", 2f);
        } 
    }

    void LoadNextSc()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
