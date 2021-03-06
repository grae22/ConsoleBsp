﻿using System.Collections.Generic;

namespace ConsoleBsp
{
  internal interface IMap
  {
    //---------------------------------------------------------------------------------------------

    IEnumerable<Line2d> Walls { get; }

    //---------------------------------------------------------------------------------------------

    void LoadFromFile(string path);
    void SaveToFile(string path);

    //---------------------------------------------------------------------------------------------
  }
}