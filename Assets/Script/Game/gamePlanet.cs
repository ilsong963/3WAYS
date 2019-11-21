
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gamePlanet : MonoBehaviour
{

    public float damage;
    public GameObject explosion;
    private SpriteRenderer playerrender;
    GameObject Player;
    public AudioClip[] planetsound = new AudioClip[3];
    public AudioClip[] attack = new AudioClip[2];
    private AudioSource audio;
    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.FindWithTag("Player");

        audio = GetComponent<AudioSource>();
        int sound = Random.Range(0, 3);
        audio.clip = planetsound[sound];
        audio.Play();

        // Debug.Log(this.transform.position.x + "   ,   " + this.transform.position.y);

    }
    // Update is called once per frame
    void Update()
    { 
        
        
      
        // Debug.Log(Player.transform.position.x + "   ,   " + Player.transform.position.y);
        //  Debug.Log(this.transform.position.x + "   ,   " + this.transform.position.y);


    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            int sound = Random.Range(0, 2);
            audio.clip = attack[sound];
            audio.Play();



            Player.GetComponent<JoystickPlayerExample>().checkcrash(damage);


            playerrender = gameObject.GetComponent<SpriteRenderer>();
            playerrender.enabled = false;

            Instantiate(explosion, transform.position, Quaternion.identity);
            Destroy(this);

        }
    }
}