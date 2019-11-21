using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

using UnityEngine.SceneManagement;
public class toranking : MonoBehaviour
{
    private AudioSource audio;
    public InputField name;
    public int highscore;
    // Start is called before the first frame update
    void Start()
    {
        audio = GetComponent<AudioSource>();
        highscore = PlayerPrefs.GetInt("one_int");
        

    }

    // Update is called once per frame
    void Update()
    {
    }
    public void saveandSceneChange()
    {
        audio.Play();
        PlayerPrefs.SetString("one_str", name.text);
        SceneLoad();
    }
    public void SceneChange()
    {
        audio.Play(); 
        Invoke("SceneLoad", 0.2f);
}
    public void SceneLoad()
    {
        SceneManager.LoadScene("RankingScene");
    }

}
