using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    private static GameManager _instance = null;

    void Awake()
    {
        if (_instance == null)
        {
            _instance = this;
        } else
        {
            Destroy(this);
        }
    }

    public static GameManager instance()
    {
        return _instance;
    }

    private GameState state;
    public Player player;

    void Start()
    {
        state = new Play();
    }

    void Update()
    {
        state = state.process();
    }

    // called every update frame from state machine
    public void entityAction()
    {
        // move player and bosses/enemies, attacks
        player.move();
    }

}
