using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Player : MonoBehaviour
{
    private Animation thisAnimation;
    public Vector3 jump;
    public float velocity = 2.0f;
    Rigidbody rb;
    
    
    void Start()
    {
        thisAnimation = GetComponent<Animation>();
        thisAnimation["Flap_Legacy"].speed = 3;

        rb = GetComponent<Rigidbody>();
        jump = new Vector3(0.0f, 2.0f, 0.0f);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            thisAnimation.Play();
            rb.velocity = (Vector3.up * velocity);
        }

        transform.position = new Vector3(0, Mathf.Clamp(transform.position.y, -5000f, 3.6f), 0);
      
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Floor")
        {
            SceneManager.LoadScene("gameOver");
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Collider")
        {
            
            GameManager.thisManager.UpdateScore(1);
        }
    }
}
