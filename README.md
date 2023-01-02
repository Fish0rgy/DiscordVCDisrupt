# DiscordVCDisrupt 
This program is designed to disrupt voice calls on the Discord platform by sending a large amount of traffic to a Discord voice channel and rapidly connecting and disconnecting the user.

Here is a summary of the procedures carried out by the application:

1. The application prompts the user to enter several pieces of information, including the WebSocket server address, a server ID, a user ID, a session ID, and a token.

2. The application enters an infinite loop.

3. In each iteration of the loop, the application does the following:
    a. Establishes a new WebSocket connection to the server specified by the user.
    b. Sends a message to the server over the WebSocket connection. The message contains various parameters, including the server ID, user ID, session ID, and token.
    c. Disrupts the call and does not allow anyone to hear or talk until the user closes the application.

Copyright (C) 2023 Fish.#0002

This program is free software: you can redistribute it and/or modify
it under the terms of the GNU General Public License as published by
the Free Software Foundation, either version 3 of the License, or
(at your option) any later version.

This program is distributed in the hope that it will be useful,
but WITHOUT ANY WARRANTY; without even the implied warranty of
MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
GNU General Public License for more details.

You should have received a copy of the GNU General Public License
along with this program.  If not, see <https://www.gnu.org/licenses/>.

This program is intended for educational purposes only. The developer(s) do not encourage or endorse the use of this program for any purpose other than education. The developer(s) are not responsible for any misuse of this program.
