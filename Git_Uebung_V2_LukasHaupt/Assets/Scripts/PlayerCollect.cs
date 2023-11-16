using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerCollect : MonoBehaviour
{
    public int ScoreValue;

    private GameObject ScoreValueObj;

    [SerializeField] private Player PlayerScript;

    public GameObject CoinPrefab;

    void Start()
    {
        ScoreValueObj = GameObject.Find("ScoreValue");
        PlayerScript = GameObject.Find("Player").GetComponent<Player>();
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
