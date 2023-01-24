using System;
using System.Data;

namespace BASICA
{
    public class Json : IJson
    {
        string Q = "\"";
        public string json(DataRow Dr)
        {
            string Json = "{";
            foreach (DataColumn Dc in Dr.Table.Columns)
            {
                if(Dc.ColumnName != "FechaNac" && Dc.ColumnName != "Password")
                {
                     Json += Q + Dc.ColumnName + Q + ":" + Q + Dr[Dc.ColumnName] + Q + ",";
                }
                else if (Dc.ColumnName == "FechaNac")
                {
                    DateTime date = (DateTime)Dr[Dc.ColumnName];
                    Json += Q + Dc.ColumnName + Q + ":" + Q + date.Year + "-"+ date.Month +"-"+date.Day + Q + ",";
                }
            }
            Json = Json.Remove(Json.Length - 1) + "}";
            return Json;
        }

        public string addObject(string parent, string name, string value)
        {
            string Sufix = "";
            if (parent.StartsWith("{"))
                Sufix = "}"; 
            if (!value.StartsWith("[") && !value.StartsWith("{"))
                value = Q + value + Q;
            if (parent.StartsWith("["))
                Sufix = "]"; 
            name =  Q + name + Q + ":" + value + Sufix;
            if (parent != "{}" && parent != "[]") name = "," + name;
            return parent.Remove(parent.Length - 1) + name;
        }
    }
}
