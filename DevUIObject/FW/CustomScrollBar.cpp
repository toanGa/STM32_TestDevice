#include "CustomScrollBar.h"



CustomScrollBar::CustomScrollBar()
{
	BackColor = GUI_GRAY;
	colorPointer = GUI_GREEN;
	sizePointer = 2;
}


CustomScrollBar::~CustomScrollBar()
{

}

void CustomScrollBar::OnKeyDown(KeyEventArgs e)
{
	switch (e.KeyChar)
	{
	case KEYUP:
		OnScrollUp();
		break;
	case KEYDOWN:
		OnScrollDown();
		break;
	default:
		break;
	}


	this->DisplayRectangle = GDI::Rectangle(this->Location, this->Width, this->Height);

	// call to parent method
	// update by Window
	this->Update();
}

void CustomScrollBar::OnKeyPress(KeyEventArgs e)
{
	// action same OnKeyDown
	OnKeyDown(e);
}

// not process when release key
void CustomScrollBar::OnKeyUp(KeyEventArgs e)
{
	// nothing
}

void CustomScrollBar::OnScrollUp()
{
	OnScrollDec();
}

void CustomScrollBar::OnScrollDown()
{
	OnScrollInc();
}

void CustomScrollBar::OnPaint(PaintEventArgs e)
{
	int16_t barActive_y = this->Location.y +
		(Height - sizePointer)*(GetActive()) / (GetTotal() - 1);

	GDI::Draw::DrawRect(GDI::Rectangle(Location.x, barActive_y, Width,
		sizePointer), colorPointer);

}

void CustomScrollBar::OnPaintBackground(PaintEventArgs pevent)
{

	GDI::Draw::DrawRect(GDI::Rectangle(Location, Width, Height), BackColor);

	// draw backgorund
	if (BackImage != NULL)
	{
		GDI::Draw::DrawPicture(*BackImage, Location);
	}
}

