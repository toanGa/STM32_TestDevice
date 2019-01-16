#pragma once
#include "Point.h"
namespace GDI
{
	class Rectangle
	{
	public:
		Rectangle();
		Rectangle(int x, int y, int width, int height);
		Rectangle(Point location, int width, int height);
		~Rectangle();

		//
		// Summary:
		//     Gets or sets the height of this System.Drawing.Rectangle structure.
		//
		// Returns:
		//     The height of this System.Drawing.Rectangle structure. The default is 0.
		int Height;
		//
		// Summary:
		//     Gets or sets the width of this System.Drawing.Rectangle structure.
		//
		// Returns:
		//     The width of this System.Drawing.Rectangle structure. The default is 0.
		int Width;
		//
		// Summary:
		//     Gets or sets the y-coordinate of the upper-left corner of this System.Drawing.Rectangle
		//     structure.
		//
		// Returns:
		//     The y-coordinate of the upper-left corner of this System.Drawing.Rectangle structure.
		//     The default is 0.
		int Y;
		//
		// Summary:
		//     Gets or sets the x-coordinate of the upper-left corner of this System.Drawing.Rectangle
		//     structure.
		//
		// Returns:
		//     The x-coordinate of the upper-left corner of this System.Drawing.Rectangle structure.
		//     The default is 0.
		int X;

		static Rectangle FromLocation(int x1, int y1, int x2, int y2);
	};
}


