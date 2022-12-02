using UnityEngine;
using System.Collections;

public class ItemScene : MonoBehaviour
{
    [SerializeField] private int configIndex;
    [SerializeField] private string screenMessage;
    public string ScreenMessage => screenMessage;

    private float liveTime = 1;
    private IItemActionListener actionListener;

    public void Wakeup(IItemActionListener actionListener)
    {
        this.actionListener = actionListener;
        StopAllCoroutines();
        StartCoroutine(Live());
    }

    private IEnumerator Live()
    {
        float time = liveTime;

        while (time > 0)
        {
            time -= Time.deltaTime;

            if (Input.GetKeyDown(KeyCode.F))
            {
                Debug.Log("Pickup");
                if (actionListener.Pickup(configIndex))
                {
                    Destroy(gameObject);
                    yield return null;
                    break;
                }
            }

            yield return null;
        }
    }


}
