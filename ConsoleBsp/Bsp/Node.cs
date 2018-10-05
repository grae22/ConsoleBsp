using System;
using System.Collections.Generic;

namespace ConsoleBsp.Bsp
{
  internal class Node
  {
    public IReadOnlyList<Line2d> Lines => _lines.AsReadOnly();

    public Node NodeBehind { get; private set; }
    public Node NodeInFront { get; private set; }
  
    private readonly List<Line2d> _lines = new List<Line2d>();

    public Node(in Line2d hyperplane)
    {
      AddLine(hyperplane);
    }

    public void AddLine(in Line2d line)
    {
      if (line == null)
      {
        throw new ArgumentNullException(nameof(line));
      }

      _lines.Add(line);
    }

    public void CreateNodeBehind(Line2d hyperplane)
    {
      if (NodeBehind != null)
      {
        throw new Exception("Node-behind already exists.");
      }

      NodeBehind = new Node(hyperplane);
    }

    public void CreateNodeInFront(Line2d hyperplane)
    {
      if (NodeInFront != null)
      {
        throw new Exception("Node-in-front already exists.");
      }

      NodeInFront = new Node(hyperplane);
    }
  }
}
