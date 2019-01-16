#pragma once
#include <stdint.h>

#define NTSTATUS   uint32_t
#define OUT        
#define IN         const
#define HANDLE     void*
#define PHANDLE    HANDLE*
#define INT        int32_t
#define UINT       uint32_t
#define PINT       INT*
#define PUINT      UINT*
#define BOOLEAN    uint8_t
#define PBOOLEAN   BOOLEAN*
#define LARGE_INT  int64_t
#define PLARGE_INT LARGE_INT*
#define VOID       void
#define PVOID      VOID*
#define ULONG      unsigned long
#define PULONG     ULONG*
#define LARGE_INTEGER  int64_t
#define PLARGE_INTEGER LARGE_INTEGER*
#define OPTIONAL

typedef void (*TIMER_CALLBACK)(HANDLE PTimerObj);

typedef enum _EVENT_TYPE
{
	NotificationEvent,//Known also as manual-reset event
	SynchronizationEvent //Known as auto-reset event
} EVENT_TYPE, *PEVENT_TYPE;

typedef enum _TIMER_TYPE
{
	NotificationTimer,//Known also as manual-reset event
	SynchronizationTimer //Known as auto-reset event
} TIMER_TYPE;

enum _NTSTATUS
{
#ifndef _WIN32_WINNT
	STATUS_SUCCESS = 0x00000000,
	STATUS_TIMEOUT = 0x00000102,
#endif

	STATUS_FAIL = 0xFFFFFFFF
};

typedef struct
{
	HANDLE          Handle;
	TIMER_TYPE      Type;
	TIMER_CALLBACK  Context;
	INT             DueTime;
	INT				Period;
	UINT			Args;
}TimerObject, *PTimerObject;
