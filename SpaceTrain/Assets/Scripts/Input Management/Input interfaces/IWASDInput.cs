using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IWASDInput
{
	// using a bool if you want to make a more complex input detection, such if you want to know how long a press was.
	void W_Key_Held(bool b);
	void A_Key_Held(bool b);
	void S_Key_Held(bool b);
	void D_Key_Held(bool b);
}
