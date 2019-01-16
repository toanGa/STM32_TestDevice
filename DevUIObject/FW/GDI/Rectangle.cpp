#include "Rectangle.h"
#include <math.h>
#include <stdlib.h>

namespace GDI
{
	Rectangle::Rectangle()
	{
		X = 0;
		Y = 0;
		Width = 0;
		Height = 0;
	}

	Rectangle::Rectangle(int x, int y, int width, int height)
	{
		this->X = x;
		this->Y = y;
		this->Width = width;
		this->Height = height;
	}

	Rectangle::Rectangle(Point location, int width, int height)
	{
		this->X = location.x;
		this->Y = location.y;	
		this->Width = width;
		this->Height = height;
	}


	Rectangle::~Rectangle()
	{
	}

	Rectangle Rectangle::FromLocation(int x1, int y1, int x2, int y2)
	{
		return Rectangle(x1, y1, abs(x1 - x2) + 1, abs(y1 - y2) + 1);
	}
}

