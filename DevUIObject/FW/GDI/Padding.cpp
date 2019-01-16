#include "Padding.h"

namespace GDI
{
	Padding::Padding()
	{
	}


	Padding::~Padding()
	{
	}

	void Padding::SetHorizontal(int value)
	{
		Left = value;
		Right = value;
	}

	void Padding::SetAll(int value)
	{
		Left = value;
		Right = value;
		Top = value;
		Bottom = value;
	}
}

