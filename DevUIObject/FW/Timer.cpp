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
	this->TimerObj.DueTime = 100;
	this->TimerObj.Period  = 1000;
}

Timer::Timer(int interval, EventHandler Tick)
{
	memset(&TimerObj, 0, sizeof(TimerObj));

	Name = "Timer";
	this->Tick = Tick;
	this->TimerObj.DueTime = 100;
	this->TimerObj.Period  = interval;
}

Timer::~Timer()
{
	// syscall to close timer
	this->Enable(false);
}

Timer* Timer::FindTimer(PTimerObject TimerObj,int* Index)
{
	int size = ListTimer.size();
	int i;
	for(i = 0; i < size; i++)
	{
		if(TimerObj == &ListTimer.at(i)->TimerObj)
		{
			if(Index != NULL)
			{
				*Index = i;
			}
			return ListTimer.at(i);
		}
	}

	return NULL;
}

bool Timer::CreateSystemTimer()
{
	NtCreateTimer(&TimerObj, SynchronizationTimer, false, SysCallback, TimerObj.Period, TimerObj.DueTime);
	ListTimer.push_back(this);
	return true;
}

void Timer::SysCallback(HANDLE PTimerObj)
{
	Timer* tm = FindTimer((PTimerObject)PTimerObj, NULL);
	// implement detail event argument
	EventArgs e;

	tm->OnTimer(e);
}

bool Timer::IsEnabled()
{
	// need override
	BOOLEAN tmStatus;
	NtCheckTimerActive(&this->TimerObj, &tmStatus);
	return tmStatus;

}

void Timer::Enable(bool enable)
{
	// syscall to enable timer
	if(!enable)
	{
		// if timer is already open -> close and release resource
		if(IsEnabled())
		{
			NtCancelTimer(&(TimerObj), NULL);

			int indexClear;
			Timer* tm = FindTimer((PTimerObject)&TimerObj, &indexClear);
			if(tm != NULL)
			{
				assert(this == tm);
				ListTimer.erase(ListTimer.begin() + indexClear);
			}
			else
			{
				PRINTF("Timer %s has been stopped\r\n", tm->Name);
			}
		}
	}
	else
	{
		// Open timer if previous not open
		if(!IsEnabled())
		{
			if(TimerObj.Handle != NULL)
			{
				int indexClear;
				Timer* tm = FindTimer((PTimerObject)&TimerObj, &indexClear);
				if(tm != NULL)
				{
					assert(this == tm);
					ListTimer.erase(ListTimer.begin() + indexClear);
				}
				NtCancelTimer(&(TimerObj), NULL);
			}

			CreateSystemTimer();
			NtOpenTimer(&TimerObj);
		}
	}
}

void Timer::SetInterval(int interval)
{
	this->TimerObj.Period = interval;
	NtSetTimer(&TimerObj, TimerObj.DueTime,TimerObj.Context, this->TimerObj.Period, NULL);
}

int Timer::GetInterval()
{
	return TimerObj.Period;
}

void Timer::OnTimer(EventArgs e)
{
	if (Tick != NULL)
	{
		Tick(this, e);
	}
}
