using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Healt : MonoBehaviour
{
    public float maxHealt;
    private float currentHealt;
   public HealtBar healtBar;
    
    // Start is called before the first frame update
    void Start()
    {
        currentHealt = maxHealt;
        healtBar.setMaxHealt(maxHealt);

    }

    public void getHit(float damage)
    {
        currentHealt -= damage;
        if (currentHealt <= 0)
        {
            Debug.Log("you die");
            return;
        }
        healtBar.setHealt(currentHealt);
    }

    public float getHealt()
    {
        return currentHealt;
    }
}
