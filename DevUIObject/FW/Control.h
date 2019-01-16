#pragma once
#include<stdint.h>
#include<stdio.h>
#include<vector>
#include<list>
#include<string.h>
#include "Message.h"
#include "GUI.h"
#include "GDI/Padding.h"
#include "GDI/Rectangle.h"
#include "GDI/Point.h"
#include "GDI/Draw.h"
#include "EventArgs.h"
#include "KeyEventArgs.h"
#include "PaintEventArgs.h"
#include "Timer.h"

#include "FWDebug.h"

using namespace std;
using namespace GDI;

#define override
#define OVERRIDE

//class Color
//{
//public:
//	uint8_t R;
//	uint8_t G;
//	uint8_t B;
//};



//class Image
//{
//
//};

//class Font
//{
//
//};

class Control
{
private:
	Control* MasterControl;
	char* Text;
	int TextSize;
	static const int DEFAULT_TEXT_SIZE;

	vector<Control*> ListControlAdded;
	// timer for control handler with timer
	// just one timer share all object
	static void CallBackControlTimer(void* sender, EventArgs e);
	static Timer ControlTimer;
protected:
	Control * Focusing;
	bool Enable;
	bool Visible;
	void EnableControlTimer(bool enable);
public:
	typedef enum
	{
		ControlBase,
		ControlWindow,
		ControlPanel,
		ControlButton,
		ControlLabel,
		ControlUser,
	}EControlType;
	
public:
	Control();
	~Control();

	// Get set method after done
	EControlType ControlType;
	char* Name;
	GDI::Point Location;
	int Width;
	int Height;

	//Rectangle DisplayRectangle;
	void* Tag;
	int TabIndex;

	static const Font DefaultFont;
	static const Color DefaultForeColor;
	static const Color DefaultBackColor;
	
	GDI::Padding Margin;
	
	Font  FontText;
	Color BackColor;
	Image* BackImage;
	Color ForeColor;
	Color BoderColor;
	int BoderSize;

	GDI::Rectangle DisplayRectangle;// protected

	// Callback event
	EventHandler LostFocus;
	EventHandler AppropFocus;
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
	bool FocusNextControl(bool forward);
	virtual GDI::Point RelativeLocation();
	GDI::Rectangle ControlRectangle();
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
	bool IsFocusing();
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
	
protected:

	virtual void OnTextChanged(EventArgs e);
	virtual void OnKeyDown(KeyEventArgs e);
	virtual void OnKeyPress(KeyEventArgs e);
	virtual void OnKeyUp(KeyEventArgs e);
	virtual void OnControlTimer(EventArgs e);
	virtual void OnLostFocus(EventArgs e);
	virtual void OnAppropFocus(EventArgs e);
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

	// using in window -> need seperate in IContainable interface
	virtual void OnUpdateControl(Control* control);
	virtual void OnHideControl(Control* control);
	virtual void OnShowControl(Control* control);
	virtual void OnDrawControl(Control* control);
};

