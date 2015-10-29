# GRCBox C\# Client
This repository contains a GRCBox client library written in
C#. It allows to implement GRCBox-aware applications for windows.

It has been tested in Windows 7, but should work in Windows 
Mobile too. 

Issues:
In windows 7, the hostname "grcbox" is not properly resolved. DNS 
were configured correctly since `nslookup grcbox` returned the
correct IP.