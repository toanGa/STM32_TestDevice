#pragma once
#include<stdint.h>
#include<stdio.h>

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
	}ControlType;

public:
	Control();
	~Control();

	ControlType ControlType = ControlBase;
	char* Name = (char*)"Control";
	int Width;
	int Height;
	void* Tag = NULL;
	int TabIndex;
	bool Enable;

	const Font DefaultFont();
	const Color DefaultForeColor();
	const Color DefaultBackColor();

	Point Location;

	char* Text = NULL;
	Font Font;
	Color BackColor;
	Image BackImage;
	Color ForeColor;

	EventHandler TextChanged = NULL;
	KeyEventHandler KeyDown = NULL;
	KeyEventHandler KeyPress = NULL;
	KeyEventHandler KeyUp = NULL;

	void BringToFront();
	bool Contains(Control* ctl);

	virtual void Add(Control* value);
	virtual void Clear();
	virtual void Remove(Control* value);

	void Update();
	void Hide();
	void Show();
	void Draw();

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

