using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerReload : MonoBehaviour {
    public GameObject target;
    public RectTransform canvasRect;
    public Transform ring;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
        float offsetPosY = target.transform.position.y + 1.5f;

        Vector3 offsetPos = new Vector3(target.transform.position.x, offsetPosY, target.transform.position.z);
        Vector2 canvasPos;
        Vector2 screenPoint = Camera.main.WorldToScreenPoint(offsetPos);
        RectTransformUtility.ScreenPointToLocalPointInRectangle(canvasRect, screenPoint, null, out canvasPos);

        ring.localPosition = canvasPos;

    }
}
