using UnityEngine;
using UnityEngine.UI;

public class ItemCollector : MonoBehaviour
{
    private int totalCoin, totalKey;
    [SerializeField] private Text textCoin,textKey;

    private void Start()
    {
        totalCoin = 0;
        totalKey = 0;
    }

    private void Update()
    {
        textCoin.text = totalCoin.ToString();
        textKey.text = totalKey.ToString();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        /*if (collision.gameObject.CompareTag("Coin"))
        {
            Destroy(collision.gameObject);
            totalCoin++;
        }*/
        string tag = collision.tag;
        switch (tag)
        {
            case "Coin":
                Destroy(collision.gameObject);
                totalCoin++;
                break;

            case "Key":
                Destroy(collision.gameObject);
                totalKey++;
                break;
        }
    }
}