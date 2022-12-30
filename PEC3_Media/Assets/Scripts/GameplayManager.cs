using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameplayManager : MonoBehaviour
{
    private void OnEnable()
    {
        Robot_Controller.OnDefeated += PlayerDefeated;
    }

    private void OnDisable()
    {
        Robot_Controller.OnDefeated -= PlayerDefeated;
    }

    private void PlayerDefeated(string name)
    {
        print("Player " + name + " defeated.");
    }
}
