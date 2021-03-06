using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Map Setting/New Mesh Setting")]
public class MeshSettings : UpdatableData
{
	public const int numSupportedLODs = 5;
	public const int numSupportedChunkSizes = 9;
	public const int numSupportedFlatshadedChunkSizes = 3;
	public static readonly int[] supportedChunkSizes = { 48, 72, 96, 120, 144, 168, 192, 216, 240 };

	public float meshScale = 2.5f;
    public bool useFlatShading;

	[Range(0, numSupportedChunkSizes - 1)]
	public int chunkSizeIndex;
	[Range(0, numSupportedFlatshadedChunkSizes - 1)]
	public int flatshadedChunkSizeIndex;
	

	/*
	Num vertices per line of mesh rendered at LOD == 0.
	Includes 2 extra vertices that are excluded from final mesh, but used for calculate Normals.
	*/
	public int numVertsPerLine
    {
        get
        {
			return supportedChunkSizes[(useFlatShading) ? flatshadedChunkSizeIndex : chunkSizeIndex] + 1;
        }
    }

	public float meshWorldSize {
		get
		{
			return (numVertsPerLine - 3) * meshScale;
		}
	}

}
