////////////////////////////////////////////////////////////////////////////////
//
//  SvgPaint.cs - This file is part of Svg2Xaml.
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
using System.Globalization;
using System.Windows.Media;

namespace Svg2Xaml
{

  //****************************************************************************
  abstract class SvgPaint
  {

    //==========================================================================
    public static SvgPaint Parse(string value)
    {
      if(value == null)
        throw new ArgumentNullException("value");
      
      value = value.Trim();
      if(value == "")
        throw new ArgumentException("value must not be empty", "value");

      if(value.StartsWith("url"))
      {
        string url = value.Substring(3).Trim();
        if(url.StartsWith("(") && url.EndsWith(")"))
        {
          url = url.Substring(1, url.Length - 2).Trim();
          if(url.StartsWith("#"))
            return new SvgUrlPaint(url.Substring(1).Trim());
        }
      }

			value = value.ToLowerInvariant();

      if(value.StartsWith("#"))
      {
        string color = value.Substring(1).Trim();
        if(color.Length == 3)
        {
          byte r = Byte.Parse(String.Format("{0}{0}", color[0]), NumberStyles.HexNumber);
          byte g = Byte.Parse(String.Format("{0}{0}", color[1]), NumberStyles.HexNumber);
          byte b = Byte.Parse(String.Format("{0}{0}", color[2]), NumberStyles.HexNumber);
          return new SvgColorPaint(new SvgColor(r, g, b));
        }

        if(color.Length == 6)
        {
          byte r = Byte.Parse(color.Substring(0,2), NumberStyles.HexNumber);
          byte g = Byte.Parse(color.Substring(2, 2), NumberStyles.HexNumber);
          byte b = Byte.Parse(color.Substring(4, 2), NumberStyles.HexNumber);
          return new SvgColorPaint(new SvgColor(r, g, b));
        }
      }

      if(value.StartsWith("rgb"))
      {
        string color = value.Substring(3).Trim();
        if(color.StartsWith("(") && color.EndsWith(")"))
        {
          color = color.Substring(1, color.Length - 2).Trim();

          string[] components = color.Split(',');
          if(components.Length == 3)
          {
            float r,g,b;

            components[0] = components[0].Trim();
            if(components[0].EndsWith("%"))
            {
              components[0] = components[0].Substring(0, components[0].Length - 1).Trim();
              r = Single.Parse(components[0], CultureInfo.InvariantCulture.NumberFormat) / 100;
            }
            else
              r = (float)(Byte.Parse(components[0]) / 255.0);

            components[1] = components[1].Trim();
            if(components[1].EndsWith("%"))
            {
              components[1] = components[1].Substring(0, components[1].Length - 1).Trim();
              g = Single.Parse(components[1], CultureInfo.InvariantCulture.NumberFormat) / 100;
            }
            else
              g = (float)(Byte.Parse(components[1]) / 255.0);

            components[2] = components[1].Trim();
            if(components[2].EndsWith("%"))
            {
              components[2] = components[2].Substring(0, components[2].Length - 1).Trim();
              b = Single.Parse(components[2], CultureInfo.InvariantCulture.NumberFormat) / 100;
            }
            else
              b = (float)(Byte.Parse(components[2]) / 255.0);

            return new SvgColorPaint(new SvgColor(r, g, b));
          }
        }
      }

      if(value == "none")
        return null;


      switch(value)
      {
				case "aliceblue": return new SvgColorPaint(new SvgColor(240 / 255.0f, 248 / 255.0f, 255 / 255.0f));
				case "antiquewhite": return new SvgColorPaint(new SvgColor(250 / 255.0f, 235 / 255.0f, 215 / 255.0f));
				case "aqua": return new SvgColorPaint(new SvgColor(0 / 255.0f, 255 / 255.0f, 255 / 255.0f));
				case "aquamarine": return new SvgColorPaint(new SvgColor(127 / 255.0f, 255 / 255.0f, 212 / 255.0f));
				case "azure": return new SvgColorPaint(new SvgColor(240 / 255.0f, 255 / 255.0f, 255 / 255.0f));
				case "beige": return new SvgColorPaint(new SvgColor(245 / 255.0f, 245 / 255.0f, 220 / 255.0f));
				case "bisque": return new SvgColorPaint(new SvgColor(255 / 255.0f, 228 / 255.0f, 196 / 255.0f));
				case "black": return new SvgColorPaint(new SvgColor(0 / 255.0f, 0 / 255.0f, 0 / 255.0f));
				case "blanchedalmond": return new SvgColorPaint(new SvgColor(255 / 255.0f, 235 / 255.0f, 205 / 255.0f));
				case "blue": return new SvgColorPaint(new SvgColor(0 / 255.0f, 0 / 255.0f, 255 / 255.0f));
				case "blueviolet": return new SvgColorPaint(new SvgColor(138 / 255.0f, 43 / 255.0f, 226 / 255.0f));
				case "brown": return new SvgColorPaint(new SvgColor(165 / 255.0f, 42 / 255.0f, 42 / 255.0f));
				case "burlywood": return new SvgColorPaint(new SvgColor(222 / 255.0f, 184 / 255.0f, 135 / 255.0f));
				case "cadetblue": return new SvgColorPaint(new SvgColor(95 / 255.0f, 158 / 255.0f, 160 / 255.0f));
				case "chartreuse": return new SvgColorPaint(new SvgColor(127 / 255.0f, 255 / 255.0f, 0 / 255.0f));
				case "chocolate": return new SvgColorPaint(new SvgColor(210 / 255.0f, 105 / 255.0f, 30 / 255.0f));
				case "coral": return new SvgColorPaint(new SvgColor(255 / 255.0f, 127 / 255.0f, 80 / 255.0f));
				case "cornflowerblue": return new SvgColorPaint(new SvgColor(100 / 255.0f, 149 / 255.0f, 237 / 255.0f));
				case "cornsilk": return new SvgColorPaint(new SvgColor(255 / 255.0f, 248 / 255.0f, 220 / 255.0f));
				case "crimson": return new SvgColorPaint(new SvgColor(220 / 255.0f, 20 / 255.0f, 60 / 255.0f));
				case "cyan": return new SvgColorPaint(new SvgColor(0 / 255.0f, 255 / 255.0f, 255 / 255.0f));
				case "darkblue": return new SvgColorPaint(new SvgColor(0 / 255.0f, 0 / 255.0f, 139 / 255.0f));
				case "darkcyan": return new SvgColorPaint(new SvgColor(0 / 255.0f, 139 / 255.0f, 139 / 255.0f));
				case "darkgoldenrod": return new SvgColorPaint(new SvgColor(184 / 255.0f, 134 / 255.0f, 11 / 255.0f));
				case "darkgray": return new SvgColorPaint(new SvgColor(169 / 255.0f, 169 / 255.0f, 169 / 255.0f));
				case "darkgreen": return new SvgColorPaint(new SvgColor(0 / 255.0f, 100 / 255.0f, 0 / 255.0f));
				case "darkgrey": return new SvgColorPaint(new SvgColor(169 / 255.0f, 169 / 255.0f, 169 / 255.0f));
				case "darkkhaki": return new SvgColorPaint(new SvgColor(189 / 255.0f, 183 / 255.0f, 107 / 255.0f));
				case "darkmagenta": return new SvgColorPaint(new SvgColor(139 / 255.0f, 0 / 255.0f, 139 / 255.0f));
				case "darkolivegreen": return new SvgColorPaint(new SvgColor(85 / 255.0f, 107 / 255.0f, 47 / 255.0f));
				case "darkorange": return new SvgColorPaint(new SvgColor(255 / 255.0f, 140 / 255.0f, 0 / 255.0f));
				case "darkorchid": return new SvgColorPaint(new SvgColor(153 / 255.0f, 50 / 255.0f, 204 / 255.0f));
				case "darkred": return new SvgColorPaint(new SvgColor(139 / 255.0f, 0 / 255.0f, 0 / 255.0f));
				case "darksalmon": return new SvgColorPaint(new SvgColor(233 / 255.0f, 150 / 255.0f, 122 / 255.0f));
				case "darkseagreen": return new SvgColorPaint(new SvgColor(143 / 255.0f, 188 / 255.0f, 143 / 255.0f));
				case "darkslateblue": return new SvgColorPaint(new SvgColor(72 / 255.0f, 61 / 255.0f, 139 / 255.0f));
				case "darkslategray": return new SvgColorPaint(new SvgColor(47 / 255.0f, 79 / 255.0f, 79 / 255.0f));
				case "darkslategrey": return new SvgColorPaint(new SvgColor(47 / 255.0f, 79 / 255.0f, 79 / 255.0f));
				case "darkturquoise": return new SvgColorPaint(new SvgColor(0 / 255.0f, 206 / 255.0f, 209 / 255.0f));
				case "darkviolet": return new SvgColorPaint(new SvgColor(148 / 255.0f, 0 / 255.0f, 211 / 255.0f));
				case "deeppink": return new SvgColorPaint(new SvgColor(255 / 255.0f, 20 / 255.0f, 147 / 255.0f));
				case "deepskyblue": return new SvgColorPaint(new SvgColor(0 / 255.0f, 191 / 255.0f, 255 / 255.0f));
				case "dimgray": return new SvgColorPaint(new SvgColor(105 / 255.0f, 105 / 255.0f, 105 / 255.0f));
				case "dimgrey": return new SvgColorPaint(new SvgColor(105 / 255.0f, 105 / 255.0f, 105 / 255.0f));
				case "dodgerblue": return new SvgColorPaint(new SvgColor(30 / 255.0f, 144 / 255.0f, 255 / 255.0f));
				case "firebrick": return new SvgColorPaint(new SvgColor(178 / 255.0f, 34 / 255.0f, 34 / 255.0f));
				case "floralwhite": return new SvgColorPaint(new SvgColor(255 / 255.0f, 250 / 255.0f, 240 / 255.0f));
				case "forestgreen": return new SvgColorPaint(new SvgColor(34 / 255.0f, 139 / 255.0f, 34 / 255.0f));
				case "fuchsia": return new SvgColorPaint(new SvgColor(255 / 255.0f, 0 / 255.0f, 255 / 255.0f));
				case "gainsboro": return new SvgColorPaint(new SvgColor(220 / 255.0f, 220 / 255.0f, 220 / 255.0f));
				case "ghostwhite": return new SvgColorPaint(new SvgColor(248 / 255.0f, 248 / 255.0f, 255 / 255.0f));
				case "gold": return new SvgColorPaint(new SvgColor(255 / 255.0f, 215 / 255.0f, 0 / 255.0f));
				case "goldenrod": return new SvgColorPaint(new SvgColor(218 / 255.0f, 165 / 255.0f, 32 / 255.0f));
				case "gray": return new SvgColorPaint(new SvgColor(128 / 255.0f, 128 / 255.0f, 128 / 255.0f));
				case "grey": return new SvgColorPaint(new SvgColor(128 / 255.0f, 128 / 255.0f, 128 / 255.0f));
				case "green": return new SvgColorPaint(new SvgColor(0 / 255.0f, 128 / 255.0f, 0 / 255.0f));
				case "greenyellow": return new SvgColorPaint(new SvgColor(173 / 255.0f, 255 / 255.0f, 47 / 255.0f));
				case "honeydew": return new SvgColorPaint(new SvgColor(240 / 255.0f, 255 / 255.0f, 240 / 255.0f));
				case "hotpink": return new SvgColorPaint(new SvgColor(255 / 255.0f, 105 / 255.0f, 180 / 255.0f));
				case "indianred": return new SvgColorPaint(new SvgColor(205 / 255.0f, 92 / 255.0f, 92 / 255.0f));
				case "indigo": return new SvgColorPaint(new SvgColor(75 / 255.0f, 0 / 255.0f, 130 / 255.0f));
				case "ivory": return new SvgColorPaint(new SvgColor(255 / 255.0f, 255 / 255.0f, 240 / 255.0f));
				case "khaki": return new SvgColorPaint(new SvgColor(240 / 255.0f, 230 / 255.0f, 140 / 255.0f));
				case "lavender": return new SvgColorPaint(new SvgColor(230 / 255.0f, 230 / 255.0f, 250 / 255.0f));
				case "lavenderblush": return new SvgColorPaint(new SvgColor(255 / 255.0f, 240 / 255.0f, 245 / 255.0f));
				case "lawngreen": return new SvgColorPaint(new SvgColor(124 / 255.0f, 252 / 255.0f, 0 / 255.0f));
				case "lemonchiffon": return new SvgColorPaint(new SvgColor(255 / 255.0f, 250 / 255.0f, 205 / 255.0f));
				case "lightblue": return new SvgColorPaint(new SvgColor(173 / 255.0f, 216 / 255.0f, 230 / 255.0f));
				case "lightcoral": return new SvgColorPaint(new SvgColor(240 / 255.0f, 128 / 255.0f, 128 / 255.0f));
				case "lightcyan": return new SvgColorPaint(new SvgColor(224 / 255.0f, 255 / 255.0f, 255 / 255.0f));
				case "lightgoldenrodyellow": return new SvgColorPaint(new SvgColor(250 / 255.0f, 250 / 255.0f, 210 / 255.0f));
				case "lightgray": return new SvgColorPaint(new SvgColor(211 / 255.0f, 211 / 255.0f, 211 / 255.0f));
				case "lightgreen": return new SvgColorPaint(new SvgColor(144 / 255.0f, 238 / 255.0f, 144 / 255.0f));
				case "lightgrey": return new SvgColorPaint(new SvgColor(211 / 255.0f, 211 / 255.0f, 211 / 255.0f));
				case "lightpink": return new SvgColorPaint(new SvgColor(255 / 255.0f, 182 / 255.0f, 193 / 255.0f));
				case "lightsalmon": return new SvgColorPaint(new SvgColor(255 / 255.0f, 160 / 255.0f, 122 / 255.0f));
				case "lightseagreen": return new SvgColorPaint(new SvgColor(32 / 255.0f, 178 / 255.0f, 170 / 255.0f));
				case "lightskyblue": return new SvgColorPaint(new SvgColor(135 / 255.0f, 206 / 255.0f, 250 / 255.0f));
				case "lightslategray": return new SvgColorPaint(new SvgColor(119 / 255.0f, 136 / 255.0f, 153 / 255.0f));
				case "lightslategrey": return new SvgColorPaint(new SvgColor(119 / 255.0f, 136 / 255.0f, 153 / 255.0f));
				case "lightsteelblue": return new SvgColorPaint(new SvgColor(176 / 255.0f, 196 / 255.0f, 222 / 255.0f));
				case "lightyellow": return new SvgColorPaint(new SvgColor(255 / 255.0f, 255 / 255.0f, 224 / 255.0f));
				case "lime": return new SvgColorPaint(new SvgColor(0 / 255.0f, 255 / 255.0f, 0 / 255.0f));
				case "limegreen": return new SvgColorPaint(new SvgColor(50 / 255.0f, 205 / 255.0f, 50 / 255.0f));
				case "linen": return new SvgColorPaint(new SvgColor(250 / 255.0f, 240 / 255.0f, 230 / 255.0f));
				case "magenta": return new SvgColorPaint(new SvgColor(255 / 255.0f, 0 / 255.0f, 255 / 255.0f));
				case "maroon": return new SvgColorPaint(new SvgColor(128 / 255.0f, 0 / 255.0f, 0 / 255.0f));
				case "mediumaquamarine": return new SvgColorPaint(new SvgColor(102 / 255.0f, 205 / 255.0f, 170 / 255.0f));
				case "mediumblue": return new SvgColorPaint(new SvgColor(0 / 255.0f, 0 / 255.0f, 205 / 255.0f));
				case "mediumorchid": return new SvgColorPaint(new SvgColor(186 / 255.0f, 85 / 255.0f, 211 / 255.0f));
				case "mediumpurple": return new SvgColorPaint(new SvgColor(147 / 255.0f, 112 / 255.0f, 219 / 255.0f));
				case "mediumseagreen": return new SvgColorPaint(new SvgColor(60 / 255.0f, 179 / 255.0f, 113 / 255.0f));
				case "mediumslateblue": return new SvgColorPaint(new SvgColor(123 / 255.0f, 104 / 255.0f, 238 / 255.0f));
				case "mediumspringgreen": return new SvgColorPaint(new SvgColor(0 / 255.0f, 250 / 255.0f, 154 / 255.0f));
				case "mediumturquoise": return new SvgColorPaint(new SvgColor(72 / 255.0f, 209 / 255.0f, 204 / 255.0f));
				case "mediumvioletred": return new SvgColorPaint(new SvgColor(199 / 255.0f, 21 / 255.0f, 133 / 255.0f));
				case "midnightblue": return new SvgColorPaint(new SvgColor(25 / 255.0f, 25 / 255.0f, 112 / 255.0f));
				case "mintcream": return new SvgColorPaint(new SvgColor(245 / 255.0f, 255 / 255.0f, 250 / 255.0f));
				case "mistyrose": return new SvgColorPaint(new SvgColor(255 / 255.0f, 228 / 255.0f, 225 / 255.0f));
				case "moccasin": return new SvgColorPaint(new SvgColor(255 / 255.0f, 228 / 255.0f, 181 / 255.0f));
				case "navajowhite": return new SvgColorPaint(new SvgColor(255 / 255.0f, 222 / 255.0f, 173 / 255.0f));
				case "navy": return new SvgColorPaint(new SvgColor(0 / 255.0f, 0 / 255.0f, 128 / 255.0f));
				case "oldlace": return new SvgColorPaint(new SvgColor(253 / 255.0f, 245 / 255.0f, 230 / 255.0f));
				case "olive": return new SvgColorPaint(new SvgColor(128 / 255.0f, 128 / 255.0f, 0 / 255.0f));
				case "olivedrab": return new SvgColorPaint(new SvgColor(107 / 255.0f, 142 / 255.0f, 35 / 255.0f));
				case "orange": return new SvgColorPaint(new SvgColor(255 / 255.0f, 165 / 255.0f, 0 / 255.0f));
				case "orangered": return new SvgColorPaint(new SvgColor(255 / 255.0f, 69 / 255.0f, 0 / 255.0f));
				case "orchid": return new SvgColorPaint(new SvgColor(218 / 255.0f, 112 / 255.0f, 214 / 255.0f));
				case "palegoldenrod": return new SvgColorPaint(new SvgColor(238 / 255.0f, 232 / 255.0f, 170 / 255.0f));
				case "palegreen": return new SvgColorPaint(new SvgColor(152 / 255.0f, 251 / 255.0f, 152 / 255.0f));
				case "paleturquoise": return new SvgColorPaint(new SvgColor(175 / 255.0f, 238 / 255.0f, 238 / 255.0f));
				case "palevioletred": return new SvgColorPaint(new SvgColor(219 / 255.0f, 112 / 255.0f, 147 / 255.0f));
				case "papayawhip": return new SvgColorPaint(new SvgColor(255 / 255.0f, 239 / 255.0f, 213 / 255.0f));
				case "peachpuff": return new SvgColorPaint(new SvgColor(255 / 255.0f, 218 / 255.0f, 185 / 255.0f));
				case "peru": return new SvgColorPaint(new SvgColor(205 / 255.0f, 133 / 255.0f, 63 / 255.0f));
				case "pink": return new SvgColorPaint(new SvgColor(255 / 255.0f, 192 / 255.0f, 203 / 255.0f));
				case "plum": return new SvgColorPaint(new SvgColor(221 / 255.0f, 160 / 255.0f, 221 / 255.0f));
				case "powderblue": return new SvgColorPaint(new SvgColor(176 / 255.0f, 224 / 255.0f, 230 / 255.0f));
				case "purple": return new SvgColorPaint(new SvgColor(128 / 255.0f, 0 / 255.0f, 128 / 255.0f));
				case "red": return new SvgColorPaint(new SvgColor(255 / 255.0f, 0 / 255.0f, 0 / 255.0f));
				case "rosybrown": return new SvgColorPaint(new SvgColor(188 / 255.0f, 143 / 255.0f, 143 / 255.0f));
				case "royalblue": return new SvgColorPaint(new SvgColor(65 / 255.0f, 105 / 255.0f, 225 / 255.0f));
				case "saddlebrown": return new SvgColorPaint(new SvgColor(139 / 255.0f, 69 / 255.0f, 19 / 255.0f));
				case "salmon": return new SvgColorPaint(new SvgColor(250 / 255.0f, 128 / 255.0f, 114 / 255.0f));
				case "sandybrown": return new SvgColorPaint(new SvgColor(244 / 255.0f, 164 / 255.0f, 96 / 255.0f));
				case "seagreen": return new SvgColorPaint(new SvgColor(46 / 255.0f, 139 / 255.0f, 87 / 255.0f));
				case "seashell": return new SvgColorPaint(new SvgColor(255 / 255.0f, 245 / 255.0f, 238 / 255.0f));
				case "sienna": return new SvgColorPaint(new SvgColor(160 / 255.0f, 82 / 255.0f, 45 / 255.0f));
				case "silver": return new SvgColorPaint(new SvgColor(192 / 255.0f, 192 / 255.0f, 192 / 255.0f));
				case "skyblue": return new SvgColorPaint(new SvgColor(135 / 255.0f, 206 / 255.0f, 235 / 255.0f));
				case "slateblue": return new SvgColorPaint(new SvgColor(106 / 255.0f, 90 / 255.0f, 205 / 255.0f));
				case "slategray": return new SvgColorPaint(new SvgColor(112 / 255.0f, 128 / 255.0f, 144 / 255.0f));
				case "slategrey": return new SvgColorPaint(new SvgColor(112 / 255.0f, 128 / 255.0f, 144 / 255.0f));
				case "snow": return new SvgColorPaint(new SvgColor(255 / 255.0f, 250 / 255.0f, 250 / 255.0f));
				case "springgreen": return new SvgColorPaint(new SvgColor(0 / 255.0f, 255 / 255.0f, 127 / 255.0f));
				case "steelblue": return new SvgColorPaint(new SvgColor(70 / 255.0f, 130 / 255.0f, 180 / 255.0f));
				case "tan": return new SvgColorPaint(new SvgColor(210 / 255.0f, 180 / 255.0f, 140 / 255.0f));
				case "teal": return new SvgColorPaint(new SvgColor(0 / 255.0f, 128 / 255.0f, 128 / 255.0f));
				case "thistle": return new SvgColorPaint(new SvgColor(216 / 255.0f, 191 / 255.0f, 216 / 255.0f));
				case "tomato": return new SvgColorPaint(new SvgColor(255 / 255.0f, 99 / 255.0f, 71 / 255.0f));
				case "turquoise": return new SvgColorPaint(new SvgColor(64 / 255.0f, 224 / 255.0f, 208 / 255.0f));
				case "violet": return new SvgColorPaint(new SvgColor(238 / 255.0f, 130 / 255.0f, 238 / 255.0f));
				case "wheat": return new SvgColorPaint(new SvgColor(245 / 255.0f, 222 / 255.0f, 179 / 255.0f));
				case "white": return new SvgColorPaint(new SvgColor(255 / 255.0f, 255 / 255.0f, 255 / 255.0f));
				case "whitesmoke": return new SvgColorPaint(new SvgColor(245 / 255.0f, 245 / 255.0f, 245 / 255.0f));
				case "yellow": return new SvgColorPaint(new SvgColor(255 / 255.0f, 255 / 255.0f, 0 / 255.0f));
				case "yellowgreen": return new SvgColorPaint(new SvgColor(154 / 255.0f, 205 / 255.0f, 50 / 255.0f));
      }

      throw new ArgumentException(String.Format("Unsupported paint value: {0}", value));
    }

    //==========================================================================
    public abstract Brush ToBrush(SvgBaseElement element);

  } // class SvgPaint

}
