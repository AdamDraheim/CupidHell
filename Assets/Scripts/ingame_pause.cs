using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ingame_pause : MonoBehaviour
{

    public GameObject obj;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            pause();
        }
    }

    public void pause()
    {
        obj.active = true;
        Time.timeScale = 0;
    }

    public void unpause()
    {
        Time.timeScale = 1;
        obj.active = false;
    }

    public void Restart()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(name);
    }

    public void Quit()
    {
        Application.Quit();
    }

}
