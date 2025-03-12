using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CircleCollider2D))]
public class Coin : MonoBehaviour
{
    [Header("Config")]
    [SerializeField] private float respawnTimeSeconds = 8;
    [SerializeField] private int goldGained = 1;

    private CircleCollider2D circleCollider;
    private SpriteRenderer visual;

    private void Awake()
    {
        circleCollider = GetComponent<CircleCollider2D>();
        visual = GetComponentInChildren<SpriteRenderer>();
    }

    private void CollectCoin()
    {
        circleCollider.enabled = false; // Dezactivează doar collider-ul
        visual.enabled = false; // Ascunde moneda
        GameManager.instance.goldEvents.GoldGained(goldGained);
        GameManager.instance.miscEvents.CoinCollected(); // Notifică sistemul că moneda a fost colectată
        StopAllCoroutines();
        StartCoroutine(RespawnAfterTime());
    }

    private IEnumerator RespawnAfterTime()
    {
        yield return new WaitForSeconds(respawnTimeSeconds);
        circleCollider.enabled = true; // Reactivăm collider-ul
        visual.enabled = true; // Reactivăm sprite-ul
    }

    private void OnTriggerEnter2D(Collider2D otherCollider)
    {
        if (otherCollider.CompareTag("PERSONAJ"))
        {
            CollectCoin();
        }
    }
}
