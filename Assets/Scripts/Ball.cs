using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    [SerializeField]
    private Rigidbody rb;
    [SerializeField]
    private GameObject splashImg;
    [SerializeField]
    private float jumpForce;

    private GameManager gm;
    private Kat kat;

    private bool canJump;

    void Start()
    {
        gm = GameObject.FindObjectOfType<GameManager>();
    }

    private void FixedUpdate()
    {
        canJump = true;
    }

    private void OnCollisionEnter(Collision other) 
    {
        GameObject splash =  Instantiate(splashImg, transform.position - new Vector3(0, 0.22f, 0f), transform.rotation);
        splash.transform.SetParent(other.gameObject.transform);
        Destroy(splash, 1);

        string materialName = other.gameObject.GetComponent<MeshRenderer>().material.name;

       if(materialName == "Safe (Instance)" && canJump == true) {
            rb.velocity = Vector3.zero;
            rb.AddForce(Vector3.up * jumpForce * Time.deltaTime, ForceMode.Impulse);
            canJump = false;
        }   

        else if(materialName == "Unsafe (Instance)") {
            gm.restartGame();
        }

        else if(materialName == "Final (Instance)")
        {
            gm.restartGame();
        }
    }
}
