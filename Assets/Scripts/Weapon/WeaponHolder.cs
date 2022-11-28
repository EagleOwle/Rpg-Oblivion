using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponHolder : MonoBehaviour
{
	[SerializeField] private bool onlyHideCursor = true;

	[SerializeField] private Animator animator;
	[SerializeField] private SmoothFollow smoothFollow;

	[SerializeField] private Weapon sword;
	[SerializeField] private Weapon staff;
	[SerializeField] private Weapon axe;


	private int currentWeaponIndex;

    private void Start()
    {
		//sword.gameObject.SetActive(false);
		staff.gameObject.SetActive(false);
		axe.gameObject.SetActive(false);
	}

    public void OnChangeWeapon(int weaponIndex)
    {
		currentWeaponIndex = weaponIndex;
		smoothFollow.enabled = false;
		animator.SetTrigger("Hide");
    }


    private void Update()
    {
		if (onlyHideCursor && Cursor.visible == true) return;

		if (Input.GetKeyDown(KeyCode.Alpha1))
        {
			OnChangeWeapon(1);

		}

		if (Input.GetKeyDown(KeyCode.Alpha2))
		{
			OnChangeWeapon(2);

		}

		if (Input.GetKeyDown(KeyCode.Alpha3))
		{
			OnChangeWeapon(3);

		}
	}


    private void EndHide()
    {
		ChangeWeapon();
	}

	private void ChangeWeapon()
    {
		switch (currentWeaponIndex)
        {
			case(1):
				sword.gameObject.SetActive(true);
				staff.gameObject.SetActive(false);
				axe.gameObject.SetActive(false);
				break;
			case(2):
				sword.gameObject.SetActive(false);
				staff.gameObject.SetActive(true);
				axe.gameObject.SetActive(false);
				break;
			case(3):
				sword.gameObject.SetActive(false);
				staff.gameObject.SetActive(false);
				axe.gameObject.SetActive(true);
				break;
        }

		smoothFollow.enabled = true;
	}

	

}
