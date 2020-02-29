using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Swap_Sprite : MonoBehaviour
{

    public Sprite[] sprites;

    public string type;

    private GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (player == null || player.GetComponent<PlayerStats>() == null)
        {
            player = GameObject.Find("Player");
        }
        else {

            float val = player.GetComponent<PlayerStats>().GetPower(type);
            Debug.Log(val * sprites.Length);
            this.GetComponent<Image>().sprite = sprites[(int)(val * sprites.Length)];

        }

    }
}
