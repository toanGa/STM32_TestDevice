#pragma once
#include<stdint.h>
#include<stdio.h>
#include<vector>
#include<list>
#include<string.h>
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

class PaintEventArgs : public EventArgs
{
public:
	typedef enum
	{
		PaintDrawControl,
		PaintShowControl,
		PaintHideControl,
		PaintDrawPartControl,
		PaintShowPartControl
	}PaintOption;
	// modify here
	PaintOption PainOption;
};

typedef struct
{
public:
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
}Rectangle;

typedef void(*EventHandler)(void* sender, EventArgs e);
typedef void(*KeyEventHandler)(void* sender, KeyEventArgs e);


class Control
{
private:
	vector<Control*> ListControlAdded;
	Control* MasterControl;
	bool Enable;
	bool Visible;
	int TextSize;
protected:
	Control * Focusing;
public:
	typedef enum
	{
		ControlBase,
		ControlWindow,
		ControlPanel,
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

	//Rectangle DisplayRectangle;
	void* Tag;
	int TabIndex;

	const Font DefaultFont();
	const Color DefaultForeColor();
	const Color DefaultBackColor();
	
	Padding Margin;
	char* Text;
	Font Font;
	Color BackColor;
	Image BackImage;
	Color ForeColor;
	Rectangle DisplayRectangle;// protected

	// Callback event
	EventHandler LostFocus;
	EventHandler TextChanged;
	KeyEventHandler KeyDown;
	KeyEventHandler KeyPress;
	KeyEventHandler KeyUp;

	//
	// Summary:
	//     Brings the control to the front of the z-order.
	void BringToFront();
	bool Contains(Control* ctl);

	void Add(Control* value);
	void Clear();
	void Remove(Control* value);
	Control* GetNextControl(Control* ctl, bool forward);

	//
	// Summary:
	//     Causes the control to redraw the invalidated regions within its client area.
	void Update();
	//
	// Summary:
	//     Conceals the control from the user.
	void Hide();
	//
	// Summary:
	//     Displays the control to the user.
	void Show();
	void Draw();
	//
	// Summary:
	//     Releases the unmanaged resources used by the System.Windows.Forms.Control and
	//     its child controls and optionally releases the managed resources.
	//
	// Parameters:
	//   disposing:
	//     true to release both managed and unmanaged resources; false to release only unmanaged
	//     resources.
	void Dispose(bool disposing);

	void Dispose();

	//
	// Summary:
	//     Sets input focus to the control.
	//
	// Returns:
	//     true if the input focus request was successful; otherwise, false.
	bool Focus();

	Control* FindWindow();

	virtual char* GetText();
	virtual void SetText(char* content);

	int GetTextSize();
	bool SetTextSize(int size);

	//
	// Summary:
	//     Forces the control to invalidate its client area and immediately redraw itself
	//     and any child controls.
	virtual void Refresh();
	virtual void ResetBackColor();
	virtual void ResetFont();
	virtual void ResetForeColor();

	virtual void WndProc(Message m);

	virtual char* ToString();
	void run();
	
protected:
	// lifecycle function (for Application)
	//virtual void OnCreate();
	//virtual void OnStart();
	//virtual void OnResume();
	//virtual void OnPause();
	//virtual void OnStop();
	//virtual void OnDestroy();

	virtual void OnTextChanged(EventArgs e);
	virtual void OnKeyDown(KeyEventArgs e);
	virtual void OnKeyPress(KeyEventArgs e);
	virtual void OnKeyUp(KeyEventArgs e);
	virtual void OnLostFocus(EventArgs e);
	//
	// Summary:
	//     Raises the System.Windows.Forms.Control.Paint event.
	//
	// Parameters:
	//   e:
	//     A System.Windows.Forms.PaintEventArgs that contains the event data.
	virtual void OnPaint(PaintEventArgs e);
	//
	// Summary:
	//     Paints the background of the control.
	//
	// Parameters:
	//   pevent:
	//     A System.Windows.Forms.PaintEventArgs that contains information about the control
	//     to paint.
	virtual void OnPaintBackground(PaintEventArgs pevent);
};

