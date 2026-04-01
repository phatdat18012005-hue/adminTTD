#!/usr/bin/env pwsh

# Script chay ung dung ASP.NET Core
# Cach su dung: 
#   1. Nhan right-click trong folder project
#   2. Chon "Open with PowerShell"
#   3. Chay: .\run-app.ps1

Write-Host "========================================" -ForegroundColor Cyan
Write-Host "  HE THONG QUAN TRI - STARTUP SCRIPT" -ForegroundColor Green
Write-Host "========================================" -ForegroundColor Cyan
Write-Host ""

# Kiem tra .NET SDK
Write-Host "Kiem tra .NET SDK..." -ForegroundColor Yellow
try {
    $dotnetVersion = dotnet --version
    Write-Host "? .NET SDK version: $dotnetVersion" -ForegroundColor Green
} catch {
    Write-Host "? Loi: .NET SDK chua duoc cai dat!" -ForegroundColor Red
    Write-Host "  Tai tu: https://dotnet.microsoft.com/download" -ForegroundColor Yellow
    Exit 1
}

# Kiem tra database connection
Write-Host "`nKiem tra ket noi Database..." -ForegroundColor Yellow
$connectionString = "Server=PHATDAT;Database=TTD;Trusted_Connection=True;TrustServerCertificate=True"
Write-Host "  Connection String: $connectionString" -ForegroundColor Gray

# Chay ung dung
Write-Host "`nChay ung dung..." -ForegroundColor Yellow
Write-Host ""

Write-Host "THONG TIN:" -ForegroundColor Cyan
Write-Host "  - API se chay tren HTTP va HTTPS" -ForegroundColor Gray
Write-Host "  - Neu thay loi HTTPS, click 'Proceed anyway'" -ForegroundColor Gray
Write-Host "  - Dang xuat: Nhan Ctrl+C" -ForegroundColor Gray
Write-Host ""

# Chay app
dotnet run

Write-Host ""
Write-Host "========================================" -ForegroundColor Cyan
Write-Host "  UNG DUNG DA DUNG" -ForegroundColor Yellow
Write-Host "========================================" -ForegroundColor Cyan
