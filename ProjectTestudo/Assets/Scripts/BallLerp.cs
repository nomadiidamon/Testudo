using UnityEngine;
using System.Collections;

public class ObjectColorLerp : MonoBehaviour
{
    [SerializeField] public Color maxColor;
    [SerializeField] public Color currColor;
    [SerializeField] public Color minColor;

    [SerializeField] public float lerpSpeed;

    MeshRenderer rend;
    bool upwards = false;

    void Start()
    {
        rend = GetComponent<MeshRenderer>();
        if (rend != null)
        {
            maxColor = rend.material.color;
        }
        currColor = maxColor;
    }

    void Update()
    {
        if (currColor.Equals(maxColor))
        {
            currColor = Color.Lerp(currColor, minColor, lerpSpeed * Time.deltaTime);
            if (rend != null)
            {
                rend.material.color = currColor;
            }
            upwards = false;
        }
        else if (currColor.Equals(minColor))
        {
            currColor = Color.Lerp(currColor, maxColor, lerpSpeed * Time.deltaTime);
            if (rend != null)
            {
                rend.material.color = currColor;
            }
            upwards = true;
        }
        else
        {
            //if (!upwards)
            //{
            //    //currColor = Color.Lerp(currColor, minColor, lerpSpeed * Time.deltaTime);
            //    currColor = Color.Lerp(currColor, maxColor, lerpSpeed * Time.deltaTime);

            //    if (rend != null)
            //    {
            //        rend.material.color = currColor;
            //    }
            //}
            //else
            //{
            //    //currColor = Color.Lerp(currColor, maxColor, lerpSpeed * Time.deltaTime);
            //    currColor = Color.Lerp(currColor, minColor, lerpSpeed * Time.deltaTime);

            //    if (rend != null)
            //    {
            //        rend.material.color = currColor;
            //    }
            //}
            Color

        }


    }


}
