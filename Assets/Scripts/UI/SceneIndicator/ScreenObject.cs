using UnityEngine;
using System.Collections;
using System;
using TMPro;

public class ScreenObject : MonoBehaviour
{
    public event Action<ScreenObject> eventHide;
    [SerializeField] private RectTransform rectTransform;
    [SerializeField] private TextMeshProUGUI messageText;

    private ItemScene item;
    public ItemScene Item => item;
    private float liveTime = 1;

    public void Initialise(ItemScene item)
    {
        this.item = item;
        messageText.text = item.ScreenMessage;
        gameObject.SetActive(true);
        ReInitialise();
    }

    public void ReInitialise()
    {
        StopAllCoroutines();
        StartCoroutine(Live());
    }

    private IEnumerator Live()
    {
        float time = liveTime;

        while (time > 0)
        {
            if (item != null)
            {
                rectTransform.position = Camera.main.WorldToScreenPoint(item.transform.position);
            }

            time -= Time.deltaTime;
            yield return new WaitForEndOfFrame();
        }

        eventHide.Invoke(this);
    }

}
