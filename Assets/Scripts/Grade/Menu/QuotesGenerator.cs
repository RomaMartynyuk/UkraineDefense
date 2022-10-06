using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuotesGenerator : MonoBehaviour
{
    [SerializeField] string[] Quotes;
    Text text;
    void Start()
    {
        text = GetComponent<Text>();
        RandomChooseQuote();
    }

    void RandomChooseQuote()
    {
        int j = Random.Range(0, Quotes.Length);
        for(int i = 0; i < Quotes.Length; i++)
        {
            if(i == j)
            {
                text.text = Quotes[i];
                break;
            }
        }
    }
}
