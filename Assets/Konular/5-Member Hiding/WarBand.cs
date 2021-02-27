using UnityEngine;
using System.Collections;

public class WarBand : MonoBehaviour
{
    void Start()
    {
        Humanoid human = new Humanoid();
        Humanoid enemy = new Enemy();
        Humanoid orc = new Orc();


        Enemy enemy2 = new Enemy();
        Orc orc2 = new Orc();


        //Notice how each Humanoid variable contains
        //a reference to a different class in the
        //inheritance hierarchy, yet each of them
        //calls the Humanoid Yell() method.
        human.Yell();
        enemy.Yell();
        orc.Yell();


        orc2.Yell();
        enemy2.Yell();
    }
}