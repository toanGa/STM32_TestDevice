#include "Message.h"

Message::Message()
{
	Msg = MessageUndefined;
}

Message::Message(EMessage msg)
{
	Msg = msg;
}

Message::~Message()
{
}

char * Message::ToString()
{
	switch (Msg)
	{
	case MessageKB0Up:
		return (char*)"MessageKB0Up";
	case MessageKB0Down:
		return (char*)"MessageKB0Down";
	case MessageKB0Press:
		return (char*)"MessageKB0Press";
	case MessageKB1Up:
		return (char*)"MessageKB1Up";
	case MessageKB1Down:
		return (char*)"MessageKB1Down";
	case MessageKB1Press:
		return (char*)"MessageKB1Press";
	case MessageKB2Up:
		return (char*)"MessageKB2Up";
	case MessageKB2Down:
		return (char*)"MessageKB2Down";
	case MessageKB2Press:
		return (char*)"MessageKB2Press";
	case MessageKB3Up:
		return (char*)"MessageKB3Up";
	case MessageKB3Down:
		return (char*)"MessageKB3Down";
	case MessageKB3Press:
		return (char*)"MessageKB3Press";
	case MessageKB4Up:
		return (char*)"MessageKB4Up";
	case MessageKB4Down:
		return (char*)"MessageKB4Down";
	case MessageKB4Press:
		return (char*)"MessageKB4Press";
	case MessageKB5Up:
		return (char*)"MessageKB5Up";
	case MessageKB5Down:
		return (char*)"MessageKB5Down";
	case MessageKB5Press:
		return (char*)"MessageKB5Press";
	case MessageKB6Up:
		return (char*)"MessageKB6Up";
	case MessageKB6Down:
		return (char*)"MessageKB6Down";
	case MessageKB6Press:
		return (char*)"MessageKB6Press";
	case MessageKB7Up:
		return (char*)"MessageKB7Up";
	case MessageKB7Down:
		return (char*)"MessageKB7Down";
	case MessageKB7Press:
		return (char*)"MessageKB7Press";
	case MessageKB8Up:
		return (char*)"MessageKB8Up";
	case MessageKB8Down:
		return (char*)"MessageKB8Down";
	case MessageKB8Press:
		return (char*)"MessageKB8Press";
	case MessageKB9Up:
		return (char*)"MessageKB9Up";
	case MessageKB9Down:
		return (char*)"MessageKB9Down";
	case MessageKB9Press:
		return (char*)"MessageKB9Press";
	case MessageKBStarUp:
		return (char*)"MessageKBStarUp";
	case MessageKBStarDown:
		return (char*)"MessageKBStarDown";
	case MessageKBStarPress:
		return (char*)"MessageKBStarPress";
	case MessageKBHashtagUp:
		return (char*)"MessageKBHashtagUp";
	case MessageKBHashtagDown:
		return (char*)"MessageKBHashtagDown";
	case MessageKBHashtagPress:
		return (char*)"MessageKBHashtagPress";
	case MessageKBHomeUp:
		return (char*)"MessageKBHomeUp";
	case MessageKBHomeDown:
		return (char*)"MessageKBHomeDown";
	case MessageKBHomePress:
		return (char*)"MessageKBHomePress";
	case MessageKBCallUp:
		return (char*)"MessageKBCallUp";
	case MessageKBCallDown:
		return (char*)"MessageKBCallDown";
	case MessageKBCallPress:
		return (char*)"MessageKBCallPress";
	case MessageKBVolupUp:
		return (char*)"MessageKBVolupUp";
	case MessageKBVolupDown:
		return (char*)"MessageKBVolupDown";
	case MessageKBVolupPress:
		return (char*)"MessageKBVolupPress";
	case MessageKBVoldownUp:
		return (char*)"MessageKBVoldownUp";
	case MessageKBVoldownDown:
		return (char*)"MessageKBVoldownDown";
	case MessageKBVoldownPress:
		return (char*)"MessageKBVoldownPress";
	case MessageKBPowerUp:
		return (char*)"MessageKBPowerUp";
	case MessageKBPowerDown:
		return (char*)"MessageKBPowerDown";
	case MessageKBPowerPress:
		return (char*)"MessageKBPowerPress";
	case MessageTimer:
		return (char*)"MessageTimer";
	default:
		return (char*)"";
	}
}
