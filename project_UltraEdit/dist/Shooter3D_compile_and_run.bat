
: disable all outputs
@echo off

: set the root path of the Shooter3D project
SET PROJECT_PATH=E:\workspaces\visual_studio\Shooter3D\trunk\
SET PROJECT_NAME=Shooter3D

: change to project path
cd /d %PROJECT_PATH%

: delete the existent exe file
del %PROJECT_NAME%.exe

: compile the project using .NET 2.0
C:\Windows\Microsoft.NET\Framework\v2.0.50727\csc.exe /platform:x86 /out:%PROJECT_PATH%%PROJECT_NAME%.exe /reference:%PROJECT_PATH%csgl.dll;%PROJECT_PATH%Microsoft.DirectX.AudioVideoPlayback.dll %PROJECT_PATH%*.cs %PROJECT_PATH%Classes\Engine3D\*.cs %PROJECT_PATH%Classes\EngineGame\*.cs %PROJECT_PATH%Classes\Game\*.cs %PROJECT_PATH%Classes\IO\*.cs %PROJECT_PATH%Classes\Engine3D\SolidMeshes\Walls\*.cs %PROJECT_PATH%Classes\Engine3D\SolidMeshes\*.cs %PROJECT_PATH%Classes\Engine3D\MaskedMeshes\*.cs %PROJECT_PATH%Classes\Engine3D\MeshCollection\*.cs %PROJECT_PATH%Classes\Engine3D\WallFaces\*.cs

: run the compiled exe file
%PROJECT_PATH%%PROJECT_NAME%.exe

: paws till a key is pressed
pause
