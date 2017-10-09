using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class DrawLine : MonoBehaviour 
{
	private LineRenderer line;
	private bool isMousePressed;
	private List<Vector3> pointsList;
	private Vector3 mousePos;



	// Structure for line points
	struct myLine
	{
		public Vector3 StartPoint;
		public Vector3 EndPoint;
	};
	//	-----------------------------------	
	void Awake()
	{
		// Create line renderer component and set its property
		line = gameObject.AddComponent<LineRenderer>();
		line.material =  new Material(Shader.Find("Unlit/Color"));
        line.material.color = Color.blue;
		line.SetVertexCount(0);
		line.SetWidth(10f,10f);
		line.SetColors(Color.red, Color.red);
		///line.useWorldSpace = true;	
		isMousePressed = false;
		pointsList = new List<Vector3>();
//		renderer.material.SetTextureOffset(
	}
	//	-----------------------------------	

       public void llamar()
    {
        Debug.Log("llamaste?");
    }
	public void Dibujar (Vector3 mousePos) 
	{
        // Drawing line when mouse is moving(presses)
        // mousePos = hc.getRealsensePosition();
        //Debug.Log(mousePos);
			mousePos.z=-11;
            //mousePos.x = Screen.width - mousePos.x;
            //mousePos.y = Screen.height - mousePos.y+200;
			if (!pointsList.Contains (mousePos)) 
			{
				pointsList.Add (mousePos);
				line.SetVertexCount (pointsList.Count);
				line.SetPosition (pointsList.Count - 1, (Vector3)pointsList [pointsList.Count - 1]);
				//if(isLineCollide())
				//{
				//	isMousePressed = false;
				//	line.SetColors(Color.red, Color.red);
				//}
			}
		
	}

    public void Redo()
    {
        // If mouse button down, remove old line and set its color to green
            isMousePressed = true;
            line.SetVertexCount(0);
            pointsList.RemoveRange(0, pointsList.Count);
            line.SetColors(Color.green, Color.green);
        
    }

    public void mouseExit()
    {
       
            isMousePressed = false;
        
    }
}