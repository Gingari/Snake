using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class SnakeController : MonoBehaviour
{
    public float speedmultiply = 1.05f;
    public float Speed = 10f;
    Vector3 direction = Vector3.up;
    public FoodSpawner fds;
    public int rec = 0;
    public GameObject tailPrefab;
    private List<GameObject> tailSegments = new List<GameObject>();
    public TextMeshProUGUI record;
    public TextMeshProUGUI GameOver;
    public TextMeshProUGUI Mtext;
    public TextMeshProUGUI SrectText;
    public Button menu;
    public Button startagain;

    private void Start()
    {
        // Получение уровня сложности из GameManager
        int diff = GameManager.instance.diff;

        switch (diff)
        {
            case 0:
                Speed = 10f;
                speedmultiply = 1.05f;
                break;
            case 1:
                Speed = 13f;
                speedmultiply = 1.06f;
                break;
            case 2:
                Speed = 15f;
                speedmultiply = 1.08f;
                break;
            case 3:
                Speed = 18f;
                speedmultiply = 1.1f;
                break;
        }

        delaystart();
        Time.timeScale = 1;
        SrectText.enabled = false;
        Mtext.enabled = false;
        startagain.image.enabled = false;
        menu.image.enabled = false;
        menu.enabled = false;
        startagain.enabled = false;
        GameOver.enabled = false;
        tailSegments.Add(gameObject);
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.W) && direction != Vector3.down)
        {
            direction = Vector3.up;
            gameObject.transform.rotation = Quaternion.Euler(0, 0, 0);
        }
        else if (Input.GetKey(KeyCode.A) && direction != Vector3.right)
        {
            direction = Vector3.left;
            gameObject.transform.rotation = Quaternion.Euler(0, 0, 90);
        }
        else if (Input.GetKey(KeyCode.S) && direction != Vector3.up)
        {
            direction = Vector3.down;
            gameObject.transform.rotation = Quaternion.Euler(0, 0, 180);
        }
        else if (Input.GetKey(KeyCode.D) && direction != Vector3.left)
        {
            direction = Vector3.right;
            gameObject.transform.rotation = Quaternion.Euler(0, 0, -90);
        }
    }

    void FixedUpdate()
    {
        for (int i = tailSegments.Count - 1; i > 0; i--)
        {
            Vector3 targetPosition = tailSegments[i - 1].transform.position;
            tailSegments[i].transform.position = Vector3.Lerp(tailSegments[i].transform.position, targetPosition, Time.deltaTime * Speed * 0.7f);
        }
        Vector3 newPosition = this.transform.position + new Vector3(direction.x, direction.y, 0f);
        this.transform.position = Vector3.Lerp(this.transform.position, newPosition+direction, Time.deltaTime * Speed);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Wall"))
        {
            Time.timeScale = 0;
            Debug.Log("error");
            GameOver.enabled = true;
            SrectText.enabled = true;
            Mtext.enabled = true;
            startagain.image.enabled = true;
            menu.image.enabled = true;
            menu.enabled = true;
            startagain.enabled = true;
        }

        if (collision.gameObject.CompareTag("Food"))
        {
            Destroy(GameObject.Find("Food(Clone)"));
            Speed = Speed * speedmultiply;
            fds.Spawn();
            rec++;
            record.text = Convert.ToString(rec);
            AddTailSegment();
        }
    }

    IEnumerator delay()
    {
        yield return new WaitForSeconds(0.9f);
    }

    IEnumerator delaystart()
    {
        yield return new WaitForSeconds(2f);
    }

    void AddTailSegment()
    {
        Color RandomColor()
        {
            float r = (float)mRandom.GetRandomNumber(0, 1f);
            float g = (float)mRandom.GetRandomNumber(0, 1f);
            float b = (float)mRandom.GetRandomNumber(0, 1f);
            return new Color(r, g, b);
        }
        GameObject newSegment = Instantiate(this.tailPrefab);
        newSegment.GetComponent<SpriteRenderer>().material.color = RandomColor();
        newSegment.transform.position = tailSegments[tailSegments.Count - 1].transform.position - direction;
        StartCoroutine(delay());
        tailSegments.Add(newSegment);
    }
}

class mRandom
{
    public static System.Random random = new System.Random();

    public static double GetRandomNumber(double minimum, double maximum)
    {
        return random.NextDouble() * (maximum - minimum) + minimum;
    }
}
