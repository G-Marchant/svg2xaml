﻿////////////////////////////////////////////////////////////////////////////////
//
//  SvgPolylineElement.cs - This file is part of Svg2Xaml.
//
//    Copyright (C) 2009,2011 Boris Richter <himself@boris-richter.net>
//
//  --------------------------------------------------------------------------
//
//  Svg2Xaml is free software: you can redistribute it and/or modify it under 
//  the terms of the GNU Lesser General Public License as published by the 
//  Free Software Foundation, either version 3 of the License, or (at your 
//  option) any later version.
//
//  Svg2Xaml is distributed in the hope that it will be useful, but WITHOUT 
//  ANY WARRANTY; without even the implied warranty of MERCHANTABILITY or 
//  FITNESS FOR A PARTICULAR PURPOSE. See the GNU Lesser General Public 
//  License for more details.
//  
//  You should have received a copy of the GNU Lesser General Public License 
//  along with Svg2Xaml. If not, see <http://www.gnu.org/licenses/>.
//
//  --------------------------------------------------------------------------
//
//  $LastChangedRevision$
//  $LastChangedDate$
//  $LastChangedBy$
//
////////////////////////////////////////////////////////////////////////////////
using System;
using System.Windows.Media;
using System.Xml.Linq;
using System.Collections.Generic;
using System.Globalization;

namespace Svg2Xaml
{
  
  //****************************************************************************
  class SvgPolylineElement
    : SvgDrawableBaseElement
  {
    //==========================================================================
    public readonly List<SvgPoint> Points = new List<SvgPoint>();

    //==========================================================================
    public SvgPolylineElement(SvgDocument document, SvgBaseElement parent, XElement polylineElement)
      : base(document, parent, polylineElement)
    {
      XAttribute points_attribute = polylineElement.Attribute("points");
      if(points_attribute != null)
      {
        List<double> coordinates = new List<double>();

        string[] points = points_attribute.Value.Split(',', ' ', '\t');
        foreach(string coordinate_value in points)
        {
          string coordinate = coordinate_value.Trim();
          if(coordinate == "")
            continue;
          coordinates.Add(Double.Parse(coordinate, CultureInfo.InvariantCulture.NumberFormat));
        }

        for(int i = 0; i < coordinates.Count - 1; i += 2)
          Points.Add(new SvgPoint(coordinates[i], coordinates[i + 1]));
      }
    }

    //==========================================================================
    public override Geometry GetBaseGeometry()
    {
      if(Points.Count == 0)
        return null;

      PathFigure path_figure = new PathFigure();

      path_figure.StartPoint = Points[0].ToPoint();
      path_figure.IsClosed = false;
      path_figure.IsFilled = false;

      for(int i = 1; i < Points.Count; ++i)
        path_figure.Segments.Add(new LineSegment(Points[i].ToPoint(), true));

      PathGeometry path_geometry = new PathGeometry();
      path_geometry.Figures.Add(path_figure);

      return path_geometry;
    }

  } // class SvgPolylineElement

}
