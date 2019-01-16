#pragma once
class EventArgs
{
public:

};

typedef void(*EventHandler)(void* sender, EventArgs e);
