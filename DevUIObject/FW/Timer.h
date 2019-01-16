#pragma once
#include "EventArgs.h"
#include "SYSCALL/syscall.h"

class Timer
{
private:
	TimerObject TimerObj;

private:
	static void SysCallback(HANDLE PTimerObj);
	static Timer* FindTimer(PTimerObject TimerObj,int* Index);
	bool CreateSystemTimer();
public:
	Timer();
	Timer(int interval, EventHandler Tick);
	~Timer();

	char* Name;
	bool IsEnabled();
	void Enable(bool enable);
	void SetInterval(int interval);
	int GetInterval();

	EventHandler Tick;
protected:
	virtual void OnTimer(EventArgs e);
};
