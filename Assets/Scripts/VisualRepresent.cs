using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VisualRepresent : MonoBehaviour
{
    [SerializeField]
    private GameController controller;

    void Start()
    {

    }

    // it'll be called by GameLogic when field is updated
    public void UpdateRepresent()
    {
        Cell[,] field = controller.field.getField();
        Vector2Int field_size = controller.field.getFieldSize();
        foreach (GameObject o in Object.FindObjectsOfType<GameObject>())
        {
            if (o.name != "Main Camera")
                Destroy(o);
        }        
        int x = -field_size.x, y = -field_size.y;        
        ushort[] triangles = new ushort[] { 0, 1, 2, 0, 2, 3, 0, 3, 4, 0, 4, 1 };
        for (int i = 0; i < field_size.x; i++)
        {
            for(int j = 0; j < field_size.y; j++)
            {
                if (field[i, j].state == true)
                {
                    Vector2[] vertices = new Vector2[] { new Vector2(x, y), new Vector2(x - 1, y - 1), new Vector2(x - 1, y + 1), new Vector2(x + 1, y + 1), new Vector2(x + 1, y - 1) };
                    DrawPolygon2D(vertices, triangles, field[i,j].color);                    
                }
                x += 2;
            }
            x = -field_size.x;
            y += 2;
        }
    }

    void DrawPolygon2D(Vector2[] vertices, ushort[] triangles, Color color)
    {
        GameObject polygon = new GameObject(); //create a new game object
        SpriteRenderer sr = polygon.AddComponent<SpriteRenderer>(); // add a sprite renderer
        Texture2D texture = new Texture2D(3, 3); // create a texture larger than your maximum polygon size

        // create an array and fill the texture with your color
        List<Color> cols = new List<Color>();
        for (int i = 0; i < (texture.width * texture.height); i++)
            cols.Add(color);
        texture.SetPixels(cols.ToArray());
        texture.Apply();

        sr.color = color; //you can also add that color to the sprite renderer

        sr.sprite = Sprite.Create(texture, new Rect(0, 0, 2, 2), Vector2.zero, 1); //create a sprite with the texture we just created and colored in

        //convert coordinates to local space
        float lx = Mathf.Infinity, ly = Mathf.Infinity;
        foreach (Vector2 vi in vertices)
        {
            if (vi.x < lx)
                lx = vi.x;
            if (vi.y < ly)
                ly = vi.y;
        }
        Vector2[] localv = new Vector2[vertices.Length];
        for (int i = 0; i < vertices.Length; i++)
        {
            localv[i] = vertices[i] - new Vector2(lx, ly);
        }

        sr.sprite.OverrideGeometry(localv, triangles); // set the vertices and triangles

        polygon.transform.position = (Vector2)transform.InverseTransformPoint(transform.position) + new Vector2(lx, ly); // return to world space
    }
}
