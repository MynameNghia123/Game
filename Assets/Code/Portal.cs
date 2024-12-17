using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portal : Collidable
{
    public string[] scenceNames;

    protected override void OnCollide(Collider2D other)
    {
        if(other.name == "Player")
        {
            GameManager.instance.SaveState();
            string sceneName = scenceNames[Random.Range(0, scenceNames.Length)];
            UnityEngine.SceneManagement.SceneManager.LoadScene(sceneName);
        }
    }
}
