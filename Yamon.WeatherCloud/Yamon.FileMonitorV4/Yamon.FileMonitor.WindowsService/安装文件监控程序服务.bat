@echo off
set BASE_DIR=%~dp0
%BASE_DIR:~0,2%
sc create YamonFileMonitorServcieV4 binpath= "%BASE_DIR%Yamon.FileMonitor.WindowsService.exe"   displayname= "�Ʒ����ļ���ط���V4" start= auto type= own
sc start YamonFileMonitorServcieV4
echo �밴������ر�
pause>nul
