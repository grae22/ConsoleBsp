using System.Collections.Generic;
using System.IO;
using System.Linq;
using Newtonsoft.Json;

namespace ConsoleBsp
{
  internal class Map : IMap
  {
    //---------------------------------------------------------------------------------------------

    public IEnumerable<Line2d> Walls { get; } = new List<Line2d>();

    //---------------------------------------------------------------------------------------------

    public void LoadFromFile(string path)
    {
      string fileContent = File.ReadAllText(path);

      var walls = JsonConvert.DeserializeObject<List<Line2d>>(fileContent);

      walls.ForEach(w => Walls.Append(w));
    }

    //---------------------------------------------------------------------------------------------

    public void SaveToFile(string path)
    {
      string fileContent = JsonConvert.SerializeObject(Walls);

      File.WriteAllText(path, fileContent);
    }

    //---------------------------------------------------------------------------------------------
  }
}
