using UnityEngine;
using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using System.Text;

public class UnitSelectionComponent : MonoBehaviour
{
    bool isSelecting = false;
    Vector3 mousePosition1;
    public Sprite[] sprites = new Sprite[4]; //Selected sprites and not selected sprites
    

    void Update()
    {
        // If we press the left mouse button, begin selection and remember the location of the mouse
        if( Input.GetMouseButtonDown( 0 ) )
        {
            isSelecting = true;
            mousePosition1 = Input.mousePosition;

            foreach( var selectableObject in FindObjectsOfType<SelectableUnitComponent>() )
            {
                if (selectableObject.tag == "ReadTeam")
                {
                    if (selectableObject.gameObject.GetComponent<SpriteRenderer>().sprite == sprites[1])
                    {
                        selectableObject.gameObject.GetComponent<SpriteRenderer>().sprite = sprites[0];

                    }
                }
                if (selectableObject.tag == "TurquoiseTeam")
                {
                    if (selectableObject.gameObject.GetComponent<SpriteRenderer>().sprite == sprites[3])
                    {
                        selectableObject.gameObject.GetComponent<SpriteRenderer>().sprite = sprites[2];
                    }
                }

            }
        }
        // If we let go of the left mouse button, end selection
        if( Input.GetMouseButtonUp( 0 ) )
        {
            var selectedObjects = new List<SelectableUnitComponent>();
            foreach( var selectableObject in FindObjectsOfType<SelectableUnitComponent>() )
            {
                if( IsWithinSelectionBounds( selectableObject.gameObject ) )
                {
                    selectedObjects.Add( selectableObject );
                }
            }

            var sb = new StringBuilder();
            sb.AppendLine( string.Format( "Selecting [{0}] Units", selectedObjects.Count ) );
            foreach( var selectedObject in selectedObjects )
                sb.AppendLine( "-> " + selectedObject.gameObject.name );
            Debug.Log( sb.ToString() );

            isSelecting = false;
        }

        // Highlight all objects within the selection box
        if( isSelecting )
        {
            foreach( var selectableObject in FindObjectsOfType<SelectableUnitComponent>() )
            {
                if (IsWithinSelectionBounds(selectableObject.gameObject))
                {
                    if (selectableObject.tag == "ReadTeam")
                    {
                        if (selectableObject.gameObject.GetComponent<SpriteRenderer>().sprite == sprites[0])
                        {
                            selectableObject.gameObject.GetComponent<SpriteRenderer>().sprite = sprites[1];
                        }

                    }
                    if (selectableObject.tag == "TurquoiseTeam")
                    {
                        if (selectableObject.gameObject.GetComponent<SpriteRenderer>().sprite == sprites[2])
                        {
                            selectableObject.gameObject.GetComponent<SpriteRenderer>().sprite = sprites[3];
                        }
                    }
                }
                else
                {
                    if (selectableObject.tag == "ReadTeam")
                    {
                        if (selectableObject.gameObject.GetComponent<SpriteRenderer>().sprite == sprites[1])
                        {
                            selectableObject.gameObject.GetComponent<SpriteRenderer>().sprite = sprites[0];

                        }
                    }
                    if (selectableObject.tag == "TurquoiseTeam")
                    {
                        if (selectableObject.gameObject.GetComponent<SpriteRenderer>().sprite == sprites[3])
                        {
                            selectableObject.gameObject.GetComponent<SpriteRenderer>().sprite = sprites[2];
                        }
                    }
                }
            }
        }
    }

    public bool IsWithinSelectionBounds( GameObject gameObject )
    {
        if( !isSelecting )
            return false;

        var camera = Camera.main;
        var viewportBounds = Utils.GetViewportBounds( camera, mousePosition1, Input.mousePosition );
        return viewportBounds.Contains( camera.WorldToViewportPoint( gameObject.transform.position ) );
    }

    void OnGUI()
    {
        if( isSelecting )
        {
            // Create a rect from both mouse positions
            var rect = Utils.GetScreenRect( mousePosition1, Input.mousePosition );
            Utils.DrawScreenRect( rect, new Color( 0.8f, 0.8f, 0.95f, 0.25f ) );
            Utils.DrawScreenRectBorder( rect, 2, new Color( 0.8f, 0.8f, 0.95f ) );
        }
    }
}