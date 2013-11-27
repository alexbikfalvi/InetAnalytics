/*
* Copyright (C) 2013 Alex Bikfalvi
*
* This program is free software; you can redistribute it and/or modify
* it under the terms of the GNU General Public License as published by
* the Free Software Foundation; either version 3 of the License, or (at
* your option) any later version.
*
* This program is distributed in the hope that it will be useful, but
* WITHOUT ANY WARRANTY; without even the implied warranty of
* MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the GNU
* General Public License for more details.
*
* You should have received a copy of the GNU General Public License
* along with this program; if not, write to the Free Software
* Foundation, Inc., 51 Franklin Street, Fifth Floor, Boston, MA 02110-1301, USA.
*/

#include "Headers.h"
#include "InetAgentServer.h"

int main(int argc, char* argv[])
{
	try
	{
		// Create the server.
		InetAgent::InetAgentServer* server = alloc InetAgent::InetAgentServer(argc, argv);

		// Delete the server.
		delete server;
	}
	catch (std::exception &exception)
	{
		// Show the exception.
		std::cout << "An error occurred while executing the Internet Analytics Agent." << std::endl;
		std::cout << exception.what() << std::endl;
	}

#if defined(_CRTDBG_MAP_ALLOC)
	// Show the memory leaks.
	_CrtDumpMemoryLeaks();
#endif

	return 0;
}
