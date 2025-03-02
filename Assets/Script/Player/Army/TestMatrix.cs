using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestMatrix : MonoBehaviour
{
    [SerializeField] public int n = 3;

    private Vector2[,] matrix;
    public Vector2? center = null;

    void Start()
    {
        matrix = CreateMatrix(n);
        PrintMatrix(matrix);
    }

    Vector2[,] CreateMatrix(int size)
    {
        Vector2[,] matrix = new Vector2[size, size];

        // Điền giá trị vào ma trận theo tọa độ (x, y)
        for (int x = 0; x < size; x++)
        {
            for (int y = 0; y < size; y++)
            {
                matrix[x, y] = new Vector2(x, y); // Gán giá trị Vector2 tương ứng với tọa độ
            }
        }
        ShiftCoordinates(matrix);

        return matrix;
    }

     void ShiftCoordinates(Vector2[,] matrix)
    {
        // Nếu không có tâm, chọn tâm gần nhất
        Vector2 shiftCenter = center.HasValue ? center.Value : new Vector2(n / 2, n / 2);

        for (int x = 0; x < matrix.GetLength(0); x++)
        {
            for (int y = 0; y < matrix.GetLength(1); y++)
            {
                // Chuyển tọa độ
                matrix[x, y] -= shiftCenter; // Di chuyển tâm về (0, 0)
            }
        }
    }


    void PrintMatrix(Vector2[,] matrix)
    {
        for (int i = 0; i < matrix.GetLength(0); i++)
        {
            string row = "";
            for (int j = 0; j < matrix.GetLength(1); j++)
            {
                row += "(" + matrix[i, j].x + ", " + matrix[i, j].y + ") ";
            }
            Debug.Log(row); // In ra ma trận trong console
        }
    }


}
