using UnityEngine;

public class LinearMovemnet : MonoBehaviour
{
    [SerializeField] protected Transform[] movePoint;
    private int indexMp = 0;

    protected int getIndex()
    {
        if (Vector2.Distance(transform.position, movePoint[indexMp].position) < .01)
        {
            indexMp++;
            if (indexMp >= movePoint.Length) indexMp = 0;
        }
        return indexMp;
    }

    protected void movement(Transform target, float speed)
    {
        transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
    }
}