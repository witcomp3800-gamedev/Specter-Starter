﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class GameState
{

    public enum STATE
    {
        PLAY, GAMEOVER
    }
    public enum EVENT
    {
        EXIT, UPDATE, ENTER
    }

    public STATE name;
    protected EVENT stage;
    protected GameState nextState;
    protected GameManager gameManager;

    public GameState()
    {
        gameManager = GameManager.instance();
    }

    public virtual void Enter()
    {
        stage = EVENT.UPDATE;
    }
    public virtual void Update()
    {
        stage = EVENT.UPDATE;
    }
    public virtual void Exit()
    {
        stage = EVENT.EXIT;
    }

    public GameState process()
    {
        if (stage == EVENT.ENTER) Enter();
        if (stage == EVENT.UPDATE) Update();
        if (stage == EVENT.EXIT)
        {
            Exit();
            return nextState;
        }
        return this;
    }
}

public class Play : GameState
{
    public Play() : base()
    {
        name = STATE.PLAY;
        stage = EVENT.ENTER;
    }

    public override void Enter()
    {
        base.Enter();
    }

    public override void Update()
    {
        // all gamemanager stuff here
        // called every frame
        gameManager.entityAction(); // contain all movement and attacking 
    }

    public override void Exit()
    {
        base.Exit();
    }


}