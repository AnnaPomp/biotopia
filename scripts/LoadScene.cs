using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class LoadScene : MonoBehaviour
{
    public Animator scenetrans;
    private void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.CompareTag("PERSONAJ"))
        {
            StartCoroutine("LoadLevel");
        }
    }

    IEnumerator LoadLevel()
    {
        scenetrans.SetTrigger("Start");

        yield return new WaitForSeconds(1);
        SceneManager.LoadScene("Cave");
    }
}
