using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public int diff = 0; // ���������� ���������

    private void Awake()
    {
        // ���� ��������� ��� ���������� � ��� �� ���� ���������, ���������� ���� ���������.
        if (instance != null && instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            // ���������� ��������� � ���� ������ � ������� ��� ��������������
            instance = this;
        }
    }
}   