using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    private void Awake()
    {

        if(GameManager.instance != null)
        {
            Destroy(gameObject);
            return;
        }


        instance = this;
        SceneManager.sceneLoaded += LoadState;
        DontDestroyOnLoad(gameObject);
    }

    public List<int> weaponPrices;
    public List<int> xpTable;
    public List<Sprite> playerSprites;
    public List<Sprite> xpTables;

    // References
    public PlayerMove player;

    public FloatingTextManager floatingTextManager;
    // logic
    public int pesos;
    public int experience;


    // floating text
    public void ShowText(string msg, int fontSize, Color color, Vector3 position, Vector3 motion, float duration)
    {
        floatingTextManager.Show(msg, fontSize, color, position, motion, duration);

    }



    public void SaveState()
    {
        string s = "";
        s += "0".ToString() + "|";
        s += pesos.ToString() + "|";
        s += experience.ToString() + "|";
        s += "0";

        PlayerPrefs.SetString("SaveState", s);
    }

    public void LoadState(Scene s, LoadSceneMode mode)
    {
        if (!PlayerPrefs.HasKey("SaveState")) return;

        string[] data = PlayerPrefs.GetString("SaveState").Split("|");

        pesos = int.Parse(data[1]);
        experience = int.Parse(data[2]);
    }
}
