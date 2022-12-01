using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponHolder : MonoBehaviour
{
	[SerializeField] private Animator animator;
	[SerializeField] private SmoothFollow smoothFollow;

    private int configItemIndex;
    private IItem currentItem;

    public void Initialise(ref Action<int> SetItem)
    {
        SetItem += OnChangeWeapon;
    }

    public void OnChangeWeapon(int configItemIndex)
    {
        this.configItemIndex = configItemIndex;
        smoothFollow.enabled = false;
		animator.SetTrigger("Hide");
    }

    private void EndHide()//Animator event
    {
        if (currentItem != null)
        {
            Destroy(currentItem.GetGameObject());
        }

        InstantiateItem(configItemIndex);
        smoothFollow.enabled = true;
    }

	private void InstantiateItem(int configItemIndex)
    {
        if (configItemIndex < 0) return;
        Weapon prefab = ConfigStorage.Instance.configItem.configsWeapon[configItemIndex].weaponPrefab;
        currentItem = Instantiate(prefab, transform) as IItem;
    }

}
