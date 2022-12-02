using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponHolder : MonoBehaviour
{
    [SerializeField] private bool onlyHideCursor;

    [SerializeField] private Animator animator;
	[SerializeField] private SmoothFollow smoothFollow;

    private int configItemIndex;
    private Weapon current;

    public void Initialise(ref Action<int> SetItem)
    {
        SetItem += OnChangeWeapon;
    }

    public void OnChangeWeapon(int configItemIndex)
    {
        this.configItemIndex = configItemIndex;
        smoothFollow.enabled = false;
		animator.SetTrigger("Hide");
        StopAllCoroutines();
    }

    private void EndHide()//Animator event
    {
        if (current != null)
        {
            current.SelfDestroy();
            current = null;
        }

        InstantiateItem(configItemIndex);
        smoothFollow.enabled = true;
    }

	private void InstantiateItem(int configItemIndex)
    {
        if (configItemIndex < 0) return;
        Weapon prefab = ConfigStorage.Instance.configItem.configsWeapon[configItemIndex].weaponPrefab;
        current = Instantiate(prefab, transform);
        StartCoroutine(WaitInput());
    }

    private IEnumerator WaitInput()
    {
        while(true)
        {
            if (onlyHideCursor && Cursor.visible == true) break;

            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
                current.Attack();
            }

            yield return null;
        }
    }


}
