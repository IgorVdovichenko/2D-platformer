using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class EnemySpritesImporter : AssetPostprocessor {

    void OnPreprocessTexture()
    {
        string lowerCaseAssetPath = assetPath.ToLower();
        bool isInDirectory = lowerCaseAssetPath.IndexOf("sprites/enemies/") != -1;

        if (isInDirectory)
        {
            TextureImporter textureImporter = (TextureImporter)assetImporter;
            textureImporter.spriteImportMode = SpriteImportMode.Multiple;
            textureImporter.filterMode = FilterMode.Point;
            textureImporter.textureCompression = TextureImporterCompression.Uncompressed;
        }
    }
}
