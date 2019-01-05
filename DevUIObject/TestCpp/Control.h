#pragma once
#include<stdint.h>
#include<stdio.h>
#include<vector>

using namespace std;

class Color
{
public:
	uint8_t R;
	uint8_t G;
	uint8_t B;
};

class Point
{
public:
	// Implement later
	//Point();
	//Point(int x, int y);
	int x;
	int y;
};

class Image
{

};

class Font
{

};

class EventArgs
{

};

class KeyEventArgs : public EventArgs
{
public:
	char KeyChar;
};

class Message
{
public:
	int Msg;
};

typedef struct
{
public:
	//
	// Summary:
	//     Gets the combined padding for the right and left edges.
	//
	// Returns:
	//     Gets the sum, in pixels, of the System.Windows.Forms.Padding.Left and System.Windows.Forms.Padding.Right
	//     padding values.
	int Horizontal;
	//
	// Summary:
	//     Gets or sets the padding value for the top edge.
	//
	// Returns:
	//     The padding, in pixels, for the top edge.
	int Top;
	//
	// Summary:
	//     Gets or sets the padding value for the right edge.
	//
	// Returns:
	//     The padding, in pixels, for the right edge.
	int Right;
	//
	// Summary:
	//     Gets or sets the padding value for the left edge.
	//
	// Returns:
	//     The padding, in pixels, for the left edge.
	int Left;
	//
	// Summary:
	//     Gets or sets the padding value for the bottom edge.
	//
	// Returns:
	//     The padding, in pixels, for the bottom edge.
	int Bottom;
	//
	// Summary:
	//     Gets or sets the padding value for all the edges.
	//
	// Returns:
	//     The padding, in pixels, for all edges if the same; otherwise, -1.
	int All;
}Padding;


typedef void(*EventHandler)(void* sender, EventArgs e);
typedef void(*KeyEventHandler)(void* sender, KeyEventArgs e);


class Control
{
public:
	typedef enum
	{
		ControlBase,
		ControlButton,
		ControlLabel
	}EControlType;
	
public:
	Control();
	~Control();

	EControlType ControlType;
	char* Name;
	Point Location;
	int Width;
	int Height;
	void* Tag;
	int TabIndex;
	bool Enable;
	bool Visible;

	const Font DefaultFont();
	const Color DefaultForeColor();
	const Color DefaultBackColor();
	
	Padding Margin;
	char* Text;
	Font Font;
	Color BackColor;
	Image BackImage;
	Color ForeColor;

	EventHandler TextChanged;
	KeyEventHandler KeyDown;
	KeyEventHandler KeyPress;
	KeyEventHandler KeyUp;

	void BringToFront();
	bool Contains(Control* ctl);

	virtual void Add(Control* value);
	virtual void Clear();
	virtual void Remove(Control* value);

	virtual void Update();
	virtual void Hide();
	virtual void Show();
	virtual void Draw();
	virtual void Dispose();

	virtual void Refresh();
	virtual void ResetBackColor();
	virtual void ResetFont();
	virtual void ResetForeColor();

	virtual void WndProc(Message m);

	virtual char* ToString();
	void run();
	
protected:
	virtual void OnTextChanged(EventArgs e);
	virtual void OnKeyDown(KeyEventArgs e);
	virtual void OnKeyPress(KeyEventArgs e);
	virtual void OnKeyUp(KeyEventArgs e);
};

