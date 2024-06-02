using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;

public class GetItem : MonoBehaviour
{
	[Tooltip("How far you can fetch items from")]
	public float _checkRadius;
	Dictionary<GameObject, GameObject> _inventory = new Dictionary<GameObject, GameObject>();
	[SerializeField] List<GameObject> _gameobjects = new List<GameObject>();
	// Start is called before the first frame update
	void Start()
	{
		
	}

	// Update is called once per frame
	void Update()
	{
		if (Input.GetKeyDown(KeyCode.Space))
		{
			CheckForItem();
		}
	}

	void CheckForItem()
	{
		Collider[] hitColliders = Physics.OverlapSphere(transform.position, _checkRadius);
		foreach(var hitCollider in hitColliders)
		{
			foreach(Item item in hitCollider.gameObject.GetComponents<Item>())
			{
                _inventory.Add(item.GetUsage(), hitCollider.gameObject);
                _gameobjects.Add(hitCollider.gameObject);
                hitCollider.gameObject.SetActive(false);
            }
			if(hitCollider.gameObject.TryGetComponent<RequireItem>(out RequireItem usage))
			{
				Debug.Log("Yep");
				if(_inventory.TryGetValue(usage.gameObject, out _)){
                    usage._enabled ^= true;
                    _inventory.Remove(usage.gameObject);
                }
			}
		}
	}

    void ShowInventory()
	{
		foreach(var stuff in _inventory)
		{
            
        }
	}
}
