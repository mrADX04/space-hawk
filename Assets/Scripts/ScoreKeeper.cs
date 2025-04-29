using UnityEngine;

public class ScoreKeeper : MonoBehaviour
{
    int score = 0;

    static ScoreKeeper instance;

    public int GetScoreKeeper()
    {
        return score;
    }

    //making the instance global for using **Way 2 of executiong singleton pattern**
    //but we will not be using this geetter method in our project
    // public ScoreKeeper GetInstance()
    // {
    //     return instance;
    // }
    void Awake()
    {
        ManageSingleton();
    }

    void ManageSingleton()
    {
        //**WAY 1 of executing singleton pattern (non-global way/method)**
        // int instanceCount = FindObjectsOfType(GetType()).Length;
        // if(instanceCount > 1)
        if(instance != null)
        {
            gameObject.SetActive(false);
            Destroy(gameObject);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }
    public int GetScore ()
    {
      return score;
    }

    public void ModifyScore (int value)
    {
        score += value;
        Mathf.Clamp(score, 0, int.MaxValue);
        Debug.Log(score);
    } 

    public void ResetScore ()
    {
        score = 0;
    }
}
