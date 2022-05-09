using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class GameplayManager : MonoBehaviour
{
    public static GameplayManager Instance { get; private set; } //Sorry Wridzer

    protected Dictionary<Checkpoint, bool> checkpoints;
    protected Checkpoint lastCheckpoing; //For respawns
    protected StartBlock startBlock;
    protected float timer;
    protected bool timerActive;
    protected Player player;
    [SerializeField] protected GameObject playerPrefab;


    protected virtual void Awake()
    {
        if(Instance != null) { Debug.LogWarning("A Gameplay Manager already existed and was destroyed."); Destroy(Instance.gameObject); }
        Instance = this;

        checkpoints = new Dictionary<Checkpoint, bool>();
    }

    public void InstantiateLevel(GameObject level)
    {
        Instantiate(level, Vector3.zero, Quaternion.identity);
    }

    public virtual void SpawnPlayer()
    {
        //PROTOTYPE ONLY. Most likely has to change to accommodate VR.
        //Probably we can just put the main menu in the same scene, and instantiate the player immediately but disable its movement
        //Or something idk ik ben geen dev

        player = Instantiate(playerPrefab, startBlock.playerSpawnPoint.position, startBlock.playerSpawnPoint.rotation).GetComponent<Player>();
    }

    public void SetStartBlock(StartBlock _startBlock)
    {
        if(startBlock != null) { Debug.LogError("There should never be multiple start blocks in a level. Someone fucked up."); }
        startBlock = _startBlock;
    }

    public void AddCheckpoint(Checkpoint _checkpoint)
    {
        checkpoints.Add(_checkpoint, false);
    }

    protected virtual void Update()
    {
        if (timerActive) { timer += Time.deltaTime; }
    }

    protected virtual IEnumerator StartRun()
    {
        player.ResetValues();
        player.enabled = false; //Ugly?
        timer = 0.0f;
        timerActive = false;

        startBlock.SetLights(Color.black);

        yield return new WaitForSeconds(1.0f);
        startBlock.SetLight(0, Color.red);

        yield return new WaitForSeconds(1.0f);
        startBlock.SetLight(1, Color.red);

        yield return new WaitForSeconds(1.0f);
        startBlock.SetLight(2, Color.red);
        
        yield return new WaitForSeconds(1.0f);
        startBlock.SetLights(Color.green);        
        timerActive = true;
        player.enabled = true;
    }

    public virtual void PassCheckpoint(Checkpoint _checkpoint)
    {
        if (checkpoints[_checkpoint]) { return; }
        Debug.Log("Passed checkpoint " + _checkpoint);
        checkpoints[_checkpoint] = true;
        //Code here that saves current player state for respawning
    }

    public virtual void PassFinish()
    {        
        if (CheckIfAllCheckpointsPassed())
        {
            PlayerFinished();
        }
    }

    protected abstract void PlayerFinished();

    protected bool CheckIfAllCheckpointsPassed()
    {
        //Mijs: Hier kijkt de code of alle checkpoints gehaald zijn, dus hier kunnen evt. finish lampjes in

        bool done = true;
        foreach (bool p in checkpoints.Values)
        {
            done = done && p; //Could we make an early stopper. Yes, and it might be marginally more efficient. But this is shorter and cool boolean magic, so deal with it
        }
        return done;
    }
}
