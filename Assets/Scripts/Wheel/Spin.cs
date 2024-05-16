using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Spin : MonoBehaviour
{
    public int numberOfGitfs = 9;
    public float timeRotate;
    public float numberCircleRotate;

    private const float circle = 360.0f;
    private float angleOfGift;

    public Transform parrent;
    private float currentTime;

    public AnimationCurve curve;
    private void Start()
    {
        angleOfGift = circle / numberOfGitfs;
        SetPositionData();
    }

    IEnumerator RotateWheel()
    {
        float starAngle = transform.eulerAngles.z;
        currentTime = 0;
        int indexGitRandom = Random.Range(1, numberOfGitfs);
        Debug.Log(indexGitRandom);

        float angleWant = (numberCircleRotate * circle) + angleOfGift * indexGitRandom - starAngle;

        while (currentTime < timeRotate) 
        {
            yield return new WaitForEndOfFrame();
            currentTime += Time.deltaTime;

            float angleCurrent = angleWant * curve.Evaluate(currentTime / timeRotate);
            this.transform.eulerAngles = new Vector3(0, 0, angleCurrent + starAngle);
        }
    }

    [ContextMenu("Rotate")]
    void RotateNow()
    {
        StartCoroutine(RotateWheel());
    }

    void SetPositionData()
    {
        for (int i = 0; i < parrent.childCount; i++)
        {
            parrent.GetChild(i).eulerAngles = new Vector3(0, 0, -circle/numberOfGitfs * i);
            parrent.GetChild(i).GetChild(0).GetComponent<TextMeshProUGUI>().text = (i+1) .ToString();
        }
    }
}
