using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseGridSelect : MonoBehaviour
{
    public Grid mainGrid;
    public LayerMask floorLayer;
    public GameObject GridCellHighlight;

    Transform cellHighlight;
    Camera camera;
    // Start is called before the first frame update
    void Start()
    {
        cellHighlight = Instantiate(GridCellHighlight).transform;
        camera = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit hit;
        Ray ray = camera.ScreenPointToRay(Input.mousePosition);

        if(Physics.Raycast(ray, out hit))
        {
            
            cellHighlight.position = mainGrid.GetCellCenterLocal(mainGrid.WorldToCell(hit.point));
        }
        cellHighlight.transform.position = new Vector3(cellHighlight.position.x, 0.04f, cellHighlight.position.z);
    }
}
