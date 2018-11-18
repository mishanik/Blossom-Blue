using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectionPosition : MonoBehaviour
{

    bool isSelecting = false;
    Vector3 mousePosition1;

	void Update () {
        if (Input.GetMouseButtonDown(0))
        {
            isSelecting = true;
            mousePosition1 = Input.mousePosition;
        }
        if (Input.GetMouseButtonUp(0))
        {
            isSelecting = false;
        }
	}
    void OnGUI()
    {
        if (isSelecting)
        {
            var rect = DrowSelection.Utils.GetScreenRect(mousePosition1, Input.mousePosition);
            DrowSelection.Utils.DrowScreenRect(rect, new Color(0.8f, 0.8f, 0.95f, 0.25f));
            DrowSelection.Utils.DrowScreenRectBorder(rect, 2, new Color(0.8f, 0.8f, 0.95f));
        }
    } 
    public bool IsWithinSelectionBounds( GameObject gameObject)
    {
        if (!isSelecting)
            return false;
        var camera = Camera.main;
        var viewportBounds = DrowSelection.Utils.GetViewportBounds(camera, mousePosition1, mousePosition1);

        return viewportBounds.Contains(camera.WorldToViewportPoint(gameObject.transform.position));
    }
}
