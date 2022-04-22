using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorControls : MonoBehaviour
{
    private PlayerInputMap controls;

    public Camera mainCamera;

    //Passive Cursor state
    public Texture2D cursor;

    //Cursor State once clicked
    public Texture2D cursorClicked;

    // Start is called before the first frame update
    void Awake()
    {
        controls = new PlayerInputMap();
        ChangedCursor(cursor);
    }

    private void OnEnable()
    {
        controls.Enable();
    }
    private void OnDisable()
    {
        controls.Disable();
    }

    private void ChangedCursor(Texture2D cursorType)
    {
        //by changing the hotspot you can change what part of the cursor is used for clickcing (the tip, center etc...)
        //Vector2 hotspot = new Vector2(cursorType.width..., cursorType.height...);
        Cursor.SetCursor(cursorType, Vector2.zero, CursorMode.Auto);
    }
    private void Start()
    {
        controls.PlayerControls.Leftclick.started += _ => StartedClick();
        controls.PlayerControls.Leftclick.performed += _ => EndedClick();
    }
    private void StartedClick()
    {
        //When Cursor is clicked it will change to on click cursor 
        ChangedCursor(cursorClicked);
    }

    private void EndedClick()
    {
        //Once Click has ended it will return back to the games default cursor
        ChangedCursor(cursor);
        DetectObject();
    }

    //Checks if the items being interacted with is clickable
    private void DetectObject()
    {
        //creates a raycast from the camera to the mouses current position
        Ray ray = mainCamera.ScreenPointToRay(controls.PlayerControls.MousePos.ReadValue<Vector2>());
        RaycastHit2D hit2D = Physics2D.GetRayIntersection(ray);
        //Checks if a collider has been hit and will carry on functions
        if (hit2D.collider != null)
        {
            //stores the clicked input into click.
            IClick click = hit2D.collider.gameObject.GetComponent<IClick>();
            // click isnt null will preform the onClick action which will have an operation dependant on the object clicked.
            if (click != null) 
                click.onClickAction();
            Debug.Log("Hit:" + hit2D.collider.tag);
        }

    }

}
