using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IndicatorControl : MonoBehaviour
{

    public GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.position =(Vector2)player.transform.position + new Vector2(0, 1.3f);
    }
}
