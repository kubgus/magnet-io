using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class UsernameManager : MonoBehaviour
{
    [SerializeField] TMP_Text username;

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
        "gru", "Vector", "C#", "unity", "smallgamedev", "CodeMonkey", "BTP", "michael", "Mike", "milk", "MiEk",
        "Tom Scott", "skype", "zoom", "corona", "COVID-19", "atomic", "explosive", "explos7", "Moon", "pwpf",
        "James", "Michal", "popcat", "russia4", "iamveryc", "coolman", "daniel", "89797/5648", "4524827528", "4849548125",
        "125485675", "7586684", "687548454", "95481554", "andrew84585", "stickman", "StickFight", "falldown", "visitor",
        "GUEST", "guest4854045", "guest84854845", "guest454851", "guest71815", "guest95841", "guest32515", "guest75934",
        "doge", "dogecoin", "elon", "ElonMusk", "sweden", "C418", "wholetthed", "lookin", "vibin", "bing chilling", "jetstream",
        "fall guys", "Killher", "dead", "idied", "9999999", "pivot", "IVAN", "ip", "192.168.0.1", "Sorcer",
        "mauser", "panzer", "mouseman", "cat_dat", "sus", "cheek", "Wholegrain", "cringe", "undertale", "him", "her"
    };

    // Start is called before the first frame update
    void Start()
    {
        // FOR MAIN MENU
        try
        {
            if (gameObject.name == "Player")
            {
                username.text = PlayerPrefs.GetString("username");
            }
            else
            {
                username.text = names[Random.Range(0, names.Count)];
            }
        } catch { }
    }

    private void Update()
    {
        // FOR MAIN MENU
        try
        {
            switch (PlayerPrefs.GetInt("nametags"))
            {
                case 0:
                    username.gameObject.SetActive(true);
                    break;
                default:
                    username.gameObject.SetActive(false);
                    break;
            }
        } catch { }
    }

    void OnGUI()
    {
        if (Event.current.Equals(Event.KeyboardEvent("N")))
        {
            switch (PlayerPrefs.GetInt("nametags"))
            {
                case 0:
                    PlayerPrefs.SetInt("nametags", 1);
                    break;
                default:
                    PlayerPrefs.SetInt("nametags", 0);
                    break;
            }
        }
    }
}
