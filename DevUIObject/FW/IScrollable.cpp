#include "IScrollable.h"



IScrollable::IScrollable()
{
	active = 0;
	total = 0;
	circle = false;
}


IScrollable::~IScrollable()
{

}

void IScrollable::SetActive(int value)
{
	if (value + 1 < total)
	{
		active = value;
	}
}

int IScrollable::GetActive()
{
	return active;
}

void IScrollable::SetTotal(int value)
{
	if (value < active + 1)
	{
		active = 0;
	}
	total = value;
}

int IScrollable::GetTotal()
{
	return total;
}

void IScrollable::EnableCircle(bool enable)
{
	circle = enable;
}

void IScrollable::SetRatio(int active, int total)
{
	if (active < total)
	{
		this->active = active;
		this->total = total;
	}
}

void IScrollable::OnScrollDec()
{
	if (active)
	{
		active--;
	}
	else
	{
		if (circle)
		{
			active = total - 1;
		}
	}
}

void IScrollable::OnScrollInc()
{
	if (active < total)
	{
		active++;
	}
	else
	{
		active = 0;
	}
}
