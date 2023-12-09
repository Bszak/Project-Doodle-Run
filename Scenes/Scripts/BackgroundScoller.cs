using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundScroller : MonoBehaviour
{
    public float initialScrollSpeed = 1.0f;
    public float speedIncrement = 0.1f;

    private float offset;
    private Material mat;
    private bool hasStarted = false;

    // Start is called before the first frame update
    void Start()
    {
        if (!hasStarted)
        {
            mat = GetComponent<Renderer>().material;
            hasStarted = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
        offset += (Time.deltaTime * initialScrollSpeed) / 10f;
        mat.SetTextureOffset("_MainTex", new Vector2(offset, 0));

        initialScrollSpeed += speedIncrement;
    }
}
