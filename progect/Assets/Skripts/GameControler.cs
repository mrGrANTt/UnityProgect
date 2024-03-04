using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameControler : MonoBehaviour
{
    public Gameoverskript Gameoverskript;
    int health = 0;

    public void GameOver()
    {
        Gameoverskript.Setup(health);
    }
}
