#include "Timer.h"
#include <stdio.h>
#include <string.h>
#include <vector>
#include <assert.h>
#include "FWDebug.h"

static std::vector<Timer*> ListTimer;

Timer::Timer()
{
	memset(&TimerObj, 0, sizeof(TimerObj));

	Name = "Timer";
	Tick = NULL;

}

Timer::Timer(int interval, EventHandler Tick)
{
	memset(&TimerObj, 0, sizeof(TimerObj));

	Name = "Timer";
	this->Tick = Tick;

}

Timer::~Timer()
{
	// syscall to close timer
	this->Dispose();
}

bool Timer::IsEnabled()
{
	// need override
	BOOLEAN tmStatus = true;
	///NtCheckTimerActive(&this->TimerObj, &tmStatus);
	return tmStatus;

}

void Timer::Enable(bool enable)
{

}

void Timer::Dispose()
{
	
}

void Timer::SetInterval(int interval)
{
	
}

int Timer::GetInterval()
{
	return int();
}

void Timer::OnTimer(EventArgs e)
{
	if (Tick != NULL)
	{
		Tick(this, e);
	}
}
