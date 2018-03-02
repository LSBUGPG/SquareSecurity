using UnityEngine;

public class SetColour : MonoBehaviour {

	public string type;
    public Renderer renderer;
    public Material originalMaterial;

	void Awake()
	{
		renderer = GetComponent<Renderer> ();
        originalMaterial = renderer.material;
	}

    public void ChangeColour(string type, Material material)
	{
		if (this.type == type) {
            originalMaterial = material;
			renderer.material = new Material(originalMaterial);
		}
	}

    public void DarkenColour(bool apply)
    {
        if (apply)
        {
            Material material = new Material(originalMaterial);
            material.color = Color.Lerp(material.color, Color.black, 0.9f);
            renderer.material = material;
        }
        else
        {
            renderer.material = new Material(originalMaterial);
        }
    }
}
