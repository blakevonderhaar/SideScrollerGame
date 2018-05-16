	using UnityEngine;
	using System.Collections;

	public class PlayerHealth : MonoBehaviour 
	{
		GUIStyle healthStyle;
		GUIStyle backStyle;
		Combat combat;

		void Awake()
		{
			combat = GetComponent<Combat>();
		}

		void OnGUI()
		{
			InitStyles();

			// Draw a Health Bar
			Vector3 pos = Camera.main.WorldToScreenPoint(transform.position);

			// draw health bar background
			GUI.color = Color.red;
			GUI.backgroundColor = Color.red;
			GUI.Box(new Rect(pos.x-25, Screen.height - (pos.y + 35) , Combat.maxHealth/2, 7), ".", backStyle);

			// draw health bar amount
			if (combat.health >= 1) {
				GUI.color = Color.green;
				GUI.backgroundColor = Color.green;
				GUI.Box (new Rect (pos.x - 25, Screen.height - (pos.y + 34) , combat.health / 2, 5), ".", healthStyle);
			}
		}

		void InitStyles()
		{
			if( healthStyle == null )
			{
				healthStyle = new GUIStyle( GUI.skin.box );
				healthStyle.normal.background = MakeTex( 2, 2, new Color( 0f, 1f, 0f, 1.0f ) );
			}

			if( backStyle == null )
			{
				backStyle = new GUIStyle( GUI.skin.box );
			backStyle.normal.background = MakeTex( 2, 2, Color.red );
			}
		}

		Texture2D MakeTex( int width, int height, Color col )
		{
			Color[] pix = new Color[width * height];
			for( int i = 0; i < pix.Length; ++i )
			{
				pix[ i ] = col;
			}
			Texture2D result = new Texture2D( width, height );
			result.SetPixels( pix );
			result.Apply();
			return result;
		}
	}


