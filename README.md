# UnitySpriteSplicer
Slices a sprite into multiple square sprites, supports positioning, rotation and scaling.

# Usage
```csharp
public void Start()
{
    var renderer = gameObject.GetComponent<SpriteRenderer>();
  
    // Spawn spliced gameobject on top of current game object
    const int slices = 4;
    var spliced = SpriteSplicer.Splice(renderer, slices, transform.position, transform.localScale, transform.rotation);

    // Destroy current gameeobject
    Destroy(gameObject);
}
```
You should see visually no difference, but your object will be sliced in a grid.
