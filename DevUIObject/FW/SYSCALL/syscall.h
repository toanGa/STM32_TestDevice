#pragma once

#ifdef __cplusplus
extern "C" {
#endif

#include <stdint.h>
#include "ntdef.h"

// return result create timer
NTSTATUS NtCreateTimer(OUT PTimerObject TimerObj,
						IN TIMER_TYPE TimerType, BOOLEAN StartFlag,
						IN TIMER_CALLBACK TimerContext OPTIONAL,
						IN INT Period OPTIONAL,
						IN INT DueTime);
NTSTATUS NtSetTimer(IN PTimerObject TimerObj,
						IN INT DueTime,
						IN TIMER_CALLBACK TimerContext OPTIONAL,
						IN INT Period OPTIONAL,
						OUT PBOOLEAN PreviousState OPTIONAL);
NTSTATUS NtCancelTimer(IN PTimerObject TimerObj,
						OUT PBOOLEAN CurrentState OPTIONAL);
NTSTATUS NtOpenTimer(
					OUT PTimerObject TimerObj);
NTSTATUS NtQueryTimer(
					IN HANDLE      TimerHandle,
					OUT PVOID      TimerInformation,
					IN ULONG       TimerInformationLength,
					OUT PULONG     ReturnLength OPTIONAL);
NTSTATUS NtCheckTimerActive(IN PTimerObject TimerObj,
		            OUT PBOOLEAN TimerStatus);
UINT     NtGetTickCount();
NTSTATUS NtQuerySystemTime(
					OUT PLARGE_INTEGER SystemTime );

void TimerCallback();

#ifdef __cplusplus
}
#endif
