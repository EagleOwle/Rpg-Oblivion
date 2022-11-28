using UnityEngine;
using System.Collections;
using TMPro;
using UnityEngine.UI;
using System;

public class UIGameTopPanel : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI coinsText;
    [SerializeField] private TextMeshProUGUI pointsText;

    public void Initialise(IPlayerGetData playerData)
    {
        playerData.eventChangeCoints += OnChangeCoins;
        playerData.eventChangePoints += OnChangePoints;

        OnChangeCoins(playerData.GetCoins());
        OnChangePoints(playerData.GetPoints());
        
    }

    private void OnChangeCoins(int value)
    {
        StopAllCoroutines();
        int current = int.Parse(coinsText.text);
        StartCoroutine(LerpValue(current, value, (output) => { coinsText.text = output.ToString(); }));
    }

    private void OnChangePoints(int value)
    {
        StopAllCoroutines();
        int current = int.Parse(pointsText.text);
        StartCoroutine(LerpValue(current, value, (output) => { pointsText.text = output.ToString(); }));
    }

    private IEnumerator LerpValue(float current, float target, Action<float> output, float dumpTime = 10f)
    {
        while (current != target)
        {
            current = Mathf.MoveTowards(current, target, dumpTime * Time.deltaTime);
            output(Mathf.RoundToInt(current));
            yield return null;
        }
    }

}
