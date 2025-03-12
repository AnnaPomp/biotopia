using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CHARACTERMOVEMENT : MonoBehaviour
{
    //get input from player\
    public Animator animator;
    public float viteza;
    private bool facingRight = true;
    private void Update()// get input of position of player
    {
        float orizontal = Input.GetAxisRaw("Horizontal");//coordonatele de pe orizontala
        float vertical = Input.GetAxisRaw("Vertical");//coordonatele de pe verticala


        Vector3 Directie = new Vector3(orizontal, vertical);
        //stochez in vector pozitia jucatorului
        animateMovement(Directie);
        FlipCharacter(orizontal);
        animateMovement(Directie);
        transform.position += Directie*viteza*Time.deltaTime;
    }
    void animateMovement(Vector3 directie)
    {
        if (animator != null)
        {
            if(directie.magnitude>0)
            {
                animator.SetBool("semisca", true);
                animator.SetFloat("horizontal", directie.x);
                animator.SetFloat("vertical", directie.y);
            }
            else
            {
                animator.SetBool("semisca", false);
            }
        }
    }

    void FlipCharacter(float orizontal)
    {
        if (orizontal > 0 && !facingRight)
        {
            Flip();
        }
        else if (orizontal < 0 && facingRight)
        {
            Flip();
        }
    }

    void Flip()
    {
        facingRight = !facingRight;
        Vector3 scale = transform.localScale;
        scale.x *= -1; 
        transform.localScale = scale;
    }
}
