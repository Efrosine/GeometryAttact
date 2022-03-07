using UnityEngine;

public class Crusher : MonoBehaviour
{
    [SerializeField] private Transform[] movePoint;
    private int indexMp = 0;
    [SerializeField] private float speedUp, speedDown;

    // Start is called before the first frame update
    private void Start()
    {
    }

    // Update is called once per frame
    private void Update()
    {
        if (Vector2.Distance(transform.position, movePoint[indexMp].position) < .01)
        {
            indexMp++;
            if (indexMp >= movePoint.Length) indexMp = 0;
        }

        if (indexMp == 0) transform.position = Vector2.MoveTowards(transform.position, movePoint[0].position, speedDown * Time.deltaTime);
        else transform.position = Vector2.MoveTowards(transform.position, movePoint[1].position, speedUp * Time.deltaTime);
    }
}