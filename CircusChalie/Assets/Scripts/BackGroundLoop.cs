using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackGroundLoop : MonoBehaviour
{
    private float width;


    private void Awake()
    {
        BoxCollider2D backgroundCollider = GetComponent<BoxCollider2D>();
        width = backgroundCollider.size.x;
    }

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x <= -width * 6)
        {
            Reposition();
        }
    }

    private void Reposition()
    {
        Vector2 offset = new Vector2(width * 24.03f, 0f);

        transform.position = transform.position.AddVector(offset);
    }
}
