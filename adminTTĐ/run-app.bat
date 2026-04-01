@echo off
REM Script chay ung dung ASP.NET Core tren Windows
REM Cach su dung: 
REM   1. Double-click file run-app.bat
REM   2. Hoac chay trong command prompt

cls
echo.
echo ========================================
echo   HE THONG QUAN TRI - STARTUP
echo ========================================
echo.

REM Kiem tra .NET SDK
echo Kiem tra .NET SDK...
dotnet --version >nul 2>&1
if %errorlevel% neq 0 (
    echo X Loi: .NET SDK chua duoc cai dat!
    echo   Tai tu: https://dotnet.microsoft.com/download
    pause
    exit /b 1
)

echo O .NET SDK da san sang

REM Kiem tra cai project
echo.
echo Kiem tra du an...
if not exist "adminTTD.csproj" (
    echo X Loi: adminTTD.csproj khong tim thay
    echo   Chay script trong thu muc goc cua project
    pause
    exit /b 1
)

echo O Du an san sang

REM Chay app
echo.
echo Thong tin:
echo   - API se chay tren HTTP va HTTPS
echo   - Neu thay loi HTTPS, click 'Proceed anyway'
echo   - Dang xuat: Nhan Ctrl+C va dong terminal
echo.
echo Chay ung dung...
echo.

dotnet run

echo.
echo ========================================
echo   UNG DUNG DA DUNG
echo ========================================
pause
