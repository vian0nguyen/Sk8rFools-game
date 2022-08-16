using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "PlayerPos", menuName = "ScriptableObjects/PlayerPositionScriptableObj", order = 1)]
public class PlayerPosition : ScriptableObject 
{
    public Vector2 newScene_Position;
    public bool checkpoint = false;
}
