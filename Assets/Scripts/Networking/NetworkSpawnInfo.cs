using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum NetworkSpawnObject
{
	PLAYER = 0,
	BULLET = 1
}

[CreateAssetMenu(menuName = "My Assets/NetworkSpawnInfo")]
public class NetworkSpawnInfo : ScriptableObject
{
	// TODO: A serializableDictionary would help here...
	public List<GameObject> prefabList = new List<GameObject>();
}
