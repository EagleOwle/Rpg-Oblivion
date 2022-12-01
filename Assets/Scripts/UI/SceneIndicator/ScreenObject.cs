using UnityEngine;
using System.Collections;

public class ScreenObject : MonoBehaviour
{
    [SerializeField] private RectTransform rectTransform;
    public ItemScene itemScene;

    private void LateUpdate()
    {
        if (itemScene == null) return;
        rectTransform.position = Camera.main.WorldToScreenPoint(itemScene.transform.position);
    }


}
