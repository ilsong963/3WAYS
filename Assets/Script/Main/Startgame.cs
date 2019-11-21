using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Startgame : MonoBehaviour
{
    private AudioSource audio;
    // Start is called before the first frame update
    void Start()
    {
        audio = GetComponent<AudioSource>();
    }


    // Update is called once per frame
    void Update()
    {
        
    }
    public void SceneChange()
    {
        
        audio.Play();
        Invoke("SceneLoad", 0.2f);

    }
    public void SceneLoad()
    {
        SceneManager.LoadScene("GameScene");
    }
}
