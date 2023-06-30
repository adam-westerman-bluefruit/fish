using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Rewired;
using UnityEngine.Assertions;

public class PlayerManager : MonoBehaviour
{
    public int playerId;
    private Player rewiredPlayer;
    public Follow cam;
    public PlayerCharacter character;
    public bool canInput = true;

    void Start()
    {
        cam.target = character.transform;
        rewiredPlayer = ReInput.players.GetPlayer(playerId);
        Assert.IsNotNull(rewiredPlayer);
        print(rewiredPlayer.controllers);
    }

    void updateCamera()
    {
        float camH = rewiredPlayer.GetAxis("CamHorizontal");
        cam.Turn(camH);
    }

    void movePlayer()
    {
        Vector2 dir = rewiredPlayer.GetAxis2D("PlayerHorizontal", "PlayerVertical");
        character.move(dir, cam.transform.forward);
    }

    void FixedUpdate()
    {
        if(!canInput)
            return;


        updateCamera();
        movePlayer();

    }
}
