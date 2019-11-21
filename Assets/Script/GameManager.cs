using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

using UnityEngine.SceneManagement;
public class GameManager : MonoBehaviour
{
    public AudioClip end;
    public AudioClip dirchange;
    private AudioSource audio;
    public Text scoretx;
    public float score =0f;
    public Text enginetx;
    public float engine;
    public int dir;
    public int predir;
    float timer;
    int waitingTime;
    public bool isRest = false;
    int highscore;
    GameObject player_dir;
    GameObject fix;
    GameObject Player;
    public GameObject bolt;
    int count;
    // Start is called before the first frame update
    void Start()
    {

        count = 0;
        audio = GetComponent<AudioSource>();
        audio.clip = dirchange;
        Player = GameObject.FindWithTag("Player");
        timer = 0.0f;
        waitingTime = 8;
        dir = 0;
        score = 0f;
        player_dir= Player.GetComponent<JoystickPlayerExample>().dir;


        highscore = PlayerPrefs.GetInt("one_int");

    }

    // Update is called once per frame
    void Update()
    {
        engine = Player.GetComponent<JoystickPlayerExample>().engine;
        enginetx.text = "Engine: " + (int)engine;
       
        scoretx.text = "Score: " + (Mathf.Floor(score)*10).ToString();
        score += Time.deltaTime;
        if (engine <= 0)
        {
            enginetx.text = "Engine: " + 0;
            Debug.Log(" score " + score + "  high" + highscore);
            if ((Mathf.Ceil(score) * 10) > highscore)
            {
                audio.clip = end;
                audio.Play();
                PlayerPrefs.SetInt("one_int", (int)(Mathf.Ceil(score) * 10));
                SceneManager.LoadScene("HighscoreScene");
            }
            else
                SceneManager.LoadScene("RankingScene");
        }


        timer += Time.deltaTime;

        if (timer > waitingTime)
        {
            Debug.Log("change!");
            if (isRest)
            {

                dir = Random.Range(0, 5);
                while (dir == predir)
                {
                    dir = Random.Range(0, 5);
                }
                predir = dir;
                isRest = false;
                switchdir(dir); 
                Player.GetComponent<JoystickPlayerExample>().dirsave(dir);
            }
            else
            {
                Player.GetComponent<JoystickPlayerExample>().dirsave(0);

                player_dir.transform.rotation = Quaternion.Euler(0, 0, 0);
                isRest = true;

                float x, y;
                x = Random.Range(-1.5f, 1.5f);
                y = Random.Range(-2.8f, 2.6f);

                fix = Instantiate(bolt, new Vector2(x, y), transform.rotation);

            }
            timer = 0;
            count++;

        }
    }



    void switchdir(int dir)
    {

        player_dir.transform.Rotate(0, 0, 0);

        switch (dir)
        {
            case 2:
                player_dir.transform.rotation = Quaternion.Euler(0, 0, 90);
                Debug.Log("dir 2");
                break;
            case 3:
                player_dir.transform.rotation = Quaternion.Euler(0, 0, 270);

                Debug.Log("dir 3");
                break;
            case 4:
                player_dir.transform.rotation = Quaternion.Euler(0, 0, 180);

                Debug.Log("dir 4");

                break;
        }
    }
}