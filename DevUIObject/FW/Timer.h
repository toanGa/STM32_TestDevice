#pragma once
#include "EventArgs.h"
//#include "SYSCALL/syscall.h"

// temp define  -> debug only
#define TimerObject    int
#define PTimerObject   TimerObject*
class Timer
{
private:
	TimerObject TimerObj;

private:

public:
	Timer();
	Timer(int interval, EventHandler Tick);
	~Timer();

	char* Name;
	bool IsEnabled();
	void Enable(bool enable);
	void Dispose();
	void SetInterval(int interval);
	int GetInterval();

	EventHandler Tick;
protected:
	virtual void OnTimer(EventArgs e);
};
