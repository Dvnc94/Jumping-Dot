using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dot : MonoBehaviour {
    public float upForce = 300f;
    public AudioSource tapAudio;
    public AudioSource dieAudio;
    private bool isDead = false;
    private Rigidbody2D rb2d;
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D> ();
    }

    void Update()
    {
        if(isDead == false) {
            if(Input.GetMouseButtonDown(0)) {
                rb2d.velocity = Vector2.zero;
                rb2d.AddForce(new Vector2(0, upForce));
                tapAudio.Play();
            }
        }
    }

    void OnCollisionEnter2D() {
        rb2d.simulated = false;
        isDead = true;
        GameControl.instance.PlayerDied();
        dieAudio.Play();
    }
}
