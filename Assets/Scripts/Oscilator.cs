using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Oscilator : MonoBehaviour
{

    Vector3 startingPostion;
    [SerializeField] Vector3 movementVector;
    float movementFactor;
    [SerializeField] float period = 5f;

    // Start is called before the first frame update
    void Start()
    {
        startingPostion = this.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        float cycles = Time.time / period;
        const float tau = Mathf.PI * 2;

        float rawSineWave = Mathf.Sin(cycles * tau);
        movementFactor = (rawSineWave + 1f) / 2;

        Vector3 offset = movementVector * movementFactor;
        this.transform.position = startingPostion + offset;
        
    }
}
