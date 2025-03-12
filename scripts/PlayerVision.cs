using UnityEngine;

public class PlayerVision : MonoBehaviour
{
    private DarknessManager darknessManager;

    private void Start()
    {
        darknessManager = FindObjectOfType<DarknessManager>();
    }

    private void Update()
    {
        Vector2Int playerPos = new Vector2Int(Mathf.RoundToInt(transform.position.x), Mathf.RoundToInt(transform.position.y));
        darknessManager.RevealArea(playerPos);
    }
}
