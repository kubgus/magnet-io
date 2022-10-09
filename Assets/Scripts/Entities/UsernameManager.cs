using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class UsernameManager : MonoBehaviour
{
    TMP_Text username;

    [SerializeField] static List<string> names = new()
    {
        "Prospieler", "Castleback", "sus amogus", "Alphareign", "QuandleDingle69", "Agar.io", "Rick Astley",
        "beluga", "NotABot", "Jake", "emilia", "LaIQ", "Mavelan", "queen", "D.va", "Username", "Coolman", "Dani",
        "Coolgamebro", "Mango on a fork", "5545", "420", "6969", "854848", "Max", "ballon", "Arthur Morgan",
        "steve", "Steve", "person", "coolguy", "the", "never", "gonna", "give", "you", "up", "Superman", "balls",
        "ballslmao", "lmao", "lol", "George", "shadow", "kingman", "boss", "bossman", "Minecraft", "mc", "donald",
        "donald trupm", "joe biden", "Gungeon fan", "candice", "ligma", "joe", "Joe", "player_1523", "player_9752",
        "player_7782", "player_8425", "player_2189", "player_6781", "player_0548","player_0001", "player_9898",
        "...", "??", "!!", "winner", "givemeyoursoul", "addsf", "asdf", "qwerty", "qwertz", "asdfgds", "asdsad",
        "afdasa", "sadsaf", "safgdsa", "xyz", "cxzcz", "sksk", "man", "skull emoji", "manimded", "gtaonline",
        "RockstarGames", "valorant", "Oxzy1", "Eltex", "laiq79", "alza", "matrix gamer", "PewDiePie", "Markiplier",
        "jack", "Jack", "raiden", "raiden12588", "iplaygenshin", "genshin", "epic_gamer", "DarkWolf", "smart",
        "smartx4", "death", "timcook", "ROBLOX", "TETRIS", "simply_sin", "Duklock", "notch", "iPhone", "android",
        "LGBT", "IHas", "Iam", "IHad", "OMG", "redacted", "*****", "boy", "girl", "KnuckleDust", "Plover", "MarchHare",
        "Dreadlight", "BellBoy", "Belizard", "Blizzard6", "soldier", "putinsucks", "Ukraine", "ImpPlant", "Sunflower",
        "Outriggr", "outplay", "GilFrog", "the rock", "rock", "AI", "sock", "anime", "tomhanks", "Will Smith", "wont_smith",
        "johnnydepp", "ambersucks", "yousuck", "win diesel", "nezbednik", "tomas458", "Kubo#8525", "gagant", "victor",
        "gru", "Vector", "C#", "unity", "smallgamedev", "CodeMonkey", "BTP", "michael", "Mike", "milk", "MiEk"
    };

    // Start is called before the first frame update
    void Start()
    {
        username = transform.Find("Username").GetComponent<TMP_Text>();

        int a = PlayerPrefs.GetInt("nametags");
        switch (a)
        {
            case 1:
                username.gameObject.SetActive(false);
                break;
            default:
                username.gameObject.SetActive(true);
                break;
        }

        if (gameObject.name == "Player")
        {
            username.text = PlayerPrefs.GetString("username");
        } else
        {
            username.text = names[Random.Range(0, names.Count)];
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.N) || Input.GetMouseButtonDown(2))
        {
            int a = PlayerPrefs.GetInt("nametags");
            switch (a)
            {
                case 1:
                    username.gameObject.SetActive(false);
                    PlayerPrefs.SetInt("nametags", 0);
                    break;
                default:
                    username.gameObject.SetActive(true);
                    PlayerPrefs.SetInt("nametags", 1);
                    break;
            }
        }
    }
}
