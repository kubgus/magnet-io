using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UsernameManager : MonoBehaviour
{
    [SerializeField] static List<string> names = new()
    {
        "Prospieler", "Castleback", "sus amogus", "Alphareign", "QuandleDingle69", "Agar.io", "Rick Astley",
        "beluga", "NotABot", "Jake", "emilia", "LaIQ", "Mavelan", "queen", "D.va", "Username", "Coolman", "Dani",
        "Coolgamebro", "Mango on a fork", "5545", "420", "6969", "854848", "Max", "ballon", "Arthur Morgan",
        "steve", "Steve", "person", "coolguy", "the", "never", "gonna", "give", "you", "up", "Superman", "balls",
        "ballslmao", "lmao", "lol", "George", "shadow", "kingman", "boss", "bossman", "Minecraft", "mc", "donald",
        "donald trupm", "joe biden", "我们能变得更高吗", "Gungeon fan"
    };

    // Start is called before the first frame update
    void Start()
    {
        TMP_Text username = transform.Find("Username").GetComponent<TMP_Text>();
        if (gameObject.name == "Player")
        {
            username.text = PlayerPrefs.GetString("username");
        } else
        {
            username.text = names[Random.Range(0, names.Count)];
        }
    }
}
