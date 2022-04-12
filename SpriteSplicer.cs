using UnityEngine;

namespace Assets.Scripts.Libraries.UnityHelpers
{
    public static class SpriteSplicer
    {
        /// <summary>
        /// Splices a sprite into multiple sprites, returns a new empty gameobject that contains the spliced sprites as children.
        /// </summary>
        /// <param name="sprite">The sprite to be sliced.</param>
        /// <param name="splices">The amount of slices.</param>
        /// <param name="position">Optional, sets the position of the parent container.</param>
        /// <param name="scale">Optional, sets the scale of the parent container.</param>
        /// <param name="rotation">Optional, sets the rotation of the parent container.</param>
        /// <returns>GameObject containing sprite slices as child gameobjects.</returns>
        public static GameObject Splice(Sprite sprite, int splices, Vector3? position = null, Vector3? scale = null, Quaternion? rotation = null)
        {
            var texture = sprite.texture;
            var spliceParent = new GameObject("Splices");
            var spliceSizeX = texture.width / splices;
            var spliceSizeY = texture.height / splices;

            float split = 1f / splices;
            float prevValueX = -(split * (splices / 2f)) + (split / 2f);
            for (int i = 0; i < splices; i++)
            {
                float prevValueY = -(split * (splices / 2f)) + (split / 2f);
                if (i != 0)
                    prevValueX += split;
                for (int j = 0; j < splices; j++)
                {
                    if (j != 0)
                        prevValueY += split;
                    Sprite newSprite = Sprite.Create(texture, new Rect(i * spliceSizeX, j * spliceSizeY, spliceSizeX, spliceSizeY), new Vector2(0.5f, 0.5f), sprite.pixelsPerUnit);
                    GameObject n = new();
                    SpriteRenderer sr = n.AddComponent<SpriteRenderer>();
                    sr.sprite = newSprite;
                    n.transform.parent = spliceParent.transform;
                    n.transform.localRotation = Quaternion.identity;
                    n.transform.localPosition = new Vector3(prevValueX, prevValueY, 0);
                }
            }

            // Set transform settings
            if (position != null)
                spliceParent.transform.position = position.Value;
            if (scale != null)
                spliceParent.transform.localScale = scale.Value;
            if (rotation != null)
                spliceParent.transform.rotation = rotation.Value;

            return spliceParent;
        }
    }
}
