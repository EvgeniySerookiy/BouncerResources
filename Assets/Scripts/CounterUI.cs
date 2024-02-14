using System;
using TMPro;
using UnityEngine;

public class CounterUI : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI redGiftCount;
    [SerializeField]
    private TextMeshProUGUI greenGiftCount;
    [SerializeField]
    private TextMeshProUGUI blueGiftCount;
    [SerializeField]
    private TextMeshProUGUI numberPlayerSteps;
    
    public void ShowGiftCount(int count, Color color)
    {
        if (color == Color.red)
        {
            redGiftCount.text = count.ToString();
        }
        else if (color == Color.green)
        {
            greenGiftCount.text = count.ToString();
        }
        else if (color == Color.blue)
        {
            blueGiftCount.text = count.ToString();
        }
    }

    public void ShowNumberSteps(int count)
    {
        int currentNumber = Convert.ToInt32(numberPlayerSteps.text);
        currentNumber += count;
        numberPlayerSteps.text = currentNumber.ToString();
    }
}