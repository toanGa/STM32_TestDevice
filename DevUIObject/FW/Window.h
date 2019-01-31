#pragma once
#include "Control.h"
class Window :
	public Control
{
private:
	void* App;
public:
	Window();
	~Window();
	void Start();
	void Stop();
	void Dispose();
	EventHandler WindowCreate;
	EventHandler WindowStart;
	EventHandler WindowResume;
	EventHandler WindowPause;
	EventHandler WindowStop;
	EventHandler WindowDestroy;
protected:
	// lifecycle function (for Window)
	virtual void OnCreate();
	virtual void OnStart();
	virtual void OnResume();
	virtual void OnPause();
	virtual void OnStop();
	virtual void OnDestroy();

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

public:

	// need protected
	virtual void WndProc(Message m);
	void WndProcAppMessage(int AppMess);
};

