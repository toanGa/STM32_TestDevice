#include "syscall.h"
#include "ti/sysbios/knl/Clock.h"
#include "ti/sysbios/knl/Event.h"
#include <stdlib.h>
#include <vector>
#include <ti/sysbios/knl/Swi.h>

static INT TimerArg = 0;
std::vector<PTimerObject> ListTimerObj;
std::vector<PTimerObject> ListHandleTimerObj;

static PTimerObject NtFindTimer(std::vector<PTimerObject>* ListTimer,IN UINT Arg, OUT PINT Index OPTIONAL);

// extern
extern Event_Handle event_user_handler;

// all timer callback jump here
static void OnTimer(UINT TimerArg)
{
	INT idxTimer;
	PTimerObject pRemove = NtFindTimer(&ListTimerObj, TimerArg, &idxTimer);

	if(pRemove != NULL)
	{
		// Post to USER thread
		ListHandleTimerObj.push_back(pRemove);
		Event_post(event_user_handler, Event_Id_20);
	}
}

void TimerCallback()
{
	int totalCallback = ListHandleTimerObj.size();
	int i;
	for(i = 0; i < totalCallback; i++)
	{
		// protect
		uint32_t key = Swi_disable();
		PTimerObject pHandle = ListHandleTimerObj.at(i);
		Swi_restore(key);

		if(pHandle->Context != NULL)
		{
			pHandle->Context((HANDLE) pHandle);
		}
	}

	// protect list using both task and swi
	uint32_t key = Swi_disable();
	ListHandleTimerObj.clear();
	Swi_restore(key);
}

NTSTATUS NtCreateTimer(OUT PTimerObject TimerObj,
		IN TIMER_TYPE TimerType, BOOLEAN StartFlag,
		IN TIMER_CALLBACK TimerContext OPTIONAL,
		IN INT Period OPTIONAL,
		IN INT DueTime)
{
	Clock_Params    clockParams;
    Clock_Params_init(&clockParams);
    if(TimerType == NotificationTimer)
    {
    	clockParams.period = 0;
    }
    else
    {
    	clockParams.period = Period;
    }

    clockParams.arg       = TimerArg;
    TimerArg++; // Increase Arg immediately -> distinct Timer object
    clockParams.startFlag = StartFlag;

    TimerObj->Handle      = (HANDLE)Clock_create(OnTimer, Period, &clockParams, NULL);

    TimerObj->Type        = TimerType;
    TimerObj->DueTime     = DueTime;
    TimerObj->Period      = Period;
    TimerObj->Context     = TimerContext;
    TimerObj->Args        = clockParams.arg;
    if(TimerObj->Handle != NULL)
    {
    	ListTimerObj.push_back(TimerObj);

    	return STATUS_SUCCESS;
    }

    return STATUS_TIMEOUT;
}

NTSTATUS NtSetTimer(IN PTimerObject TimerObj, IN INT DueTime, IN TIMER_CALLBACK TimerContext OPTIONAL, IN INT Period OPTIONAL, OUT PBOOLEAN PreviousState OPTIONAL)
{
	uint8_t oldIsActive = Clock_isActive((Clock_Handle)TimerObj->Handle);
	if(PreviousState != NULL)
	{
		if(oldIsActive)
		{
			*PreviousState = TRUE;
		}
		else
		{
			*PreviousState = FALSE;
		}
	}

	if(oldIsActive)
	{
		NtCancelTimer(TimerObj, NULL);

	}
	TimerObj->DueTime = DueTime;
	TimerObj->Context = TimerContext;

	NtCreateTimer(TimerObj, TimerObj->Type, false, TimerObj->Context, TimerObj->Period, TimerObj->DueTime);
	Clock_setTimeout((Clock_Handle)TimerObj->Handle, DueTime);
	Clock_setPeriod((Clock_Handle)TimerObj->Handle, Period);
	// function has already set in NtCreateTimer
	//Clock_setFunc((Clock_Handle)TimerObj->Handle, (Clock_FuncPtr)OnTimer, TimerObj->Args);
	if(oldIsActive)
	{
		NtOpenTimer(TimerObj);
	}

	return STATUS_SUCCESS;
}

NTSTATUS NtCancelTimer(IN PTimerObject TimerObj, OUT PBOOLEAN CurrentState OPTIONAL)
{
	INT idxTimerCancel;

	if(CurrentState != NULL)
	{
		if(Clock_isActive((Clock_Handle)TimerObj->Handle))
		{
			*CurrentState = TRUE;
		}
		else
		{
			*CurrentState = FALSE;
		}
	}

	// delete system clock
	Clock_delete((Clock_Handle*)(&TimerObj->Handle));

	// update on list clock
	PTimerObject pRemove = NtFindTimer(&ListTimerObj, TimerObj->Args, &idxTimerCancel);
	if(pRemove != NULL)
	{
		ListTimerObj.erase(ListTimerObj.begin() + idxTimerCancel);
		return STATUS_SUCCESS;
	}
	else
	{
		return STATUS_FAIL;
	}
}


NTSTATUS NtOpenTimer(
					OUT PTimerObject TimerObj)
{
	Clock_start((Clock_Handle)TimerObj->Handle);
	return NTSTATUS();
}

NTSTATUS NtQueryTimer(IN HANDLE TimerHandle, OUT PVOID TimerInformation, IN ULONG TimerInformationLength, OUT PULONG ReturnLength OPTIONAL)
{
	return NTSTATUS();
}

NTSTATUS NtCheckTimerActive(IN PTimerObject TimerObj, OUT PBOOLEAN TimerStatus)
{
	*TimerStatus = Clock_isActive((Clock_Handle)TimerObj->Handle);

	return STATUS_SUCCESS;
}

UINT NtGetTickCount()
{
	return Clock_getTicks();
}

NTSTATUS NtQuerySystemTime(
					OUT PLARGE_INTEGER SystemTime )
{

	return NTSTATUS();
}

static PTimerObject NtFindTimer(std::vector<PTimerObject>* ListTimer,IN UINT Arg, OUT PINT Index OPTIONAL)
{
	int i;
	int index = -1;
	int totalTimer = ListTimer->size();
	PTimerObject pObject = NULL;

	for(i = 0; i < totalTimer; i++)
	{
		if(ListTimer->at(i)->Args == Arg)
		{
			pObject = ListTimer->at(i);
			index   = i;
		}
	}

	if(Index != NULL)
	{
		*Index = index;
	}

	return pObject;
}
