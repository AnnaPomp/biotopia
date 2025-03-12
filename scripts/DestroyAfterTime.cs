using System.Collections;
using UnityEngine;

public class DestroyAfterTime : MonoBehaviour
{
    public float timeToDestroy = 60f;  // Timpul în secunde până la distrugerea obiectului

    private void Start()
    {
        // Apelăm corutina care va distruge obiectul după un minut
        StartCoroutine(DestroyObjectAfterTime(timeToDestroy));
    }

    // Corutina care distruge obiectul după un interval de timp
    private IEnumerator DestroyObjectAfterTime(float time)
    {
        yield return new WaitForSeconds(time);  // Așteaptă pentru timpul dat
        Destroy(gameObject);  // Distruge obiectul
    }
}
