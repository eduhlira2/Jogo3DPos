using System.Collections;

using System.Collections.Generic;

using UnityEngine;



public class PlayerMove : MonoBehaviour

{
    [SerializeField] GameObject player;
    [SerializeField] private float speedchar;
    private Rigidbody rb;
    private Animator anim;

    void Start()

    {
        anim = player.GetComponent<Animator>();

        rb = GetComponent<Rigidbody>();

    }





    void FixedUpdate()

    {

        float h = Input.GetAxis("Vertical") * speedchar;

        float v = Input.GetAxis("Horizontal") * -speedchar;



        Vector3 vel = rb.velocity;
     

        vel.x = h;

        vel.z = v;

        rb.velocity = vel;
        

        if (Input.GetAxis("Vertical") > 0)
        {
            transform.rotation = Quaternion.Euler(new Vector3(0,90,0));
            Debug.Log("Ta indo para Frente");
            anim.Play("walk");
        }
        if (Input.GetAxis("Vertical") < 0)
        {
            transform.rotation = Quaternion.Euler(new Vector3(0, 270, 0));
            Debug.Log("Ta indo para Trás");
            anim.Play("walk");
        }
        if (Input.GetAxis("Horizontal") < 0)
        {
            transform.rotation = Quaternion.Euler(new Vector3(0, 0, 0));
            Debug.Log("Ta indo para Esquerda");
            anim.Play("walk");
        }
        if (Input.GetAxis("Horizontal") > 0)
        {
            transform.rotation = Quaternion.Euler(new Vector3(0, 180, 0));
            Debug.Log("Ta indo para Direita");
            anim.Play("walk");
        }

        if (Input.GetAxis("Vertical") == 0 && Input.GetAxis("Horizontal") == 0)
        {
            Debug.Log("Ta parado");
            anim.Play("idle");
        }

    }

    

}
