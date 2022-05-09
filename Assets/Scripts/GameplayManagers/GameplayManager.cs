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
        //Code to spawn player at start block here


        timer = 0.0f;
        timerActive = true; //probably want this after some sort of countdown. Refactor later.
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

    public virtual void PassCheckpoint(Checkpoint _checkpoint)
    {
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

    public abstract void PlayerFinished();

    protected bool CheckIfAllCheckpointsPassed()
    {
        bool done = true;
        foreach (bool p in checkpoints.Values)
        {
            done = done && p; //Could we make an early stopper. Yes, and it might be marginally more efficient. But this is shorter and cool boolean magic, so deal with it
        }
        return done;
    }
}
