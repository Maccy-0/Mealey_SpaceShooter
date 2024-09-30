using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stars : MonoBehaviour
{
    public List<Transform> starTransforms;
    public float drawingTime;
    int currentStar;
    bool newLine;
    float waitTime;

    private void Start()
    {
        currentStar = -1;
        newLine = true;
        waitTime = drawingTime / 100;
    }
    // Update is called once per frame
    void Update()
    {
        DrawConstellation();
    }

    void DrawConstellation()
    {
        if (newLine == true)
        {
            currentStar += 1;
            if (currentStar == starTransforms.Count-1)
            {
                currentStar = 0;
            }

            newLine = false;
        }

        if(newLine == false)
        {
            StartCoroutine(line());
        }

        IEnumerator line()
        {

            if (currentStar == starTransforms.Count - 1)
            {
                for (int i = 0; i < 100; i++)
                {
                    Vector3 drawPoint2 = Vector3.Lerp(starTransforms[currentStar].position, starTransforms[0].position, i * 0.01f);
                    Debug.DrawLine(starTransforms[currentStar].position, drawPoint2, Color.green, 0.2f);
                    yield return new WaitForSeconds(waitTime);
                }
            }
            else
            {
                for (int i = 0; i < 100; i++)
                {
                    Vector3 drawPoint2 = Vector3.Lerp(starTransforms[currentStar].position, starTransforms[currentStar + 1].position, i*0.01f);
                    Debug.DrawLine(starTransforms[currentStar].position, drawPoint2, Color.green, 0.2f);
                    yield return new WaitForSeconds(waitTime);
                }
            }

            newLine = true;
            StopAllCoroutines();
            yield return null;
        }


    }

}
