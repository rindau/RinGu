using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class coinMovement : MonoBehaviour
{
    private Rigidbody2D rb2d;
    private Vector2 _newposition;

    // Start is called before the first frame update
    void Start()
    {
        _newposition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        _newposition = transform.position;
        _newposition.x += Mathf.Sin(Time.time) * Time.deltaTime * 1.5f;
        transform.position = _newposition;
    }
}
