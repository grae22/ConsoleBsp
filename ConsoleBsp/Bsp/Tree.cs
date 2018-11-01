using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleBsp.Bsp
{
  internal class Tree
  {
    private readonly Node _rootNode;

    public Tree(in IReadOnlyList<Line2d> lines)
    {
      if (lines.Count == 0)
      {
        return;
      }

      _rootNode = new Node(lines[0]);

      BuildTree(
        _rootNode,
        lines.Skip(1));
    }

    public Line2d FindFirstIntersectingLine(in Line2d ray)
    {
      var intersectingLines = new List<Line2d>();

      FindIntersectingLinesRecursive(
        ray,
        _rootNode,
        intersectingLines);

      return intersectingLines.Any() ? intersectingLines[0] : null;
    }

    private static void BuildTree(
      in Node parent,
      in IEnumerable<Line2d> lines)
    {
      if (!lines.Any())
      {
        return;
      }

      Line2d hyperplane = parent.Hyperplane;

      var linesBehind = new List<Line2d>();
      var linesInFront = new List<Line2d>();

      foreach (var line in lines)
      {
        var classification = LineClassifier.ClassifyLineToLine(line, hyperplane);

        switch (classification)
        {
          case LineClassifier.Classification.Behind:
            linesBehind.Add(line);
            break;

          case LineClassifier.Classification.InFront:
            linesInFront.Add(line);
            break;

          case LineClassifier.Classification.Coincident:
            parent.AddLine(line);
            break;

          case LineClassifier.Classification.Spanning:
            Line2d[] newLines = line.Split(hyperplane);

            bool isLine0Behind =
              LineClassifier.ClassifyLineToLine(newLines[0], hyperplane) == LineClassifier.Classification.Behind;

            if (isLine0Behind)
            {
              linesBehind.Add(newLines[0]);
              linesInFront.Add(newLines[1]);
            }
            else
            {
              linesBehind.Add(newLines[1]);
              linesInFront.Add(newLines[0]);
            }
            break;

          default:
            throw new ArgumentException("Classification unknown.");
        }
      }

      if (linesBehind.Any())
      {
        parent.CreateNodeBehind(linesBehind[0]);

        linesBehind.RemoveAt(0);

        BuildTree(parent.NodeBehind, linesBehind);
      }

      if (linesInFront.Any())
      {
        parent.CreateNodeInFront(linesInFront[0]);

        linesInFront.RemoveAt(0);

        BuildTree(parent.NodeInFront, linesInFront);
      }
    }

    private void FindIntersectingLinesRecursive(
      in Line2d ray,
      in Node node,
      in List<Line2d> intersectingLines)
    {
      Line2d localRay = ray;

      intersectingLines
        .AddRange(
          node
            .Lines
            .Where(l => LineClassifier.ClassifyLineToLine(localRay, l) == LineClassifier.Classification.Spanning));

      if (node.NodeBehind == null)
      {
        return;
      }
      
      FindIntersectingLinesRecursive(
        ray,
        node.NodeBehind,
        intersectingLines);
    }
  }
}
