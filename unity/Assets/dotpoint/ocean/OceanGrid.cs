using UnityEngine;
using System.Collections;

public class OceanGrid
{

	/**
	 * grid / patch table of ocean game objects
	 */
	public GameObject[,] oceanPatches;

	/**
	 * single ocean patch which is tiled several times
	 */
	public Mesh mesh;

	/**
	 * 
	 */
	public Material material;

	/**
	 * original position
	 */
	public Vector2[] positions;

	// ************************************************************************ //
	// Constructor
	// ************************************************************************ //	
	
	/**
	 * 
	 */
	public OceanGrid( int numX, int numY, int size, OceanParams settings ) 
	{		
		this.oceanPatches = new GameObject[ numX, numY ];

		this.mesh 			= this.createMesh( size );

		this.material 		= settings.material != null ? settings.material : new Material( Shader.Find("Ocean/Ocean") );

		// ------------ //

		this.createPatches( numX, numY, size, settings );
		this.updatePositions( size, settings );
	}

	// ************************************************************************ //
	// Constructor
	// ************************************************************************ //	

	/**
	 * 
	 */
	private void createPatches( int numX, int numY, int size, OceanParams settings )
	{
		for(int x = 0; x < numX; x++)
		{
			for(int y = 0; y < numY; y++)
			{
				GameObject patch = new GameObject( "OceanPatch_ " + x + "_" + y );
				
				patch.AddComponent<MeshFilter>();
				patch.AddComponent<MeshRenderer>();
				
				// ------------------- //
				
				patch.GetComponent<MeshFilter>().mesh 	= this.mesh;
				patch.renderer.material 				= this.material;
				
				// ------------------- //
				
				Vector3 tranform = new Vector3();
				tranform.x = x * settings.L - numX * settings.L/2;
				tranform.z = y * settings.L - numY * settings.L/2;
				
				patch.transform.Translate( tranform );
				
				// ------------------- //
				
				this.oceanPatches[x,y] = patch;
			}
		}
	}

	/**
	 * 
	 */
	private Mesh createMesh( int size ) 
	{
		
		Vector3[] vertices 	= new Vector3[size*size];
		Vector2[] texcoords = new Vector2[size*size];
		Vector3[] normals 	= new Vector3[size*size];
		
		int[] indices = new int[size*size*6];
		
		// ---------------- //
		// vertices:
		
		float w = (float)(size-1);
		float h = (float)(size-1);
		
		for(int x = 0; x < size; x++)
		{
			for(int y = 0; y < size; y++)
			{
				float xp = (float)x;
				float yp = (float)y;				
				
				int index = x + y * size;
				
				texcoords[index] 	= new Vector3( xp / w, yp / h );
				vertices[index] 	= new Vector3( xp, 0.0f, yp );
				normals[index] 		= new Vector3( 0.0f, 1.0f, 0.0f );
			}
		}
		
		// ---------------- //
		// indices:
		
		int num = 0;
		
		for(int x = 0; x < size-1; x++)
		{
			for(int y = 0; y < size-1; y++)
			{
				/*
				indices[num++] = x + y * size;
				indices[num++] = x + (y+1) * size;
				indices[num++] = (x+1) + y * size;
				
				indices[num++] = x + (y+1) * size;
				indices[num++] = (x+1) + (y+1) * size;
				indices[num++] = (x+1) + y * size;
				*/

				indices[num++] = (x+1) + y * size;
				indices[num++] = (x+1) + (y+1) * size;
				indices[num++] = x + (y+1) * size;

				indices[num++] = (x+1) + y * size;
				indices[num++] = x + (y+1) * size;
				indices[num++] = x + y * size;
			}
		}
		
		// ---------------- //
		// assemble:
		
		Mesh 	mesh = new Mesh();		
				mesh.vertices 	= vertices;
				mesh.uv 		= texcoords;
				mesh.normals 	= normals;
				mesh.triangles 	= indices;
		
		return mesh;
	}

	/**
	 * 
	 */
	private void updatePositions( int size, OceanParams settings )
	{
		this.positions = new Vector2[ size * size ];

		// ----------- //

		Vector3[] vertices = this.mesh.vertices;

		for( int n = 0; n < size; n++ ) 
		{
			for( int m = 0; m < size; m++ ) 
			{
				int index = n * size + m;

				float x = n * settings.L / settings.N;
				float y = m * settings.L / settings.N;

				vertices[index].x = x;
				vertices[index].z = y;

				this.positions[index] = new Vector2( x, y ); 
			}
		}

		this.mesh.vertices = vertices;
		this.mesh.RecalculateBounds();
	}

	/**
	 * 
	 */
	void CreateFresnelLookUp()
	{
		float nSnell = 1.34f; //Refractive index of water
		
		Texture2D 	texture = new Texture2D( 512, 1, TextureFormat.Alpha8, false );
					texture.filterMode 	= FilterMode.Bilinear;
					texture.wrapMode 	= TextureWrapMode.Clamp;
					texture.anisoLevel 	= 0;

		// -------------- //

		for( int x = 0; x < 512; x++ )
		{
			float fresnel = 0.0f;

			float costhetai = (float)x / 511.0f;
			float thetai 	= Mathf.Acos( costhetai );
			float sinthetat = Mathf.Sin( thetai ) / nSnell;
			float thetat 	= Mathf.Asin( sinthetat );
			
			if( thetai == 0.0f )
			{
				fresnel = ( nSnell - 1.0f ) / ( nSnell + 1.0f );
				fresnel = fresnel * fresnel;
			}
			else
			{
				float fs = Mathf.Sin(thetat - thetai) / Mathf.Sin(thetat + thetai);
				float ts = Mathf.Tan(thetat - thetai) / Mathf.Tan(thetat + thetai);

				fresnel = 0.5f * ( fs * fs + ts * ts );
			}
			
			texture.SetPixel( x, 0, new Color( fresnel, fresnel, fresnel, fresnel ) );
		}

		// -------------- //

		texture.Apply();	

		this.material.SetTexture( "_FresnelLookUp", texture );
	}

}
