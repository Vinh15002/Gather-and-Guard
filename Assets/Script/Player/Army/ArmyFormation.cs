using NUnit.Framework;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;


public class ArmyFormation
{


    public static List<Vector3> Horizontal(int amount)
    {
        List<Vector3> result = new List<Vector3>();
        result.Add(Vector3.zero);

        int index = 1;

        for(int i = 1; i< amount; i++)
        {
            result.Add(new Vector3(index, 0, 0));
          
            if (index > 0) index = -index;
            else
            {
                index = -index;
                index++;
            }
        }
        return result;
    }

    public static List<Vector3> Vertical(int amount)
    {
        List<Vector3> result = new List<Vector3>();
        result.Add(Vector3.zero);

        int index = 1;

        for (int i = 1; i < amount; i++)
        {
            result.Add(new Vector3(0, 0, index));
          
            if (index > 0) index = -index;
            else
            {
                index = -index;
                index++;
            }
        }
        return result;
    }


    public static List<Vector3> Triangle(int amount)
    {
    
        List<Vector3> result = new List<Vector3>();


        int h = Mathf.FloorToInt(Mathf.Sqrt(amount));
      
        if (h * h != amount) h++;
        int count = 3;
        result.Add(new Vector3(-(h-1), 0, 0));
        result.Add(new Vector3((h-1), 0, 0));
        result.Add(new Vector3(0, 0, (h-1)));

        

        for(int i = 0; i < h-1; i++)
        {
            int begin = i == 0 ? -(h - 2 - i) : -(h - 1 - i);
            int end = i == 0 ? (h - 2 - i) : (h - 1 - i);
            for(int j = begin; j <= end; j++)
            {
                result.Add(new Vector3(j, 0, i));
                count++;
                if(count > amount) break;
            }
            if (count > amount) break;
        }

        return result;
       
    }

    public static List<Vector3> Rectangle(int amount){
        List<Vector3> result = new List<Vector3>();
        int col = Mathf.CeilToInt(Mathf.Sqrt(amount));
        
        if(col%2==0){
            
        }
        else{
            result.Add(Vector3.zero);

        }


        return result;
    }

}