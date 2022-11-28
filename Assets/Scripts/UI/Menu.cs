using System;
using UnityEngine;

[RequireComponent(typeof(CanvasGroup))]
public class Menu : MonoBehaviour
{
	
	[SerializeField] private CanvasGroup canvasGroup;
	[SerializeField] protected float _fadeTime = 0.2f;
	[SerializeField] protected bool _lerpOnPause = false;

	public virtual void Show()
    {
		StopAllCoroutines();

		canvasGroup.alpha = 0f;
		gameObject.SetActive(true);

		if ((Time.timeScale <= 0f && _lerpOnPause == true) || Time.timeScale > 0f)
		{
			this.LerpCoroutine(time: _fadeTime,
				               from: canvasGroup.alpha,
				               to: 1f,
				               action: a => canvasGroup.alpha = a,
				               settings: new CoroutineTemplate.Settings(lerpOnPause: _lerpOnPause)
			                   );
		}
		else
		{
			canvasGroup.alpha = 1f;
		}
	}

    public virtual void Hide()
    {
        StopAllCoroutines();

		canvasGroup.alpha = 1f;

		if ((Time.timeScale <= 0f && _lerpOnPause == true) || Time.timeScale > 0f)
		{
			this.LerpCoroutine(time: _fadeTime, 
				               from: canvasGroup.alpha,
				               to: 0f,
				               action: a => canvasGroup.alpha = a,
				               onEnd: () => gameObject.SetActive(false),
				               settings: new CoroutineTemplate.Settings(lerpOnPause: _lerpOnPause)
			                   );
		}
		else
		{
			canvasGroup.alpha = 0f;
			gameObject.SetActive(false);
		}

	}

    public virtual void Hide(float _fadeTime)
    {
        StopAllCoroutines();

        canvasGroup.alpha = 1f;

        if ((Time.timeScale <= 0f && _lerpOnPause == true) || Time.timeScale > 0f)
        {
            this.LerpCoroutine(time: _fadeTime,
                               from: canvasGroup.alpha,
                               to: 0f,
                               action: a => canvasGroup.alpha = a,
                               onEnd: () => gameObject.SetActive(false),
                               settings: new CoroutineTemplate.Settings(lerpOnPause: _lerpOnPause)
                               );
        }
        else
        {
            canvasGroup.alpha = 0f;
			gameObject.SetActive(false);
        }

    }

}