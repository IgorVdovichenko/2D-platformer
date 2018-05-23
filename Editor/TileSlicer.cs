using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class TileSlicer : AssetPostprocessor
{
	string directory = "/tiles/";
	int spriteSize = 16;
	int padding = 1;
	int offset = 1;

	Vector2 tilePivot= new Vector2(0.5f, 0.5f);
	int tileAlignment = 9;

	void OnPreprocessTexture()
    {
        if(IsInDirectory(directory))
        {
			SetTextureImportSettings();
        }
    }

	bool IsInDirectory(string directory)
	{
		string lowerCaseAssetPath = assetPath.ToLower();
		return lowerCaseAssetPath.IndexOf(directory) != -1;
	}

    private void SetTextureImportSettings()
    {
        TextureImporter textureImporter = (TextureImporter)assetImporter;
        textureImporter.spriteImportMode = SpriteImportMode.Multiple;
        textureImporter.filterMode = FilterMode.Point;
        textureImporter.spritePixelsPerUnit = spriteSize;
        textureImporter.isReadable = true;
    }

    void OnPostprocessTexture(Texture2D texture)
    {
        if (IsInDirectory(directory))
		{
			TextureImporter textureImporter = (TextureImporter)assetImporter;
			List<SpriteMetaData> spriteSheet = GetTiles(texture, textureImporter);
			textureImporter.spritesheet = spriteSheet.ToArray();
		}
	}

	private List<SpriteMetaData> GetTiles(Texture2D texture, TextureImporter textureImporter)
	{
		List<SpriteMetaData> spriteSheet = new List<SpriteMetaData>();
		int counter = 0;
		for (int i = offset; i < texture.width; i += spriteSize + padding)
		{
			for (int j = offset; j < texture.height; j += spriteSize + padding)
			{
				SpriteMetaData newTile = new SpriteMetaData();
				counter++;

				newTile.pivot = tilePivot;
				newTile.alignment = tileAlignment;
				newTile.rect = new Rect(i, j, spriteSize, spriteSize);
				newTile.name = textureImporter.name + counter.ToString();

				spriteSheet.Add(newTile);
			}
		}
		return spriteSheet;
	}
}
