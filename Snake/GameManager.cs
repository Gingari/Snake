using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public int diff = 0; // ѕеременна€ сложности

    private void Awake()
    {
        // ≈сли экземпл€р уже существует и это не этот экземпл€р, уничтожьте этот экземпл€р.
        if (instance != null && instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            // ”становить экземпл€р в этот объект и сделать его неуничтожаемым
            instance = this;
        }
    }
}   