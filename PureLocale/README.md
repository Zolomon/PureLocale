﻿# PureLocale

**PureLocale** is a tool to keep the keyboard input locale on Windows in a 
clean and consistent state. 

There are applications that modify the locale without the user's consent. 
**PureLocale** reverts this if detectable and possible.

Currently there are checks for when `InputLanguage` changes in C#, 
as well as on changes for the `HKEY_CURRENT_USER\Keyboard Layout\Preload` 
registry key.


# TODO
*  [ ] Figure out how to purify `Settings > Time & Language > Region & Language`.
*  [ ] Turn into a service.
*  [ ] Create installation script for service.

# Warning

**PureLocale** tampers with the registry keys. During research a selection 
of registry keys was found to have a possible effect on the current state 
of the locale.

> **Create a backup prior to usage.**

**This software is in experimental state, subject to change and failure.**

Use this at your own risk (*peril*). You have been warned.

# Usage

1. Download
2. Build with VS2015
3. Run ~/PureLocale/bin/Debug/PureLocale.exe

# License 
See [LICENSE](https://github.com/Zolomon/PureLocale/blob/master/LICENSE).