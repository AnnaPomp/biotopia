using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public ItemManager itemManager;
    public TileManager tileManager;
    public Ui_manager uiManager;
    public Player player;
    public Inventory_man inventoryManager;
    public GoldEvents goldEvents;
    public MiscEvents miscEvents;
    public PlayerEvents playerEvents;

    private void Awake()
    {
        if(instance!=null&& instance!=this )
        {
            Destroy(this.gameObject);
        }
        else
        {
            instance = this;
        }
        DontDestroyOnLoad(this.gameObject);
        itemManager = GetComponent<ItemManager>();
        tileManager = GetComponent<TileManager>();
        uiManager = GetComponent<Ui_manager>();
        inventoryManager = GetComponent<Inventory_man>();
        player = FindObjectOfType<Player>();
        goldEvents = new GoldEvents();
        miscEvents = new MiscEvents();
        playerEvents = new PlayerEvents();
    }
}
