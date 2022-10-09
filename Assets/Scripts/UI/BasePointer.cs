using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BasePointer : MonoBehaviour
{
    [SerializeField] RectTransform pointer;
    [SerializeField] float distance;

    Transform target;
    Vector2 targetPosition;

    private void Start()
    {
        try
        {
            target = GameObject.Find("Player").GetComponent<PlayerHealth>().pBase.transform;
            targetPosition = target.position;
            Color targetColor = target.GetComponent<SpriteRenderer>().color;
            pointer.gameObject.GetComponent<Image>().color = new Color(targetColor.r, targetColor.g, targetColor.b, 0.3f);
        }
        catch
        {
            Debug.Log("stal sa vec");
        }
    }
    private void Update()
    {
        Vector2 toPosition = targetPosition;
        Vector2 fromPosition = Camera.main.transform.position;
        float angle = (float)Mathf.Atan2(toPosition.y - fromPosition.y, toPosition.x - fromPosition.x) * Mathf.Rad2Deg;
        pointer.localEulerAngles = new Vector3(0, 0, angle);

        Vector2 screenPoint = Camera.main.WorldToScreenPoint(targetPosition);
        bool isOffScreen = screenPoint.x <= 0 || screenPoint.x >= Screen.width || screenPoint.y <= 0 || screenPoint.y >= Screen.height;
        if (isOffScreen)
        {
            Vector2 pointerWorldPos = Camera.main.ScreenToWorldPoint(targetPosition);
            pointer.localPosition = pointerWorldPos.normalized;
            pointer.position = (Vector2)pointer.position + new Vector2(Mathf.Cos(angle * Mathf.Deg2Rad), Mathf.Sin(angle * Mathf.Deg2Rad)) * distance;
        } else
        {
            pointer.position = new Vector2(-50,-50);
        }
    }
}
