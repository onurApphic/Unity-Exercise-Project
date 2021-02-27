using UnityEngine;
using System.Collections;

public class Game : MonoBehaviour
{
    public int currentExp;
    public int currentLevel;
    void Start()
    {
        Player myPlayer = new Player();

        myPlayer.Experience = 50000;
        currentExp = myPlayer.Experience;
        currentLevel = myPlayer.Level;
    }
}