using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Puzzle1 : InteractBase
{
	public bool[] HasActivated;
	public int[] Order;
	public GameObject[] Barriers;
	private int Loc = 0;
    private bool HasToReset = false;
	
	public override void SendIntInfo(int NumberRecived) 
	{
		if (Loc <= HasActivated.Length) {
		    for (int i = 0; i < HasActivated.Length; i++) {
		        if (!HasActivated[i]) 
		        {
                    if (Order[Loc] == NumberRecived) 
				    {
			    		Barriers[i].GetComponent<PlataformCreate>().Activate();
			    		HasActivated[i] = true;
                        Loc++;
                        HasToReset = false;
                        break;
			    	}
                    HasToReset = true;
		        }
		    }
            if (HasToReset)
            {
                for (int r = 0; r < HasActivated.Length; r++)
                {
                    if (HasActivated[r])
                    {
                        Barriers[r].GetComponent<PlataformCreate>().Activate();
                        HasActivated[r] = false;
                        Loc = 0;
                        HasToReset = false;
                    }
                }
            }
        }
	}
}
