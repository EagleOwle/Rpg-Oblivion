using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponHolder : MonoBehaviour
{
	[SerializeField] private Weapon sword;
	[SerializeField] private Weapon staff;
	[SerializeField] private Weapon axe;

	[SerializeField] private float damping = 2.0f;
	[SerializeField] private Transform showPosition;
    [SerializeField] private Transform hidePosition;

	private int currentWeaponIndex;

    private void Start()
    {
		sword.gameObject.SetActive(false);
		staff.gameObject.SetActive(false);
		axe.gameObject.SetActive(false);
		OnChangeWeapon(3);
	}

    public void OnChangeWeapon(int weaponIndex)
    {
		StopAllCoroutines();
		currentWeaponIndex = weaponIndex;
		StartCoroutine(Hide());
    }

	//private IEnumerator Show()
	//{
	//	while (true)
	//	{
	//		transform.position = Vector3.Lerp(transform.position, showPosition.position, damping * Time.deltaTime);
	//		transform.rotation = Quaternion.Lerp(transform.rotation, showPosition.rotation, damping * Time.deltaTime);
	//		yield return null;
	//	}
	//}

	private IEnumerator Hide()
    {
		while((transform.eulerAngles.y != hidePosition.eulerAngles.y))
        {
			transform.position = Vector3.Lerp(transform.position, hidePosition.position, damping * Time.deltaTime);
			transform.rotation = Quaternion.Lerp(transform.rotation, hidePosition.rotation, damping * Time.deltaTime);
			yield return null;
        }

		Debug.Log("OnPosition");
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

		//StartCoroutine(Show());
	}

}
