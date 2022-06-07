using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NetworkManager : MonoBehaviour
{
    private static uint nextNetworkId = 0;
    public static uint NextNetworkID => ++nextNetworkId;

    [SerializeField]
    private NetworkSpawnInfo spawnInfo;
    private Dictionary<uint, GameObject> networkedReferences = new Dictionary<uint, GameObject>();

    public bool GetReference( uint id, out GameObject obj ) {
        obj = null;
        if (networkedReferences.ContainsKey(id)) {
            obj = networkedReferences[id];
            return true;
		}
        return false;
	}

    public bool UploadScore(int _playerId, int _trackId, System.TimeSpan _time)
    {
        uint timeAsInt = (uint)_time.Milliseconds;
        string scoreURL = $"https://studenthome.hku.nl/~wridzer.kamphuis/kernmodule_networking/insert_time.php?time={timeAsInt}&user_id={_playerId}&track_id={_trackId}";

        Application.OpenURL(scoreURL);

        return true;
    }

    public bool SpawnWithId( NetworkSpawnObject type, uint id, out GameObject obj ) {
        obj = null;
        if ( networkedReferences.ContainsKey(id)) {
            return false;
		}
        else {
            // assuming this doesn't crash...
            obj = GameObject.Instantiate(spawnInfo.prefabList[(int)type]);
            
            NetworkedBehaviour beh = obj.GetComponent<NetworkedBehaviour>();
            if ( beh == null ) {
                beh = obj.AddComponent<NetworkedBehaviour>();
			}
            beh.networkId = id;

            networkedReferences.Add(id, obj);

            return true;
		}
	}

    public bool DestroyWithId(uint id) {
        if (networkedReferences.ContainsKey(id)) {
            Destroy(networkedReferences[id]);
            networkedReferences.Remove(id);
            return true;
        }
        else {
            return false;
        }
    }
}