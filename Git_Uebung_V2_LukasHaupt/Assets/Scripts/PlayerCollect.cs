using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerCollect : MonoBehaviour
{
    public int ScoreValue;

    private GameObject ScoreValueObj;
    private GameObject WinscreenObj;

    private Player PlayerScript;


    void Start()
    {
        ScoreValueObj = GameObject.Find("ScoreValue");
        PlayerScript = GameObject.Find("Player").GetComponent<Player>();
        WinscreenObj = GameObject.Find("WinScreen").transform.GetChild(0).gameObject;

        WinscreenObj.SetActive(false);
    }
    private void Update()
    {
        if (ScoreValue >= 3)
        {
            WinscreenObj.SetActive(true);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Collectable"))
        {
            Destroy(other.gameObject);
            ScoreValue += 1;
            ScoreValueObj.GetComponent<TMP_Text>().text = ScoreValue.ToString();
        }
    }

    public void CountScorePlus()
    {
        ScoreValue += 1;
        ScoreValueObj.GetComponent<TMP_Text>().text = ScoreValue.ToString();
    }
}
